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
    }
}