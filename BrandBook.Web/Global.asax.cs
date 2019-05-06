using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations.Design;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using BrandBook.Web.Routes;
using BrandBook.Infrastructure;
using BrandBook.Infrastructure.Data;

namespace BrandBook.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AutoMapper.Mapper.Initialize(cfg => cfg.AddProfile<MappingProfile>());
            GlobalConfiguration.Configure(WebApiConfig.Register);
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            Database.SetInitializer(new MigrateDatabaseToLatestVersion<BrandBookDbContext, Infrastructure.Migrations.Configuration>());
            BrandBookDbContext migrateDb = new BrandBookDbContext();
            migrateDb.Database.Initialize(true);

        }
    }
}
