using System.Linq;
using System.Web.Http;
using KotProno2.EntityFramework;
using KotProno2.Models;

namespace KotProno2.Controllers
{
    public class TopScorerController : ApiController
    {
        private readonly MatchesContext _contextProvider = new MatchesContext();

        [HttpGet]
        [Authorize]
        public TopScorer TopScorer()
        {
            return _contextProvider.Context.TopScorers.SingleOrDefault(x => x.UserName == User.Identity.Name);
        }
    }
}