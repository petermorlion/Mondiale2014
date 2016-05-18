using System.Web;
using System.Web.Optimization;

namespace KotProno2
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            // TODO: a scriptbundle would be better but the minification is breaking angular
            bundles.Add(new Bundle("~/bundles/angular").Include(
                      "~/Scripts/angular.js",
                      "~/Scripts/angular-animate.js",
                      "~/Scripts/angular-route.js",
                      "~/Scripts/angular-sanitize.js",
                      "~/Scripts/breeze.debug.js",
                      "~/Scripts/breeze.angular.js",
                      "~/Scripts/app/app.js",
                      "~/Scripts/app/config.js",
                      "~/Scripts/app/config.route.js",
                      "~/Scripts/app/main.js",
                      "~/Scripts/app/games/games.js",
                      "~/Scripts/app/admin/admin.js",
                      "~/Scripts/app/main/points.js",
                      "~/Scripts/app/tournaments/tournaments.js",
                      "~/Scripts/app/statistics/statistics.js",
                      "~/Scripts/app/overview/overview.js",
                      "~/Scripts/highcharts/highcharts.js",
                      "~/Scripts/toastr.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css",
                      "~/Content/flags/common.css",
                      "~/Content/flags/flags48.css",
                      "~/Content/flags/flags24.css",
                      "~/Content/toastr.css"));
        }
    }
}
