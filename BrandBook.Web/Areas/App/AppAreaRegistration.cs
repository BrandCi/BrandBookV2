using BrandBook.Web.Routes;
using System;
using System.Web.Mvc;

namespace BrandBook.Web.Areas.App
{
    public class AppAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "App";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "App_entrypoint",
                "App/Dashboard/Index",
                new { controller = "Dashboard", action = "Index", id = UrlParameter.Optional }
            );


            context.MapRoute(
                "App_default",
                "App/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional },
                constraints: new
                {
                    serverRoute = new ServerRouteConstraint(url =>
                        url.PathAndQuery.StartsWith("/App",
                        StringComparison.InvariantCultureIgnoreCase))
                }
            );


            context.MapRoute(
                "Client_App",
                "App/{*url}",
                new { controller = "Dashboard", action = "RedesignEntry" }
            );
        }
    }
}