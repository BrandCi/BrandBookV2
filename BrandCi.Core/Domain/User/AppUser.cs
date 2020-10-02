using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BrandCi.Core.Domain.User
{
    public class CustomUserLogin : IdentityUserLogin<int> { }
    public class CustomUserClaim : IdentityUserClaim<int> { }


    public class AppUser : IdentityUser<int, CustomUserLogin, CustomUserRole, CustomUserClaim>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool PrivacyPolicyAccepted { get; set; }
        public bool IsActive { get; set; }

        public bool IsDarkmodeEnabled { get; set; }
        public bool IsRegisteredForBetaContent { get; set; }

        public DateTime CreationDate { get; set; }
        public DateTime LastModified { get; set; }
        public DateTime LastLogin { get; set; }

        public int CompanyId { get; set; }
        public Company.Company Company { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<AppUser, int> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }


    }

}
