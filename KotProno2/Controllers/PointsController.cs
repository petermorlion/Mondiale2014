using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using KotProno2.EntityFramework;
using KotProno2.Models;

namespace KotProno2.Controllers
{
    public class PointsController : ApiController
    {
        private readonly MatchesDbContext _context;

        public PointsController(MatchesDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IList<Points> Get(int id)
        {
            var result = new List<Points>();
            var bettings = _context.Bettings.Where(x => x.Match.TournamentId == id).ToList();
            var matches = _context.Matches.Where(x => x.TournamentId == id).ToList();
            var users = new ApplicationDbContext().Users.ToList();
            var usersWithCorrectTopScorer = _context.TopScorers.Where(x => x.TournamentId == id && x.IsCorrect).Select(x => x.UserName).ToList();

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

                    points.Total += bettingForMatch.GetUserScoreForMatch(match);
                }
            }

            return result;
        }
    }
}