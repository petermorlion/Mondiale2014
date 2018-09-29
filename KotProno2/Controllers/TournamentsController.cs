using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using KotProno2.Models;
using KotProno2.EntityFramework;

namespace KotProno2.Controllers
{
    public class TournamentsController : ApiController
    {
        private readonly MatchesDbContext _context;

        public TournamentsController(MatchesDbContext context)
        {
            _context = context;
        }

        // ~/api/tournaments
        [HttpGet]
        public IList<Tournament> Get()
        {
            var tournaments = _context.Tournaments.OrderByDescending(x => x.Id).ToList();

            return tournaments;
        }

        // ~/api/tournaments/id
        [HttpGet]
        public Tournament Get(int id)
        {
            var tournament = _context.Tournaments.SingleOrDefault(x => x.Id == id);

            return tournament;
        }
    }
}
