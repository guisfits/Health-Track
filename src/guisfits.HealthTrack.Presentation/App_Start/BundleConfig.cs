using System.Web.Optimization;
using guisfits.HealthTrack.Presentation.Helpers;

namespace guisfits.HealthTrack.Presentation
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.IgnoreList.Clear();

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

            bundles.Add(new ScriptBundle("~/bundles/Main").Include(
                "~/Scripts/Main.js"));

            //CSS
            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/wwwroot/lib/font-awesome/css/font-awesome.css",
                "~/wwwroot/lib/bootswatch/paper/bootstrap.css",
                "~/Content/Site.css"));

            var bundle = new ScriptBundle("~/bundles/jqueryval") { Orderer = new AsIsBundleOrderer() };

            bundle
                .Include("~/Scripts/jquery.validate-vsdoc.js")
                .Include("~/Scripts/jquery.validate.js")
                .Include("~/Scripts/jquery.validate.unobtrusive.js")
                .Include("~/Scripts/globalize/globalize.js")
                .Include("~/Scripts/jquery.validate.globalize.js");
            bundles.Add(bundle);
        }
    }
}
