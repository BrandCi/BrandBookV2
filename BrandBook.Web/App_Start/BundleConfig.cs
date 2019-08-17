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


            bundles.Add(new StyleBundle("~/Content/Css/Flag-Icon").Include(
                        "~/Content/Flag-Icon/flag-icon.min.css"));



            /*
             *
             * Styles
             * Frontend
             *
             */

            // Bundles for Frontend
            bundles.Add(new StyleBundle("~/Content/Css/Frontend/Main").Include(
                        "~/Content/bootstrap.min.css",
                        "~/Content/Frontend/Plugins/themify-icon/themify-icons.css",
                        "~/Content/Frontend/Plugins/flaticon/flaticon.css",
                        "~/Content/Frontend/Plugins/animation/animate.css",
                        "~/Content/Frontend/Plugins/owl-carousel/assets/owl.carousel.min.css",
                        "~/Content/Frontend/Plugins/magnify-pop/magnific-popup.css",
                        "~/Content/Frontend/Plugins/elagent/style.css",
                        "~/Content/Frontend/Plugins/scroll/jquery.mCustomScrollbar.min.css",

                        "~/Content/Frontend/style.min.css",
                        "~/Content/Frontend/responsive.css"));





            bundles.Add(new StyleBundle("~/Content/Frontend/Plugins").Include(
                        "~/Plugins/owl-carousel/owl.carousel.css",
                        "~/Plugins/owl-carousel/owl.carousel.css",
                        "~/Plugins/owl-carousel/owl.theme.css",
                        "~/Plugins/aos-next/dist/aos.css",
                        "~/Plugins/language-switcher/polyglot-language-switcher.css",
                        "~/Plugins/fancybox/dist/jquery.fancybox.min.css",
                        "~/Plugins/roadmap/jquery.roadmap.min.css"));


            


            





            /*
             *
             * Styles
             * Auth
             *
             */

            bundles.Add(new StyleBundle("~/Content/Css/Auth/Main").Include(
                        "~/Content/bootstrap.min.css",
                        "~/Content/Auth/Styles.min.css"));





            /*
             *
             * Styles
             * App
             *
             */
            bundles.Add(new StyleBundle("~/Content/Css/App/Main").Include(
                "~/Plugins/switchery/switchery.min.css",
                "~/Content/bootstrap.min.css",
                "~/Content/App/style.min.css"));


            bundles.Add(new ScriptBundle("~/bundles/App/Main").Include(
                "~/Scripts/jquery-{version}.js",
                "~/Scripts/App/Main/popper.min.js",
                "~/Scripts/bootstrap.min.js",
                "~/Scripts/App/Main/detect.js",
                "~/Scripts/App/Main/fastclick.js",
                "~/Scripts/App/Main/jquery.slimscroll.js",
                "~/Scripts/App/Main/jquery.blockUI.js",
                "~/Scripts/App/Main/waves.js",
                "~/Scripts/App/Main/wow.min.js",
                "~/Scripts/App/Main/jquery.nicescroll.js",
                "~/Scripts/App/Main/jquery.scrollTo.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/App/Core").Include(
                "~/Scripts/App/jquery.core.js",
                "~/Scripts/App/jquery.app.js"));










            /*
             *
             *  Plugins
             *
             */


            // Jquery.Validation
            bundles.Add(new ScriptBundle("~/bundles/Plugins/JqueryValidation").Include(
                "~/Plugins/jquery-validation/js/jquery.validate.min.js"
                ));

            // Modals
            bundles.Add(new StyleBundle("~/Content/Plugins/Modals").Include(
                    "~/Plugins/custombox/dist/custombox.min.css",
                    "~/Plugins/morris/morris.css"));

            bundles.Add(new ScriptBundle("~/bundles/Plugins/Modals").Include(
                "~/Plugins/custombox/dist/custombox.min.js",
                "~/Plugins/custombox/dist/legacy.min.js"));



            // Morris Chart
            bundles.Add(new StyleBundle("~/Content/Plugins/MorrisChart").Include(
                "~/Plugins/morris/morris.css"));
            
            bundles.Add(new ScriptBundle("~/bundles/Plugins/MorrisChart").Include(
                "~/Plugins/morris/morris.min.js",
                "~/Plugins/raphael/raphael-min.js"));


            // Datatables
            bundles.Add(new StyleBundle("~/Content/Plugins/Datatables").Include(
                "~/Plugins/datatables/dataTables.bootstrap4.min.css",
                "~/Plugins/datatables/buttons.bootstrap4.min.css",
                "~/Plugins/datatables/responsive.bootstrap4.min.css"));

            bundles.Add(new ScriptBundle("~/bundles/Plugins/Datatables").Include(
                "~/Plugins/datatables/jquery.dataTables.min.js",
                "~/Plugins/datatables/dataTables.bootstrap4.min.js",
                "~/Plugins/datatables/dataTables.buttons.min.js",
                "~/Plugins/datatables/buttons.bootstrap4.min.js",
                "~/Plugins/datatables/jszip.min.js",
                "~/Plugins/datatables/pdfmake.min.js",
                "~/Plugins/datatables/vfs_fonts.js",
                "~/Plugins/datatables/buttons.html5.min.js",
                "~/Plugins/datatables/buttons.print.min.js",
                "~/Plugins/datatables/dataTables.keyTable.min.js",
                "~/Plugins/datatables/dataTables.responsive.min.js",
                "~/Plugins/datatables/responsive.bootstrap4.min.js",
                "~/Plugins/datatables/dataTables.select.min.js"));


            // Jquery.Steps
            bundles.Add(new StyleBundle("~/Content/Plugins/JquerySteps").Include(
                "~/Plugins/jquery.steps/css/jquery.steps.css"));

            bundles.Add(new ScriptBundle("~/bundles/Plugins/JquerySteps").Include(
                "~/Plugins/jquery.steps/js/jquery.steps.min.js"));



            // Sweet Alerts
            bundles.Add(new StyleBundle("~/Content/Plugins/SweetAlerts").Include(
                "~/Plugins/sweet-alert/sweetalert2.min.css"));
            
            bundles.Add(new ScriptBundle("~/bundles/Plugins/SweetAlerts").Include(
                "~/Plugins/sweet-alert/sweetalert2.min.js"));



            // Switchery
            bundles.Add(new StyleBundle("~/Content/Plugins/Switchery").Include(
                "~/Plugins/switchery/switchery.min.css"));

            bundles.Add(new ScriptBundle("~/bundles/Plugins/Switchery").Include(
                "~/Plugins/switchery/switchery.min.js"));

        }
    }
}
