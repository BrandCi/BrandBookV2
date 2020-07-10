using System.Web.Mvc;
using System.Web.Routing;

namespace BrandBook.Web.Routes
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute(
                url: "{resource}.axd/{*pathInfo}"
            );

            routes.MapMvcAttributeRoutes();


            routes.MapRoute(
                name: "BlogOverview",
                url: "Blog/Overview",
                defaults: new { controller = "Blog", action = "Overview" },
                namespaces: new[] { "BrandBook.Web.Controllers.BlogController" }
            );

            routes.MapRoute(
                name: "Blog",
                url: "Blog/{blogName}",
                defaults: new { controller = "Blog", action = "Index" },
                namespaces: new[] { "BrandBook.Web.Controllers.BlogController" }
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
