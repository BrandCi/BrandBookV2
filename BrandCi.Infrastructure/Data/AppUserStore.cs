using BrandCi.Core.Domain.User;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace BrandCi.Infrastructure.Data
{
    public class AppUserStore : UserStore
    {
        public AppUserStore(BrandBookDbContext context)
            : base(context)
        {
        }
    }

    public class UserRoleStore : RoleStore
    {
        public UserRoleStore(BrandBookDbContext context)
            : base(context)
        {
        }
    }
}
