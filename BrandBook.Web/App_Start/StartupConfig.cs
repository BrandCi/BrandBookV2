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
            app.CreatePerOwinContext<UserAuthenticationService>(UserAuthenticationService.Create);
            app.CreatePerOwinContext<SignInService>(SignInService.Create);

            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Auth/Login/Index"),
                Provider = new CookieAuthenticationProvider
                {
                    OnValidateIdentity = SecurityStampValidator.OnValidateIdentity<UserAuthenticationService, AppUser, int>(
                        validateInterval: TimeSpan.FromMinutes(30),
                        regenerateIdentityCallback: (manager, user) => user.GenerateUserIdentityAsync(manager), getUserIdCallback: (id) => (id.GetUserId<int>()))
                }
            });


            app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);

            var isFacebookEnabled = ConfigurationManager.AppSettings["IsSocialFacebookEnabled"];
            if (isFacebookEnabled == "true" || isFacebookEnabled == "1")
            {
                app.UseFacebookAuthentication(
                    appId: ConfigurationManager.AppSettings["SocialFacebookAppId"],
                    appSecret: ConfigurationManager.AppSettings["SocialFacebookAppSecret"]
                );
            }


        }
    }
}