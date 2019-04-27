using System.Web;
using System.Web.Optimization;

namespace BrandBook.Web
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




            /*
             *
             * Styles
             * Frontend
             *
             */

            // Bundles for Frontend
            bundles.Add(new StyleBundle("~/Content/Css/Frontend/Main").Include(
                        "~/Content/bootstrap.min.css",
                        "~/Content/Frontend/Styles.min.css"));

            bundles.Add(new StyleBundle("~/Content/Frontend/Plugins").Include(
                        "~/Plugins/owl-carousel/owl.carousel.css",
                        "~/Plugins/owl-carousel/owl.carousel.css",
                        "~/Plugins/owl-carousel/owl.theme.css",
                        "~/Plugins/aos-next/dist/aos.css",
                        "~/Plugins/language-switcher/polyglot-language-switcher.css",
                        "~/Plugins/fancybox/dist/jquery.fancybox.min.css",
                        "~/Plugins/roadmap/jquery.roadmap.min.css"));


            

            bundles.Add(new StyleBundle("~/Content/Css/Frontend/Styling/01").Include(
                        "~/Content/Frontend/ColorStyle01.css"));

            bundles.Add(new StyleBundle("~/Content/Css/Frontend/Styling/02").Include(
                        "~/Content/Frontend/ColorStyle02.css"));

            bundles.Add(new StyleBundle("~/Content/Css/Frontend/Styling/03").Include(
                        "~/Content/Frontend/ColorStyle03.css"));


            // Main Js File for Sales Frontend
            bundles.Add(new ScriptBundle("~/bundles/Frontend/Main").Include(
                        "~/Scripts/Custom/theme.js"));

            // Plugins for Sales Frontend
            bundles.Add(new ScriptBundle("~/bundles/Frontend/Plugins").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Plugins/popper.js/popper.min.js",
                        "~/Scripts/bootstrap.min.js",
                        "~/Plugins/jquery-easing/jquery.easing.min.js",
                        "~/Plugins/language-switcher/jquery.polyglot.language.switcher.js",
                        "~/Plugins/jquery.appear.js",
                        "~/Plugins/jquery.countTo.js",
                        "~/Plugins/fancybox/dist/jquery.fancybox.min.js",
                        "~/Plugins/owl-carousel/owl.carousel.min.js",
                        "~/Plugins/aos-next/dist/aos.js",
                        "~/Plugins/roadmap/jquery.roadmap.js"));





            /*
             *
             * Styles
             * Auth
             *
             */

            bundles.Add(new StyleBundle("~/Content/Css/Auth/Main").Include(
                        "~/Content/Auth/Styles.min.css"));



        }
    }
}
