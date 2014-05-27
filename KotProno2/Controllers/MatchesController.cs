using Breeze.ContextProvider;
using Breeze.WebApi2;
using KotProno2.EntityFramework;
using KotProno2.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace KotProno2.Controllers
{
    [BreezeController]
    public class MatchesController : ApiController
    {
        // TODO: Use repo and DI?
        private readonly MatchesContext _contextProvider = new MatchesContext();

        [HttpGet]
        [Authorize]
        public string Metadata()
        {
            return _contextProvider.Metadata();
        }

        // ~/breeze/matches/Matches
        // ~/breeze/matches/Matches?$filter=HomeTeamId eq 1
        [HttpGet]
        [Authorize]
        public IQueryable<Match> Matches()
        {
            return _contextProvider.Context.Matches;
        }

        // ~/breeze/matches/Bettings
        // ~/breeze/matches/Bettings?$filter=HomeTeamId eq 1
        [HttpGet]
        [Authorize]
        public IQueryable<Betting> Bettings()
        {
            //TODO: use DB
            return new[] 
            {
                new Betting { MatchId = 1, HomeScore = 1, AwayScore = 2 },
                new Betting { MatchId = 2, HomeScore = 1, AwayScore = 0 },
                new Betting { MatchId = 3, HomeScore = 0, AwayScore = 2 },
            }.AsQueryable();
        }

        // ~/breeze/matches/SaveChanges
        [HttpGet]
        public SaveResult SaveChanges(JObject saveBundle)
        {
            return _contextProvider.SaveChanges(saveBundle);
        }
    }
}