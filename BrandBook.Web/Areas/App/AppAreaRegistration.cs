﻿using System;
using System.Web.Mvc;
using BrandBook.Web.Routes;

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
                "App_default",
                "App/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional },
                constraints: new
                {
                    serverRoute = new ServerRouteConstraint(url => 
                        url.PathAndQuery.StartsWith("/App/Profile",
                        StringComparison.InvariantCultureIgnoreCase))
                }
            );


            context.MapRoute(
                "Client_App",
                "App/{*url}",
                new {controller = "Dashboard", action = "AngularTest"}
            );
        }
    }
}