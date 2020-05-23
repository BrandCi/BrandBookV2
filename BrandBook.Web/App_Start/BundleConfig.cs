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
                      "~/Content/Style/bootstrap.css",
                      "~/Content/Style/site.css"));


            bundles.Add(new StyleBundle("~/Content/Css/Flag-Icon").Include(
                        "~/Content/dist/Flag-Icon/flag-icon.min.css"));






            /* MODULES / PACKAGES */

            // FRONTEND
            bundles.Add(new ScriptBundle("~/bundles/packages/frontend/blog-overview").Include(
                "~/Scripts/Packages/Frontend/fe-blog-overview.js"
                ));

            bundles.Add(new ScriptBundle("~/bundles/packages/frontend/blog-item").Include(
                "~/Scripts/Packages/Frontend/fe-blog-item.js"
                ));
            // ./FRONTEND
            /* ########### */
            // APP
            bundles.Add(new ScriptBundle("~/bundles/packages/app/um-users-overview").Include(
                "~/Scripts/Packages/App/UserManagement/app-um-users-overview.js"
                ));
            // ./APP

            // AUTH
            bundles.Add(new ScriptBundle("~/bundles/packages/auth/scripts").Include(
                "~/Scripts/bootstrap.js",
                "~/Scripts/Dependencies/Auth/popper.min.js"
            ));

            bundles.Add(new ScriptBundle("~/bundles/packages/auth/registration/validation").Include(
                "~/Scripts/Packages/Auth/Validation/custom.registration.validation.js"
                ));
            // ./AUTH



            /* ./MODULES / PACKAGES */




            /*
             *
             * Styles
             * Frontend
             *
             */

            // Bundles for Frontend
            bundles.Add(new StyleBundle("~/Content/Css/Frontend/Main").Include(
                        "~/Content/Style/bootstrap.min.css",

                        /* Plugins */
                        "~/Plugins/Frontend/themify-icon/themify-icons.css",
                        "~/Plugins/Frontend/flaticon/flaticon.css",
                        "~/Plugins/Frontend/animation/animate.css",
                        "~/Plugins/Frontend/owl-carousel/assets/owl.carousel.min.css",
                        "~/Plugins/Frontend/magnify-pop/magnific-popup.css",
                        "~/Plugins/Frontend/elagent/style.css",
                        "~/Plugins/Frontend/scroll/jquery.mCustomScrollbar.min.css",
                        /* ./Plugins */

                        "~/Content/dist/Frontend/style.min.css",
                        "~/Content/dist/Frontend/responsive.css"));

            bundles.Add(new StyleBundle("~/Content/Css/Frontend/RTL").Include(
                "~/Content/dist/Frontend/rtl.css"));


            bundles.Add(new ScriptBundle("~/bundles/Frontend/Main").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/Dependencies/Frontend/propper.js",
                        "~/Scripts/bootstrap.min.js",

                        /* Plugins */
                        "~/Plugins/Frontend/wow/wow.min.js",
                        "~/Plugins/Frontend/sckroller/jquery.parallax-scroll.js",
                        "~/Plugins/Frontend/owl-carousel/owl.carousel.min.js",
                        "~/Plugins/Frontend/imagesloaded/imagesloaded.pkgd.min.js",
                        "~/Plugins/Frontend/isotope/isotope-min.js",
                        "~/Plugins/Frontend/scroll/jquery.mCustomScrollbar.concat.min.js",
                        "~/Plugins/Frontend/magnify-pop/jquery.magnific-popup.min.js"));



            bundles.Add(new ScriptBundle("~/bundles/Frontend/General").Include(
                "~/Scripts/Dependencies/Frontend/plugins.js",
                "~/Scripts/Dependencies/Frontend/main.js",
                "~/Scripts/Dependencies/Frontend/jquery.cookie.js"));



            /* Page Bundles */
            bundles.Add(new ScriptBundle("~/bundles/Frontend/Page/Homepage").Include(
                "~/Plugins/Frontend/circle-progress/circle-progress.js",
                "~/Plugins/Frontend/counterup/jquery.counterup.min.js",
                "~/Plugins/Frontend/counterup/jquery.waypoints.min.js",
                "~/Plugins/Frontend/counterup/appear.js",
                "~/Plugins/Frontend/multiscroll/jquery.easings.min.js",
                "~/Plugins/Frontend/multiscroll/multiscroll.responsiveExpand.limited.min.js",
                "~/Plugins/Frontend/multiscroll/jquery.multiscroll.extensions.min.js"));






            /*
             *
             * Styles
             * Auth
             *
             */

            bundles.Add(new StyleBundle("~/Content/Css/Auth/Main").Include(
                        "~/Content/Style/bootstrap.min.css",
                        "~/Content/Style/Auth/Styles.min.css"));





            /*
             *
             * Styles
             * App
             *
             */
            bundles.Add(new StyleBundle("~/Content/Css/App/Main").Include(
                "~/Plugins/switchery/switchery.min.css",
                "~/Content/Style/bootstrap.min.css"));

            bundles.Add(new StyleBundle("~/Content/Css/App/Mode/Basic").Include(
                "~/Content/Style/App/style.min.css"));

            bundles.Add(new StyleBundle("~/Content/Css/App/Mode/Dark").Include(
                "~/Content/Style/App/style_dark.min.css"));



            bundles.Add(new StyleBundle("~/Content/Css/App/Main/RTL").Include(
                "~/Content/Style/App/bootstrap-rtl.min.css"));


            bundles.Add(new ScriptBundle("~/bundles/App/Main").Include(
                "~/Scripts/jquery-{version}.js",
                "~/Scripts/Dependencies/App/Main/popper.min.js",
                "~/Scripts/bootstrap.min.js",
                "~/Scripts/Dependencies/App/Main/detect.js",
                "~/Scripts/Dependencies/App/Main/fastclick.js",
                "~/Scripts/Dependencies/App/Main/jquery.slimscroll.js",
                "~/Scripts/Dependencies/App/Main/jquery.blockUI.js",
                "~/Scripts/Dependencies/App/Main/waves.js",
                "~/Scripts/Dependencies/App/Main/wow.min.js",
                "~/Scripts/Dependencies/App/Main/jquery.nicescroll.js",
                "~/Scripts/Dependencies/App/Main/jquery.scrollTo.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/App/Core").Include(
                "~/Scripts/Dependencies/App/jquery.core.js",
                "~/Scripts/Dependencies/App/jquery.app.js"));








            /*
             *
             *  Plugins
             *
             */

            // Jquery.Validation
            bundles.Add(new ScriptBundle("~/bundles/Plugins/JqueryValidation").Include(
                "~/Plugins/jquery-validation/js/jquery.validate.min.js"
                ));

            // parsleyjs
            bundles.Add(new ScriptBundle("~/bundles/Plugins/Parsleyjs").Include(
                "~/Plugins/parsleyjs/dist/parsley.min.js"
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


            // Animated-Headlines
            bundles.Add(new StyleBundle("~/Content/Plugins/AnimatedHeadlines").Include(
                "~/Plugins/animated-headlines/animated-headlines.css"));

            bundles.Add(new ScriptBundle("~/bundles/Plugins/AnimatedHeadlines").Include(
                "~/Plugins/animated-headlines/animated-headlines.js"));


            // Dropzone
            bundles.Add(new StyleBundle("~/Content/Plugins/Dropzone").Include(
                "~/Plugins/dropzone/dropzone.css"));

            bundles.Add(new ScriptBundle("~/bundles/Plugins/Dropzone").Include(
                "~/Plugins/dropzone/dropzone.js"));

            
            // Bootstrap-Datepicker
            bundles.Add(new StyleBundle("~/Content/Plugins/Datepicker").Include(
                "~/Plugins/bootstrap-datepicker/dist/css/bootstrap-datepicker.min.css"));

            bundles.Add(new ScriptBundle("~/bundles/Plugins/Datepicker").Include(
                "~/Plugins/bootstrap-datepicker/dist/js/bootstrap-datepicker.min.js"));











            /*
             * CLIENT APP - APP AREA
             

            bundles.Add(new StyleBundle("~/ClientApp/App").Include(
                "~/Content/ClientApps/AppOutput/ClientApp/styles.*"));

            bundles.Add(new ScriptBundle("~/bundles/ClientApp/App").Include(
                "~/Content/ClientApps/AppOutput/ClientApp/runtime-es2015.js",
                "~/Content/ClientApps/AppOutput/ClientApp/runtime-es5.js",
                "~/Content/ClientApps/AppOutput/ClientApp/polyfills-es5.js",
                "~/Content/ClientApps/AppOutput/ClientApp/polyfills-es2015.js",
                "~/Content/ClientApps/AppOutput/ClientApp/vendor-es2015.js",
                "~/Content/ClientApps/AppOutput/ClientApp/vendor-es5.js",
                "~/Content/ClientApps/AppOutput/ClientApp/main-es2015.js",
                "~/Content/ClientApps/AppOutput/ClientApp/main-es5.js"));
*/
        }
    }
}
