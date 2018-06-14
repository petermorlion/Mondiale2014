using System;
using System.Linq;
using System.Web.Http;
using KotProno2.EntityFramework;
using KotProno2.Models;

namespace KotProno2.Controllers
{
    public class OverviewController : ApiController
    {
        private readonly MatchesContext _matchesContext = new MatchesContext();
        private readonly ApplicationDbContext _applicationDbContext = new ApplicationDbContext();

        [HttpGet]
        public Overview Get(int id)
        {
            var now = TimeZoneInfo.ConvertTime(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("Central Europe Standard Time"));

            var result = new Overview();
            var users = _applicationDbContext.Users.OrderBy(x => x.UserName).ToList();
            var bettings = _matchesContext.Context.Bettings.Where(x => x.Match.TournamentId == id).ToLookup(x => x.MatchId);
            var matches = _matchesContext.Context.Matches
                .Where(x => x.TournamentId == id)
                .OrderByDescending(x => x.DateTime)
                .ToList()
                .Where(x => x.IsReadOnly)
                .ToList();
            var usersWithCorrectTopScorer = _matchesContext.Context.TopScorers.Where(x => x.TournamentId == id && x.IsCorrect).Select(x => x.UserName).ToList();

            //TODO: code grew organically with increasing number of ifs, indenting,... Crap
            foreach (var user in users)
            {
                result.UserNames.Add(user.UserName);
            }

            foreach (var user in usersWithCorrectTopScorer)
            {
                result.UsersWithCorrectTopScorer.Add(user);   
            }

            var hasStageStartedQuery = new HasStageStartedQuery();

            foreach (var match in matches)
            {
                var canShowInOverview = hasStageStartedQuery.Execute(id, match.Stage);

                if (!canShowInOverview)
                {
                    continue;
                }

                var overviewMatch = new OverviewMatch();

                overviewMatch.HomeTeamIsoCode = match.HomeTeamIsoCode;
                overviewMatch.AwayTeamIsoCode = match.AwayTeamIsoCode;
                overviewMatch.HomeScore = match.HomeScore;
                overviewMatch.AwayScore = match.AwayScore;
                overviewMatch.PenaltyWinner = match.PenaltyWinner;

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

                var bettingsForMatch = bettings[match.Id].OrderBy(x => x.UserName);

                foreach (var user in users)
                {
                    var overviewBetting = new OverviewBetting();

                    var betting = bettingsForMatch.SingleOrDefault(x => x.UserName == user.UserName);
                    if (betting != null)
                    {
                        overviewBetting.HomeScore = betting.HomeScore;
                        overviewBetting.AwayScore = betting.AwayScore;
                        overviewBetting.PointsClass = GetPointsClass(betting, match);
                    }

                    overviewMatch.OverviewBettings.Add(overviewBetting);
                }

                result.OverviewMatches.Add(overviewMatch);
            }

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