using System;
using System.Threading.Tasks;
using System.Web.Http;
using KotProno2.EntityFramework;
using KotProno2.Models.Commands;

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
        public async Task Post(object data)
        {
            if (!User.IsInRole("Admin"))
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
            await _context.SaveChangesAsync();
        }
    }
}