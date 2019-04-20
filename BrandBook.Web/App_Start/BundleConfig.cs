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


            // Bundles for Sales Frontend
            bundles.Add(new StyleBundle("~/Content/Css/Main").Include(
                        "~/Content/Custom/style.css",
                        "~/Content/Custom/responsive.css"));

            bundles.Add(new StyleBundle("~/Content/Css/Styling/01").Include(
                        "~/Content/Custom/ColorStyle01.css"));

            bundles.Add(new StyleBundle("~/Content/Css/Styling/02").Include(
                        "~/Content/Custom/ColorStyle02.css"));

            bundles.Add(new StyleBundle("~/Content/Css/Styling/03").Include(
                        "~/Content/Custom/ColorStyle03.css"));


        }
    }
}
