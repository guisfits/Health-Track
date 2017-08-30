
using System.Web.Optimization;

namespace guisfits.HealthTrack.Presentation
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                "~/Scripts/bootstrap.js",
                "~/Scripts/respond.js"));

            bundles.Add(new ScriptBundle("~/bundles/Site").Include(
                "~/Scripts/effects.js"));

            //CSS
            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/wwwroot/lib/font-awesome/css/font-awesome.css",
                "~/wwwroot/lib/bootswatch/paper/bootstrap.css",
                //"~/Content/carousel.css",
                "~/Content/Site.css"));
                       
        }
    }
}
