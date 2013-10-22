namespace ReportSpace.CustomerDashboard.Web
{
    using System.Web.Optimization;

    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(
                new StyleBundle("~/Content/css/css").Include(
                    "~/Content/css/responsive-tables.css",
                    "~/Content/css/prettify/prettify.css",
                    "~/Content/css/bootstrap.css",
                    "~/Content/css/bootstrap-responsive.css",
                    "~/Content/css/bootstrap-fileupload.css",
                    "~/Content/css/jquery.ui.css",
                    "~/Content/css/animate.min.css",
                    "~/Content/css/animate.delay.css",
                    "~/Content/css/isotope.css",
                    "~/Content/css/colorbox.css",
                    "~/Content/css/flexslider.css",
                    "~/Content/css/uniform.tp.css",
                    "~/Content/css/colorpicker.css",
                    "~/Content/css/jquery.jgrowl.css",
                    "~/Content/css/jquery.alerts.css",
                    "~/Content/css/jquery.tagsinput.css",
                    "~/Content/css/ui.spinner.css",
                    "~/Content/css/fullcalendar.css",
                    "~/Content/css/roboto.css",
                    "~/Content/css/lato.css",
                    "~/Content/css/font-awesome.min.css",
                    "~/Content/css/style.default.css",
                    "~/Content/css/toastr.css",
                    "~/Content/css/select2.css"));

            bundles.Add(new ScriptBundle("~/Content/js/jquery").Include(
                "~/Content/js/jquery-{version}.js",
                "~/Content/js/jquery-migrate-{version}.js",
                "~/Content/js/jquery-ui-{version}.js",
                "~/Content/js/jquery.cookie.js",
                "~/Content/js/jquery.uniform.min.js",
                "~/Scripts/jquery.unobtrusive-ajax*",
                "~/Scripts/jquery.validate*",
                "~/Scripts/jquery.validate.unobtrusive*",
                "~/Content/js/jquery.tagsinput.min.js",
                "~/Content/js/jquery.autogrow-textarea.js",
                "~/Content/js/flot/jquery.flot.min.js",
                "~/Content/js/flot/jquery.flot.resize.min.js"));

            bundles.Add(new ScriptBundle("~/Content/js/bootstrap").Include(
                "~/Content/js/bootstrap.js",
                "~/Content/js/bootstrap-fileupload.js",
                "~/Content/js/bootstrap-timepicker.min.js"));

            bundles.Add(new ScriptBundle("~/Content/js/modernizr").Include(
                "~/Scripts/modernizr-{version}.js"));

            bundles.Add(
                new ScriptBundle("~/Content/js/base").Include(
                    "~/Content/js/responsive-tables.js",
                    "~/Content/js/custom.js",
                    "~/Content/js/ui.spinner.min.js",
                    "~/Content/css/prettify/prettify.js",
                    "~/Content/js/elements.js",
                    "~/Scripts/select2.js",
                    "~/Scripts/toastr.js"));

            bundles.Add(new ScriptBundle("~/Content/local/reports").Include(
                "~/Scripts/local/reports.edit.js"));

            bundles.Add(new ScriptBundle("~/Content/local/admin").Include(
                "~/Scripts/local/admin.index.js",
                "~/Scripts/local/user.index.js",
                "~/Scripts/local/role.index.js"));
            /*
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
                        "~/Scripts/jquery-ui-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.unobtrusive*",
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

             */
        }
    }
}