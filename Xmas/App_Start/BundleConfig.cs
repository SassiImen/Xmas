using System.Web;
using System.Web.Optimization;

namespace Xmas
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            //Initials Bundles
            //bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
            //            "~/Scripts/jquery-{version}.js"));

            //bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
            //            "~/Scripts/jquery.validate*"));

            //// Use the development version of Modernizr to develop with and learn from. Then, when you're
            //// ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            //bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
            //            "~/Scripts/modernizr-*"));

            //bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
            //          "~/Scripts/bootstrap.js"));

            //bundles.Add(new StyleBundle("~/Content/css").Include(
            //          "~/Content/bootstrap.css",
            //          "~/Content/site.css"));


            /*Thème bundles*/
            bundles.Add(new StyleBundle("~/Content/XmasTheme")
                .Include("~/css/bootstrap.css", 
                "~/css/style.css",
                "~/css/dscountdown.css",
                "~/css/animate.css",
                "~/css/font-awesome.css",
                "~/css/lightbox.css",
                "~/css/cm-overlay.css"
                 ));

            bundles.Add(new ScriptBundle("~/Scripts/Load")
                .Include("~/js/Load.js"));

            bundles.Add(new ScriptBundle("~/bundles/Jquery").Include
                (
                "~/js/jquery-2.2.3.min.js"
                ));

            bundles.Add(new ScriptBundle("~/Scripts/Scroll")
                .Include(
                "~/js/move-top.js",
                "~/js/easing.js",
                "~/js/AnimateScroll.js"));

            bundles.Add(new ScriptBundle("~/Scripts/SmoothScrolling")
                .Include(
                "~/js/SmoothScrolling.js",
                "~/js/SmoothScroll.min.js"));
            bundles.Add(new ScriptBundle("~/Scripts/scrollingNav")
                .Include(
                "~/js/scrolling-nav.js",
                "~/js/jquery.vide.js"
                ));
            bundles.Add(new ScriptBundle("~/bundles/Boostrap")
               .Include("~/js/bootstrap.js"));

            bundles.Add(new ScriptBundle("~/Scripts/Gallery")
                .Include
                (
                     "~/js/jquery.tools.min.js",
                     "~/js/jquery.mobile.custom.min.js",
                     "~/js/jquery.cm-overlay.js",
                     "~/js/CmOverlay.js"
                ));

            bundles.Add(new ScriptBundle("~/Scripts/Counter")
                .Include(
                "~/js/dscountdown.min.js",
                "~/js/EventCountDown.js"
                )
                );

        }
    }
}
