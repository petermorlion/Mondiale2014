using Breeze.ContextProvider;
using Breeze.WebApi2;
using KotProno2.EntityFramework;
using KotProno2.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace KotProno2.Controllers
{
    [BreezeController]
    public class MatchesController : ApiController
    {
        // TODO: Use repo and DI?
        private readonly MatchesContext _contextProvider = new MatchesContext();

        [HttpGet]
        public string Metadata()
        {
            try
            {
                return _contextProvider.Metadata();
            }
            catch (Exception e)
            {
                return e.Message + Environment.NewLine + Environment.NewLine + e.StackTrace;
            }
        }

        // ~/breeze/matches/Matches
        // ~/breeze/matches/Matches?$filter=HomeTeamId eq 1
        [HttpGet]
        public IQueryable<Match> Matches()
        {
            return _contextProvider.Context.Matches;
        }

        // ~/breeze/matches/Bettings
        // ~/breeze/matches/Bettings?$filter=HomeTeamId eq 1
        [HttpGet]
        [Authorize]
        public IQueryable<Betting> Bettings()
        {
            return _contextProvider.Context.Bettings.Where(x => x.UserName == User.Identity.Name).AsQueryable<Betting>();
        }

        // ~/breeze/matches/SaveChanges
        [HttpGet]
        public SaveResult SaveChanges(JObject saveBundle)
        {
            return _contextProvider.SaveChanges(saveBundle);
        }

        [HttpPost]
        [Authorize]
        public void AddBettings(object data)
        {
            if (!CanSave())
            {
                return;
            }

            var command = new AddBettingsCommand
            {
                DateTime = DateTime.Now,
                Name = "AddBettings",
                Data = data,
                UserName = User.Identity.Name,
            };

            command.Execute(_contextProvider.Context);
            _contextProvider.Context.Commands.Add(command);
            _contextProvider.Context.SaveChangesAsync();
        }

        [HttpGet]
        [Authorize]
        public MatchDetails MatchDetails(int matchId)
        {
            var match = _contextProvider.Context.Matches.Single(x => x.Id == matchId);
            var bettings = _contextProvider.Context.Bettings.Where(x => x.MatchId == matchId);

            return new MatchDetails
            {
                Id = match.Id,
                HomeTeamName = Teams.All.Single(x => x.IsoCode == match.HomeTeamIsoCode).Name,
                AwayTeamName = Teams.All.Single(x => x.IsoCode == match.AwayTeamIsoCode).Name,
                DateTime = match.DateTime,
                Bettings = bettings.ToList()
            };
        }

        // ~/breeze/matches/TopScorer
        [HttpGet]
        [Authorize]
        public TopScorer TopScorer()
        {
            return _contextProvider.Context.TopScorers.SingleOrDefault(x => x.UserName == User.Identity.Name);
        }

        // ~/breeze/matches/TopScorers
        [HttpGet]
        [Authorize]
        public IQueryable<TopScorer> TopScorers()
        {
            return _contextProvider.Context.TopScorers;
        }

        [HttpPost]
        [Authorize]
        public void AddScores(object data)
        {
            if (User.Identity.Name != "petermorlion")
            {
                return;
            }

            var command = new AddScoresCommand
            {
                DateTime = DateTime.Now,
                Name = "AddScores",
                Data = data,
                UserName = User.Identity.Name,
            };

            command.Execute(_contextProvider.Context);
            _contextProvider.Context.Commands.Add(command);
            _contextProvider.Context.SaveChangesAsync();
        }

        // ~/breeze/matches/Points
        [HttpGet]
        public IQueryable<Points> Points()
        {
            var result = new List<Points>();
            var bettings = _contextProvider.Context.Bettings.ToList();
            var matches = _contextProvider.Context.Matches.ToList();
            var users = new ApplicationDbContext().Users.ToList();

            foreach (var user in users)
            {
                result.Add(new Points { UserName = user.UserName });
            }

            foreach (var match in matches)
            {
                if (!match.HomeScore.HasValue && !match.AwayScore.HasValue)
                {
                    continue;
                }

                var bettingsForMatch = bettings.Where(x => x.MatchId == match.Id);
                foreach (var bettingForMatch in bettingsForMatch)
                {
                    var userName = bettingForMatch.UserName;
                    var points = result.SingleOrDefault(x => x.UserName == userName);
                    if (points == null)
                    {
                        points = new Points { UserName = userName };
                        result.Add(points);
                    }

                    if (bettingForMatch.HomeScore == match.HomeScore
                        && bettingForMatch.AwayScore == match.AwayScore)
                    {
                        points.Total += 2;
                    }
                    else if (BettingHasCorrectResult(bettingForMatch, match))
                    {
                        points.Total += 1;
                    }
                }
            }

            return result.AsQueryable();
        }

        private bool BettingHasCorrectResult(Betting bettingForMatch, Match match)
        {
            var bettingResult = bettingForMatch.GetMatchResult();
            var realResult = match.GetMatchResult();
            return bettingResult == realResult;
        }

        // ~/breeze/matches/CanSave
        [HttpGet]
        public bool CanSave()
        {
            return DateTime.UtcNow < new DateTime(2014, 6, 12, 20, 0, 0, DateTimeKind.Utc);
        }

        // ~/breeze/matches/Overview
        [HttpGet]
        public Overview Overview()
        {
            var result = new Overview();
            var users = new ApplicationDbContext().Users.OrderBy(x => x.UserName).ToList();
            var bettings = _contextProvider.Context.Bettings.ToLookup(x => x.MatchId);
            var matches = _contextProvider.Context.Matches.OrderBy(x => x.DateTime).ToList();

            //TODO: this code assumes all users have entered all bettings
            foreach (var user in users)
            {
                result.UserNames.Add(user.UserName);
            }

            foreach (var match in matches)
            {
                var overviewMatch = new OverviewMatch();

                overviewMatch.HomeTeamIsoCode = match.HomeTeamIsoCode;
                overviewMatch.AwayTeamIsoCode = match.AwayTeamIsoCode;
                overviewMatch.HomeScore = match.HomeScore;
                overviewMatch.AwayScore = match.AwayScore;

                var homeTeam = Teams.All.SingleOrDefault(x => x.IsoCode == match.HomeTeamIsoCode);
                if (homeTeam != null)
                {
                    overviewMatch.HomeTeam = homeTeam.Name;
                }

                var awayTeam = Teams.All.SingleOrDefault(x => x.IsoCode == match.AwayTeamIsoCode);
                if (awayTeam != null)
                {
                    overviewMatch.AwayTeam = awayTeam.Name;
                }

                if (bettings.Contains(match.Id))
                {
                    var bettingsForMatch = bettings[match.Id].OrderBy(x => x.UserName);
                    foreach (var betting in bettingsForMatch)
                    {
                        var overviewBetting = new OverviewBetting
                        {
                            HomeScore = betting.HomeScore,
                            AwayScore = betting.AwayScore,
                            PointsClass = GetPointsClass(betting, match)
                        };

                        overviewMatch.OverviewBettings.Add(overviewBetting);
                    }
                }
                               

                result.OverviewMatches.Add(overviewMatch);
            }

            return result;
        }

        // ~/breeze/matches/PointsGraph
        [HttpGet]
        public Statistics Statistics()
        {
            var exactResultsPerUser = new Dictionary<string, int>();

            var result = new Statistics();
            var users = new ApplicationDbContext().Users.OrderBy(x => x.UserName).ToList();
            var bettings = _contextProvider.Context.Bettings.ToLookup(x => x.MatchId);
            var matches = _contextProvider.Context.Matches.OrderBy(x => x.DateTime).ToList();

            result.Categories = new List<string>();
            result.Series = new List<Serie>();

            foreach (var user in users)
            {
                result.Series.Add(new Serie { Name = user.UserName, Data = new List<int>() });
                exactResultsPerUser.Add(user.UserName, 0);
            }

            foreach (var match in matches)
            {
                result.Categories.Add(string.Format("{0} vs {1}", match.HomeTeamIsoCode, match.AwayTeamIsoCode));

                if (!match.HomeScore.HasValue && !match.AwayScore.HasValue)
                {
                    continue;
                }

                var bettingsForMatch = bettings[match.Id].OrderBy(x => x.UserName);
                foreach(var betting in bettingsForMatch)
                {
                    var serie = result.Series.Single(x => x.Name == betting.UserName);
                    var previousScore = serie.Data.LastOrDefault();

                    if (betting.HomeScore == match.HomeScore && betting.AwayScore == match.AwayScore)
                    {
                        serie.Data.Add(previousScore + 2);
                        exactResultsPerUser[betting.UserName] += 1;
                    }
                    else if (betting.GetMatchResult() == match.GetMatchResult())
                    {
                        serie.Data.Add(previousScore + 1);
                    }
                    else
                    {
                        serie.Data.Add(previousScore);
                    }
                }
            }

            var mostExactResults = exactResultsPerUser.Max(x => x.Value);
            result.MostExactResults = mostExactResults;
            result.MostExactResultsUsers = exactResultsPerUser
                .Where(x => x.Value == mostExactResults)
                .Select(x => x.Key).ToList();

            var leastExactResults = exactResultsPerUser.Min(x => x.Value);
            result.LeastExactResults = leastExactResults;
            result.LeastExactResultsUsers = exactResultsPerUser
                .Where(x => x.Value == leastExactResults)
                .Select(x => x.Key).ToList();

            return result;
        }

        private string GetPointsClass(Betting betting, Match match)
        {
            if (!match.HomeScore.HasValue && !match.AwayScore.HasValue)
            {
                return "";
            }

            if (betting.HomeScore == match.HomeScore && betting.AwayScore == match.AwayScore)
            {
                return "two-points";
            }

            if (betting.GetMatchResult() == match.GetMatchResult())
            {
                return "one-point";
            }

            return "";
        }
    }
}