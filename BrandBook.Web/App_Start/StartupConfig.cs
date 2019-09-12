using BrandBook.Core.Domain.User;
using BrandBook.Infrastructure.Data;
using BrandBook.Services.Authentication;
using BrandBook.Services.Users;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using System;
using System.Configuration;


namespace BrandBook.Web
{
    public partial class Startup
    {
        public void ConfigureAuth(IAppBuilder app)
        {
            app.CreatePerOwinContext(BrandBookDbContext.Create);
            app.CreatePerOwinContext<UserService>(UserService.Create);
            app.CreatePerOwinContext<SignInService>(SignInService.Create);

            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Auth/Login/Index"),
                Provider = new CookieAuthenticationProvider
                {
                    OnValidateIdentity = SecurityStampValidator.OnValidateIdentity<UserService, AppUser>(
                        validateInterval: TimeSpan.FromMinutes(30),
                        regenerateIdentity: (manager, user) => user.GenerateUserIdentityAsync(manager))
                }
            });


            app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);

            if (ConfigurationManager.AppSettings["IsSocialFacebookEnabled"] == "true")
            {
                app.UseFacebookAuthentication(
                    appId: ConfigurationManager.AppSettings["SocialFacebookAppId"],
                    appSecret: ConfigurationManager.AppSettings["SocialFacebookAppSecret"]
                );
            }


        }
    }
}