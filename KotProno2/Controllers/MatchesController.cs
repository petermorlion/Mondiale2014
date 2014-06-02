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
        public string Metadata()
        {
            return _contextProvider.Metadata();
        }

        // ~/breeze/matches/Matches
        // ~/breeze/matches/Matches?$filter=HomeTeamId eq 1
        [HttpGet]
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
            return _contextProvider.Context.Bettings.Where(x => x.UserName == User.Identity.Name).AsQueryable<Betting>();
        }

        // ~/breeze/matches/SaveChanges
        [HttpGet]
        public SaveResult SaveChanges(JObject saveBundle)
        {
            return _contextProvider.SaveChanges(saveBundle);
        }

        [HttpPost]
        [Authorize]
        public void AddBettings(object data)
        {
            var command = new AddBettingsCommand
            {
                DateTime = DateTime.Now,
                Name = "AddBettings",
                Data = data,
                UserName = User.Identity.Name
            };

            command.Execute(_contextProvider.Context);
            _contextProvider.Context.Commands.Add(command);
            _contextProvider.Context.SaveChangesAsync();
        }

        [HttpGet]
        [Authorize]
        public MatchDetails MatchDetails(int matchId)
        {
            var match = _contextProvider.Context.Matches.Single(x => x.Id == matchId);
            var bettings = _contextProvider.Context.Bettings.Where(x => x.MatchId == matchId);

            return new MatchDetails
            {
                Id = match.Id,
                HomeTeamIsoCode = match.HomeTeamIsoCode,
                AwayTeamIsoCode = match.AwayTeamIsoCode,
                DateTime = match.DateTime,
                Bettings = bettings.ToList()
            };
        }
    }
}