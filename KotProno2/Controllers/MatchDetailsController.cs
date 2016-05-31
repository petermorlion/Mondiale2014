using System.Linq;
using System.Web.Http;
using KotProno2.EntityFramework;
using KotProno2.Models;

namespace KotProno2.Controllers
{
    public class MatchDetailsController : ApiController
    {
        private readonly MatchesContext _contextProvider = new MatchesContext();

        /// <param name="id">The match id</param>
        [HttpGet]
        [Authorize]
        public MatchDetails MatchDetails(int id)
        {
            var match = _contextProvider.Context.Matches.Single(x => x.Id == id);
            var bettings = _contextProvider.Context.Bettings.Where(x => x.MatchId == id);

            return new MatchDetails
            {
                Id = match.Id,
                HomeTeamName = Teams.All.Single(x => x.IsoCode == match.HomeTeamIsoCode).Name,
                AwayTeamName = Teams.All.Single(x => x.IsoCode == match.AwayTeamIsoCode).Name,
                DateTime = match.DateTime,
                Bettings = bettings.ToList()
            };
        }
    }
}