using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using KotProno2.EntityFramework;
using KotProno2.Models;

namespace KotProno2.Controllers
{
    public class TopScorersController : ApiController
    {
        private readonly MatchesDbContext _context;

        public TopScorersController(MatchesDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Authorize]
        public IList<TopScorer> TopScorer(int id)
        {
            return _context.TopScorers.Where(x => x.TournamentId == id).ToList();
        }
    }
}