using System.Linq;
using System.Web.Http;
using KotProno2.EntityFramework;
using KotProno2.Models;

namespace KotProno2.Controllers
{
    public class TopScorerController : ApiController
    {
        private readonly MatchesDbContext _context;

        public TopScorerController(MatchesDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Authorize]
        public TopScorer TopScorer(int id)
        {
            return _context.TopScorers.SingleOrDefault(x => x.UserName == User.Identity.Name && x.TournamentId == id);
        }
    }
}