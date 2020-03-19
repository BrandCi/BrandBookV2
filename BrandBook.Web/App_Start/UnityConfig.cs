using System.Web.Http;
using Unity;
using Unity.WebApi;

using BrandBook.Core;
using BrandBook.Infrastructure;

using BrandBook.Core.Services.Subscriptions;
using BrandBook.Services.Subscriptions;

namespace BrandBook.Web
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            #region General
            container.RegisterType<IUnitOfWork, UnitOfWork>();
            #endregion

            #region Services
            container.RegisterType<ISubscriptionService, SubscriptionService>();
            #endregion





            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}