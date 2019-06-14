using System.Linq;
using System.Web.Http;
using KotProno2.EntityFramework;
using KotProno2.Models;

namespace KotProno2.Controllers
{
    public class OverviewController : ApiController
    {
        private readonly MatchesDbContext _context;
        private readonly ApplicationDbContext _applicationDbContext = new ApplicationDbContext();

        public OverviewController(MatchesDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public Overview Get(int id)
        {
            var result = new Overview();
            var bettings = _context.Bettings.Where(x => x.Match.TournamentId == id).ToLookup(x => x.MatchId);
            var matches = _context.Matches
                .Where(x => x.TournamentId == id)
                .OrderByDescending(x => x.DateTime)
                .ToList()
                .Where(x => x.IsReadOnly)
                .ToList();

            result.UserNames = _applicationDbContext.Users.Select(x => x.UserName).OrderBy(x => x).ToList();
            result.UsersWithCorrectTopScorer = _context.TopScorers.Where(x => x.TournamentId == id && x.IsCorrect).Select(x => x.UserName).ToList();

            var hasStageStartedQuery = new HasStageStartedQuery();

            foreach (var match in matches)
            {
                if (!hasStageStartedQuery.Execute(id, match.Stage))
                {
                    continue;
                }

                var overviewMatch = new OverviewMatch
                {
                    HomeTeamIsoCode = match.HomeTeamIsoCode,
                    AwayTeamIsoCode = match.AwayTeamIsoCode,
                    HomeScore = match.HomeScore,
                    AwayScore = match.AwayScore,
                    PenaltyWinner = match.PenaltyWinner,
                    HomeTeam = Teams.All.SingleOrDefault(x => x.IsoCode == match.HomeTeamIsoCode)?.Name,
                    AwayTeam = Teams.All.SingleOrDefault(x => x.IsoCode == match.AwayTeamIsoCode)?.Name
                };


                var bettingsForMatch = bettings[match.Id].OrderBy(x => x.UserName);

                foreach (var userName in result.UserNames)
                {
                    var overviewBetting = new OverviewBetting();

                    var betting = bettingsForMatch.SingleOrDefault(x => x.UserName == userName);
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

            if (betting.HasExactResultForMatch(match))
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