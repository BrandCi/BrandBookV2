using System.Web.Http;
using Unity;
using Unity.WebApi;

using BrandBook.Core;
using BrandBook.Infrastructure;

namespace BrandBook.Web
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            

            container.RegisterType<IUnitOfWork, UnitOfWork>();
            
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}