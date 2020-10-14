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
                "~/Content/Scripts/Packages/Frontend/fe-blog-overview.js"
                ));

            bundles.Add(new ScriptBundle("~/bundles/packages/frontend/blog-item").Include(
                "~/Content/Scripts/Packages/Frontend/fe-blog-item.js"
                ));
            // ./FRONTEND
            /* ########### */
            // APP
            bundles.Add(new ScriptBundle("~/bundles/packages/app/um-users-overview").Include(
                "~/Content/Scripts/Packages/App/UserManagement/app-um-users-overview.js"
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
                "~/Content/dist/App/bootstrap.min.css"));

            bundles.Add(new StyleBundle("~/Content/Css/App/Mode/Basic").Include(
                "~/Content/dist/App/style.min.css"));

            bundles.Add(new StyleBundle("~/Content/Css/App/Mode/Dark").Include(
                "~/Content/dist/App/style_dark.min.css"));

            bundles.Add(new StyleBundle("~/Content/Css/App/Main/RTL").Include(
                "~/Content/dist/App/bootstrap-rtl.min.css"));



            bundles.Add(new ScriptBundle("~/bundles/App/Main").Include(
                "~/Content/Scripts/Dependencies/App/Main/jquery-{version}.js",
                "~/Content/Scripts/Dependencies/App/Main/popper.min.js",
                "~/Content/Scripts/Dependencies/App/Main/bootstrap.min.js",
                "~/Content/Scripts/Dependencies/App/Main/detect.js",
                "~/Content/Scripts/Dependencies/App/Main/fastclick.js",
                "~/Content/Scripts/Dependencies/App/Main/jquery.slimscroll.js",
                "~/Content/Scripts/Dependencies/App/Main/jquery.blockUI.js",
                "~/Content/Scripts/Dependencies/App/Main/waves.js",
                "~/Content/Scripts/Dependencies/App/Main/wow.min.js",
                "~/Content/Scripts/Dependencies/App/Main/jquery.nicescroll.js",
                "~/Content/Scripts/Dependencies/App/Main/jquery.scrollTo.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/App/Core").Include(
                "~/Content/Scripts/Dependencies/App/jquery.core.js",
                "~/Content/Scripts/Dependencies/App/jquery.app.js"));








            /*
             *
             *  Plugins
             *
             */

            // Jquery.Validation
            bundles.Add(new ScriptBundle("~/bundles/Plugins/JqueryValidation").Include(
                "~/Content/dist/App/Plugins/jquery-validation/js/jquery.validate.min.js"
                ));


            // Modals
            bundles.Add(new StyleBundle("~/Content/Plugins/Modals").Include(
                    "~/Content/dist/App/Plugins/custombox/dist/custombox.min.css",
                    "~/Content/dist/App/Plugins/morris/morris.css"));

            bundles.Add(new ScriptBundle("~/bundles/Plugins/Modals").Include(
                "~/Content/dist/App/Plugins/custombox/dist/custombox.min.js",
                "~/Content/dist/App/Plugins/custombox/dist/legacy.min.js"));



            // Morris Chart
            bundles.Add(new StyleBundle("~/Content/Plugins/MorrisChart").Include(
                "~/Content/dist/App/Plugins/morris/morris.css"));

            bundles.Add(new ScriptBundle("~/bundles/Plugins/MorrisChart").Include(
                "~/Content/dist/App/Plugins/morris/morris.min.js",
                "~/Content/dist/App/Plugins/raphael/raphael-min.js"));


            // Datatables
            bundles.Add(new StyleBundle("~/Content/Plugins/Datatables").Include(
                "~/Content/dist/App/Plugins/datatables/dataTables.bootstrap4.min.css",
                "~/Content/dist/App/Plugins/datatables/buttons.bootstrap4.min.css",
                "~/Content/dist/App/Plugins/datatables/responsive.bootstrap4.min.css"));

            bundles.Add(new ScriptBundle("~/bundles/Plugins/Datatables").Include(
                "~/Content/dist/App/Plugins/datatables/jquery.dataTables.min.js",
                "~/Content/dist/App/Plugins/datatables/dataTables.bootstrap4.min.js",
                "~/Content/dist/App/Plugins/datatables/dataTables.buttons.min.js",
                "~/Content/dist/App/Plugins/datatables/buttons.bootstrap4.min.js",
                "~/Content/dist/App/Plugins/datatables/jszip.min.js",
                "~/Content/dist/App/Plugins/datatables/pdfmake.min.js",
                "~/Content/dist/App/Plugins/datatables/vfs_fonts.js",
                "~/Content/dist/App/Plugins/datatables/buttons.html5.min.js",
                "~/Content/dist/App/Plugins/datatables/buttons.print.min.js",
                "~/Content/dist/App/Plugins/datatables/dataTables.keyTable.min.js",
                "~/Content/dist/App/Plugins/datatables/dataTables.responsive.min.js",
                "~/Content/dist/App/Plugins/datatables/responsive.bootstrap4.min.js",
                "~/Content/dist/App/Plugins/datatables/dataTables.select.min.js"));

            // Bootstrap-Datepicker
            bundles.Add(new StyleBundle("~/Content/Plugins/Datepicker").Include(
                "~/Content/dist/App/Plugins/bootstrap-datepicker/dist/css/bootstrap-datepicker.min.css"));

            bundles.Add(new ScriptBundle("~/bundles/Plugins/Datepicker").Include(
                "~/Content/dist/App/Plugins/bootstrap-datepicker/dist/js/bootstrap-datepicker.min.js"));


        }
    }
}
