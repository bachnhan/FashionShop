using System.Web;
using System.Web.Optimization;

namespace FashionShopAdmin
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("color-admin-styles")
                .Include("~/Content/admin/assets/plugins/jquery-ui/jquery-ui.min.css")
                .Include("~/Content/admin/assets/plugins/bootstrap/4.1.0/css/bootstrap.min.css")
                .Include("~/Content/admin/assets/plugins/font-awesome/css/fontawesome.min.css")
                .Include("~/Content/admin/assets/plugins/animate/animate.min.css")
                .Include("~/Content/admin/assets/css/default/style.min.css")
                .Include("~/Content/admin/assets/css/default/style-responsive.min.css")

                .Include("~/Content/admin/assets/css/default/invoice-print.min.css")
                .Include("~/Content/admin/assets/css/default/theme/default.css")
                );

            bundles.Add(new StyleBundle("color-admin-scripts")
                .Include("~/Content/admin/assets/plugins/jquery/jquery-3.2.1.min.js")
                .Include("~/Content/admin/assets/plugins/jquery-ui/jquery-ui.min.js")
                .Include("~/Content/admin/assets/plugins/bootstrap/4.1.0/js/bootstrap.bundle.min.js")
                .Include("~/Content/admin/assets/plugins/slimscroll/jquery.slimscroll.min.js")
                .Include("~/Content/admin/assets/plugins/js-cookie/js.cookie.js")
                .Include("~/Content/admin/assets/plugins/font-awesome/js/fontawesome.min.js")
                .Include("~/Content/admin/assets/js/theme/default.min.js")
                .Include("~/Content/admin/assets/js/apps.min.js")
                .Include("~/Content/admin/assets/plugins/fullcalendar/lib/moment.min.js")
                .Include("~/Content/admin/assets/plugins/fullcalendar/fullcalendar.min.js")
                .Include("~/Content/admin/assets/js/demo/calendar.demo.min.js")
                //.Include("~/Content/admin")
                );

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));
        }
    }
}
