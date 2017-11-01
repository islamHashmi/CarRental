using System.Web.Optimization;

namespace AjinkyaCarRental.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/Scripts/jquery").Include(
                   "~/Scripts/jquery-{version}.js",
                   "~/Scripts/jquery.*",
                   "~/Scripts/jquery-ui-{version}.js"));
            
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",                      
                      "~/Scripts/moment.js",
                      "~/Scripts/bootstrap-datetimepicker.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/jquery-ui.css",
                      "~/Content/bootstrap-simplex.css",
                      "~/Content/Site.css"));

            bundles.Add(new StyleBundle("~/Content/login").Include(
                     "~/Content/bootstrap-simplex.css",
                     "~/Content/login-style.css"));
        }
    }
}