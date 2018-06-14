using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using KotProno2.EntityFramework;
using KotProno2.Models;

namespace KotProno2.Controllers
{
    public class MatchController : ApiController
    {
        private readonly MatchesContext _matchesContext = new MatchesContext();

        [HttpGet]
        public IList<Match> Get(int id)
        {
            var matches = _matchesContext.Context.Matches.Where(x => x.TournamentId == id).OrderBy(x => x.DateTime).ToList();

            return matches;
        }
    }
}