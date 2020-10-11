using System.Web.Optimization;

namespace BrandBook.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
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



            /* ./MODULES / PACKAGES */

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
                "~/Content/dist/App/style.min.css"));

            bundles.Add(new StyleBundle("~/Content/Css/App/Mode/Dark").Include(
                "~/Content/dist/App/style_dark.min.css"));

            bundles.Add(new StyleBundle("~/Content/Css/App/Main/RTL").Include(
                "~/Content/dist/App/bootstrap-rtl.min.css"));



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


            // Bootstrap-Datepicker
            bundles.Add(new StyleBundle("~/Content/Plugins/Datepicker").Include(
                "~/Plugins/bootstrap-datepicker/dist/css/bootstrap-datepicker.min.css"));

            bundles.Add(new ScriptBundle("~/bundles/Plugins/Datepicker").Include(
                "~/Plugins/bootstrap-datepicker/dist/js/bootstrap-datepicker.min.js"));


        }
    }
}
