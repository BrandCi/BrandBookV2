using System.Web.Mvc;
using System.Web.Routing;

namespace BrandBook.Web.Routes
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapMvcAttributeRoutes();


            routes.MapRoute(
                "BlogOverview",
                "Blog/Overview",
                new { controller = "Blog", action = "Overview" },
                new[] { "BrandBook.Web.Controllers.BlogController" }
            );

            routes.MapRoute(
                "Blog",
                "Blog/{blogName}",
                new { controller = "Blog", action = "Index" },
                new[] { "BrandBook.Web.Controllers.BlogController" }
            );




            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Fallback",
                url: "",
                defaults: new { controller = "Home", action = "Index" }
            );
        }
    }
}
