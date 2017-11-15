using System.Web.Optimization;

namespace HealthTrack.MVC
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            //JS
            bundles.Add(new ScriptBundle("~/bundles/app").Include(
                        "~/www/scripts/jquery-{version}.js",
                        "~/www/scripts/bootstrap.js",
                        "~/www/scripts/efeitos-logo.js",
                        "~/www/scripts/respond.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/www/scripts/jquery.validate*",
                        "~/www/scripts/validation-override.js"));

            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/www/scripts/modernizr-*"));

            //CSS
            bundles.Add(new StyleBundle("~/styles").Include(
                      "~/www/css/bootstrap.css",
                      "~/www/css/bootstrap-overrides.css",
                      "~/www/lib/font-awesome/css/font-awesome.css",
                      "~/www/css/site.css"));
        }
    }
}
