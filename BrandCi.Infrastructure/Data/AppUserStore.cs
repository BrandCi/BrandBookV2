using BrandBook.Core.Domain.User;
using Microsoft.AspNet.Identity.EntityFramework;

namespace BrandBook.Infrastructure.Data
{
    public class AppUserStore : UserStore<AppUser, UserRole, int, CustomUserLogin, CustomUserRole, CustomUserClaim>
    {
        public AppUserStore(BrandBookDbContext context)
            : base(context)
        {
        }
    }

    public class UserRoleStore : RoleStore<UserRole, int, CustomUserRole>
    {
        public UserRoleStore(BrandBookDbContext context)
            : base(context)
        {
        }
    }
}
