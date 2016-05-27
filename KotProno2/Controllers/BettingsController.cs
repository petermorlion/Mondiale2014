using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using KotProno2.EntityFramework;
using KotProno2.Models;

namespace KotProno2.Controllers
{
    public class BettingsController : ApiController
    {
        private readonly MatchesContext _contextProvider = new MatchesContext();

        [HttpGet]
        [Authorize]
        public IList<Betting> Get()
        {
            return _contextProvider.Context.Bettings.Where(x => x.UserName == User.Identity.Name).ToList();
        }

        [HttpPost]
        [Authorize]
        public void Post(object data)
        {
            var command = new AddBettingsCommand
            {
                DateTime = DateTime.Now,
                Name = "AddBettings",
                Data = data.ToString(),
                UserName = User.Identity.Name,
            };

            command.Execute(_contextProvider.Context);
            _contextProvider.Context.Commands.Add(command);
            _contextProvider.Context.SaveChangesAsync();
        }
    }
}