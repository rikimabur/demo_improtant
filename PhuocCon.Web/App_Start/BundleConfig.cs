using PhuocCon.Common;
using System.Web;
using System.Web.Optimization;

namespace PhuocCon.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            //bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
            //            "~/Scripts/jquery-{version}.js"));

            //bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
            //            "~/Scripts/jquery.validate*"));

            //// Use the development version of Modernizr to develop with and learn from. Then, when you're
            //// ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            //bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
            //            "~/Scripts/modernizr-*"));

            //bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
            //          "~/Scripts/bootstrap.js",
            //          "~/Scripts/respond.js"));

            //bundles.Add(new StyleBundle("~/Content/css").Include(
            //          "~/Content/bootstrap.css",
            //          "~/Content/site.css"));
            bundles.Add(new ScriptBundle("~/js/jquery").Include("~/Assets/Client/js/jquery-3.1.1.min.js"));
            bundles.Add(new ScriptBundle("~/js/core").Include(
                "~/Assets/Admin/libs/jqueri-ui/jquery-ui.min.js",
                "~/Assets/Admin/libs/mustache/mustache.js",
                "~/Assets/Admin/libs/numeral/numeral.js",
                "~/Assets/Admin/libs/jquery-validation/dist/jquery.validate.js",
                "~/Assets/Client/js/common.js"
                //"~/Assets/Client/js/controllers/ShoppingCart.js"
                ));

            bundles.Add(new StyleBundle("~/css/base")
                .Include("~/Assets/Client/css/bootstrap.css", new CssRewriteUrlTransform())
                .Include("~/Assets/Admin/libs/jqueri-ui/themes/smoothness/jquery-ui.min.css", new CssRewriteUrlTransform())
                .Include("~/Assets/Client/libs/font-awesome/css/font-awesome.min.css", new CssRewriteUrlTransform())
                .Include("~/Assets/Client/css/style.css", new CssRewriteUrlTransform())
                .Include("~/Assets/client/css/custom.css", new CssRewriteUrlTransform())
                );
            BundleTable.EnableOptimizations =bool.Parse(ConfigHelper.GetByKey("EnableBundles"));
        }
    }
}
