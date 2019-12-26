using BrandBook.Infrastructure;
using BrandBook.Infrastructure.Data;
using BrandBook.Web.Routes;
using System.Data.Entity;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace BrandBook.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AutoMapper.Mapper.Initialize(cfg => cfg.AddProfile<MappingProfile>());
            // GlobalConfiguration.Configure(WebApiConfig.Register);
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            Database.SetInitializer(new MigrateDatabaseToLatestVersion<BrandBookDbContext, Infrastructure.Migrations.Configuration>());
            var migrateDb = new BrandBookDbContext();
            migrateDb.Database.Initialize(true);

        }
    }
}
