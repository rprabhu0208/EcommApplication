using System.Web;
using System.Web.Optimization;

namespace ECommApplication
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


            bundles.Add(new StyleBundle("~/Content/adminlayout/css").Include(
                      "~/Content/adminlayout/css/bootstrap.min.css",
                      "~/Content/adminlayout/css/bootstrap-responsive.min.css",
                      "~/Content/adminlayout/css/colorpicker.css",
                      "~/Content/adminlayout/css/datepicker.css",
                      "~/Content/adminlayout/css/uniform.css",
                      "~/Content/adminlayout/css/select2.css",
                      "~/Content/adminlayout/css/matrix-style.css",
                      "~/Content/adminlayout/css/matrix-media.css",
                      "~/Content/adminlayout/css/bootstrap-wysihtml5.css",
                      "~/Content/adminlayout/font-awesome/css/font-awesome.css",
                      "~/Content/adminlayout/css/fontsgoogleapiscss.css" 
                      ));

            bundles.Add(new ScriptBundle("~/bundles/adminlayout/js").Include(
                        "~/Content/adminlayout/js/jquery.min.js",
                       // "~/Content/adminlayout/js/jquery.dataTables.min.js",
                        //"~/Content/adminlayout/js/jquery.ui.custom.js",
                        "~/Content/adminlayout/js/bootstrap.min.js",
                        "~/Content/adminlayout/js/bootstrap-colorpicker.js",
                        "~/Content/adminlayout/js/bootstrap-datepicker.js",
                        "~/Content/adminlayout/js/jquery.toggle.buttons.js",
                        "~/Content/adminlayout/js/masked.js",

                        "~/Content/adminlayout/js/jquery.uniform.js",
                        "~/Content/adminlayout/js/select2.min.js",
                        //"~/Content/adminlayout/js/matrix.js",
                        //"~/Content/adminlayout/js/matrix.form_common.js",
                        "~/Content/adminlayout/js/wysihtml5-0.3.0.js",
                        //"~/Content/adminlayout/js/jquery.peity.min.js",
                        "~/Content/adminlayout/js/bootstrap-wysihtml5.js"
                        ));
            

        }
    }
}
