using System;
using System.Web.Http;
using KotProno2.EntityFramework;
using KotProno2.Models;

namespace KotProno2.Controllers
{
    public class ScoresController : ApiController
    {
        private readonly MatchesDbContext _context;

        public ScoresController(MatchesDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        [Authorize]
        public void Post(object data)
        {
            // TODO: use roles
            if (User.Identity.Name != "petermorlion")
            {
                return;
            }

            var command = new AddScoresCommand
            {
                DateTime = DateTime.Now,
                Name = "AddScores",
                Data = data.ToString(),
                UserName = User.Identity.Name,
            };

            command.Execute(_context);
            _context.Commands.Add(command);
            _context.SaveChangesAsync();
        }
    }
}