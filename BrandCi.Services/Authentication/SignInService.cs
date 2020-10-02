using BrandCi.Core.Domain.User;
using Microsoft.AspNetCore.Identity.Owin;
using Microsoft.AspNetCore.Owin;
using Microsoft.AspNetCore.Owin.Security;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BrandCi.Services.Authentication
{
    public class SignInService : SignInManager<AppUser, int>
    {
        public SignInService(UserAuthenticationService userManager, IAuthenticationManager authenticationManager)
            : base(userManager, authenticationManager)
        {
        }

        public override Task<ClaimsIdentity> CreateUserIdentityAsync(AppUser appUser)
        {
            return appUser.GenerateUserIdentityAsync((UserAuthenticationService)UserManager);
        }

        public static SignInService Create(IdentityFactoryOptions<SignInService> options, IOwinContext context)
        {
            return new SignInService(context.GetUserManager<UserAuthenticationService>(), context.Authentication);
        }
    }
}