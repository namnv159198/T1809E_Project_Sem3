using System.Web;
using System.Web.Optimization;

namespace T1809E_Project_Sem3
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
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

            // Admin template
            // file css
            bundles.Add(new StyleBundle("~/AdminTemplateContent/css").Include(
                "~/AdminTemplate/js/iCheck/skins/minimal/minimal.css",
                "~/AdminTemplate/js/iCheck/skins/square/square.css",
                "~/AdminTemplate/js/iCheck/skins/square/red.css",
                "~/AdminTemplate/js/iCheck/skins/square/blue.css",
                "~/AdminTemplate/css/clndr.css",
                "~/AdminTemplate/css/style.css",
                "~/AdminTemplate/css/style-responsive.css"));

            // file js
            bundles.Add(new ScriptBundle("~/AdminTemplateContent/js").Include(
                "~/AdminTemplate/js/jquery-1.10.2.min.js",
                "~/AdminTemplate/js/jquery-ui-1.9.2.custom.min.js",
                "~/AdminTemplate/js/jquery-migrate-1.2.1.min.js",
                "~/AdminTemplate/js/bootstrap.min.js",
                "~/AdminTemplate/js/modernizr.min.js",
                "~/AdminTemplate/js/jquery.nicescroll.js",
                "~/AdminTemplate/js/easypiechart/jquery.easypiechart.js",
                "~/AdminTemplate/js/easypiechart/easypiechart-init.js",
                "~/AdminTemplate/js/sparkline/jquery.sparkline.js",
                "~/AdminTemplate/js/sparkline/sparkline-init.js",
                "~/AdminTemplate/js/iCheck/jquery.icheck.js",
                "~/AdminTemplate/js/icheck-init.js",
                "~/AdminTemplate/js/flot-chart/jquery.flot.js",
                "~/AdminTemplate/js/flot-chart/jquery.flot.tooltip.js",
                "~/AdminTemplate/js/flot-chart/jquery.flot.resize.js",
                "~/AdminTemplate/js/flot-chart/jquery.flot.pie.resize.js",
                "~/AdminTemplate/js/flot-chart/jquery.flot.selection.js",
                "~/AdminTemplate/js/flot-chart/jquery.flot.stack.js",
                "~/AdminTemplate/js/flot-chart/jquery.flot.time.js",
                "~/AdminTemplate/js/main-chart.js",
                "~/AdminTemplate/js/scripts.js"));
        }
    }
}
