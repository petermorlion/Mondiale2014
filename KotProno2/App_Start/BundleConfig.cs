using System.Web;
using System.Web.Optimization;

namespace KotProno2
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            // TODO: a scriptbundle would be better but the minification is breaking angular
            bundles.Add(new Bundle("~/bundles/angular").Include(
                      "~/Scripts/angular-ui-router.js",
                      "~/Scripts/app/app.js",
                      "~/Scripts/app/config.js",
                      "~/Scripts/app/config.route.js",
                      "~/Scripts/app/preventTemplateCache.js",
                      "~/Scripts/app/alertr.js",
                      "~/Scripts/app/games/games.js",
                      "~/Scripts/app/admin/admin.js",
                      "~/Scripts/app/points/points.js",
                      "~/Scripts/app/tournaments/tournaments.js",
                      "~/Scripts/app/tournament/tournament.js",
                      "~/Scripts/app/statistics/statistics.js",
                      "~/Scripts/app/overview/overview.js",
                      "~/Scripts/app/nav.js",
                      "~/Scripts/app/directives/loadingPanel.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/site.css",
                      "~/Content/flags/common.css",
                      "~/Content/flags/flags32.css",
                      "~/Content/flags/flags24.css"));

            BundleTable.EnableOptimizations = true;
        }
    }
}
