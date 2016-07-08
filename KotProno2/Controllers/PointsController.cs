using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using KotProno2.EntityFramework;
using KotProno2.Models;

namespace KotProno2.Controllers
{
    public class PointsController : ApiController
    {
        private readonly MatchesContext _matchesContext = new MatchesContext();

        [HttpGet]
        public IList<Points> Get(int id)
        {
            var result = new List<Points>();
            var bettings = _matchesContext.Context.Bettings.Where(x => x.Match.TournamentId == id).ToList();
            var matches = _matchesContext.Context.Matches.Where(x => x.TournamentId == id).ToList();
            var users = new ApplicationDbContext().Users.ToList();
            var usersWithCorrectTopScorer = _matchesContext.Context.TopScorers.Where(x => x.TournamentId == id && x.IsCorrect).Select(x => x.UserName).ToList();

            foreach (var user in users)
            {
                var points = new Points { UserName = user.UserName };

                if (usersWithCorrectTopScorer.Contains(user.UserName))
                {
                    points.Total += 2;
                }

                result.Add(points);
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

                    if (bettingForMatch.HomeScore == match.HomeScore && bettingForMatch.AwayScore == match.AwayScore)
                    {
                        points.Total += 2;
                    }
                    else if (BettingHasCorrectResult(bettingForMatch, match))
                    {
                        points.Total += 1;
                    }
                }
            }

            return result;
        }

        private bool BettingHasCorrectResult(Betting bettingForMatch, Match match)
        {
            var bettingResult = bettingForMatch.GetMatchResult();
            var realResult = match.GetMatchResult();
            return bettingResult == realResult;
        }
    }
}