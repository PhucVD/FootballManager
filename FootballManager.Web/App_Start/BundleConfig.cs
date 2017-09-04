using System.Web;
using System.Web.Optimization;

namespace FootballManager.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/jquery.unobtrusive-ajax.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                        "~/Scripts/bootstrap.js",
                        "~/Scripts/bootstrap-confirmation.js",
                        "~/Scripts/respond.js"));

            bundles.Add(new ScriptBundle("~/bundles/lib").Include(
                        "~/Scripts/moment.js",
                        "~/Scripts/jquery.bootstrap-growl.js",
                        "~/Scripts/bootstrap-select.js",
                        "~/Scripts/bootstrap-editable.js",
                        "~/Scripts/bootstrap-datetimepicker.js"));

            bundles.Add(new ScriptBundle("~/bundles/app").Include(
                        "~/Scripts/Application/datetimepicker.js",
                        "~/Scripts/Application/modal.js",
                        "~/Scripts/Application/xeditable.js",
                        "~/Scripts/Application/notification.js",
                        "~/Scripts/Application/ajax-button.js",
                        "~/Scripts/Application/app.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                        "~/Content/bootstrap.css",
                        "~/Content/bootstrap-select.css",
                        "~/Content/bootstrap-editable.css",
                        "~/Content/bootstrap-datetimepicker.css",
                        "~/Content/site.css"));
        }
    }
}
