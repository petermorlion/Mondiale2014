using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using KotProno2.EntityFramework;
using KotProno2.Models;

namespace KotProno2.Controllers
{
    public class MatchController : ApiController
    {
        private readonly MatchesDbContext _context;

        public MatchController(MatchesDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IList<Match> Get(int id)
        {
            var matches = _context.Matches.Where(x => x.TournamentId == id).OrderBy(x => x.DateTime).ToList();

            return matches;
        }
    }
}