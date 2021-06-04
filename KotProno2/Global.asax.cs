using KotProno2.EntityFramework;
using KotProno2.Migrations;
using KotProno2.Models;
using System.Data.Entity;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace KotProno2
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            Database.SetInitializer<MatchesDbContext>(new MigrateDatabaseToLatestVersion<MatchesDbContext, Configuration>());
            Database.SetInitializer<ApplicationDbContext>(null);

            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected void Application_Error()
        {
            var e = Server.GetLastError();
        }

        protected void Application_End()
        {
#if DEBUG
#else
            Startup.TelemetryClient.Flush();
#endif
        }
    }
}
