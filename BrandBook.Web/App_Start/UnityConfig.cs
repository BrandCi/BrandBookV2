using BrandBook.Core;
using BrandBook.Core.Services.Authentication;
using BrandBook.Core.Services.Messaging;
using BrandBook.Core.Services.Storage;
using BrandBook.Infrastructure;

using BrandBook.Core.Services.Subscriptions;
using BrandBook.Infrastructure;
using BrandBook.Services.Authentication;
using BrandBook.Services.Notification;
using BrandBook.Services.Storage;
using BrandBook.Services.Subscriptions;
using System.Web.Http;
using Unity;
using Unity.WebApi;

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
            container.RegisterType<IReCaptchaService, ReCaptchaService>();
            container.RegisterType<INotificationService, NotificationService>();
            container.RegisterType<IStorageService, BlobStorageService>();
            #endregion


            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}