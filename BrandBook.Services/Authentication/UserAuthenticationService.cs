using BrandBook.Core.Domain.User;
using BrandBook.Infrastructure.Data;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using System;

namespace BrandBook.Services.Authentication
{
    public class UserAuthenticationService : UserManager<AppUser, int>
    {
        public UserAuthenticationService(IUserStore<AppUser, int> store)
            : base(store)
        {
        }

        public static UserAuthenticationService Create(IdentityFactoryOptions<UserAuthenticationService> options, IOwinContext context)
        {
            var manager = new UserAuthenticationService(new AppUserStore(context.Get<BrandBookDbContext>()));

            // Validation for usernames
            manager.UserValidator = new UserValidator<AppUser, int>(manager)
            {
                AllowOnlyAlphanumericUserNames = false,
                RequireUniqueEmail = true
            };

            // Validation for passwords
            manager.PasswordValidator = new PasswordValidator
            {
                RequiredLength = 8,
                RequireNonLetterOrDigit = true,
                RequireDigit = true,
                RequireLowercase = true,
                RequireUppercase = true,
            };

            // AppUser lockout defaults
            manager.UserLockoutEnabledByDefault = true;
            manager.DefaultAccountLockoutTimeSpan = TimeSpan.FromMinutes(5);
            manager.MaxFailedAccessAttemptsBeforeLockout = 5;


            var dataProtectionProvider = options.DataProtectionProvider;
            if (dataProtectionProvider != null)
            {
                manager.UserTokenProvider =
                    new DataProtectorTokenProvider<AppUser, int>(dataProtectionProvider.Create("ASP.NET Identity"));
            }
            return manager;
        }
    }

}
