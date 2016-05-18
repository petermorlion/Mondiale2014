using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using KotProno2.Models;
using KotProno2.EntityFramework;

namespace KotProno2.Controllers
{
    public class TournamentsController : ApiController
    {
        private readonly MatchesContext _contextProvider = new MatchesContext();

        // ~/api/tournaments
        [HttpGet]
        public IList<Tournament> Get()
        {
            var tournaments = _contextProvider.Context.Tournaments.ToList();

            return tournaments;
        }

        // ~/api/tournaments/id
        [HttpGet]
        public Tournament Get(int id)
        {
            var tournament = _contextProvider.Context.Tournaments.SingleOrDefault(x => x.Id == id);

            return tournament;
        }
    }
}
