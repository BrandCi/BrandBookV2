using BrandBook.Core;
using BrandBook.Core.Services.Authentication;
using BrandBook.Core.Services.Messaging;
using BrandBook.Core.Services.Subscriptions;
using BrandBook.Infrastructure;
using BrandBook.Services.Authentication;
using BrandBook.Services.Notification;
using BrandBook.Services.Subscriptions;
using System.Web.Http;
using BrandBook.Core.Services.Notification;
using BrandBook.Core.Services.UserManagement;
using BrandBook.Services.UserManagement;
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

            #region Notification
            container.RegisterType<INotificationService, NotificationService>();
            container.RegisterType<IEmailBuilderService, EmailBuilderService>();
            #endregion

            #region UserManagement
            container.RegisterType<IUserService, UserService>();
            container.RegisterType<IRoleService, RoleService>();
            container.RegisterType<ICompanyService, CompanyService>();
            #endregion

            #endregion


            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}