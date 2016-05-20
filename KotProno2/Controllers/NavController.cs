using System.Web.Mvc;

namespace KotProno2.Controllers
{
    public class NavController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult TournamentNav()
        {
            return View();
        }
    }
}
