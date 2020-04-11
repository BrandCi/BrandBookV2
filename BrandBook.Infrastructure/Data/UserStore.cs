using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BrandBook.Core.Domain.User;
using Microsoft.AspNet.Identity.EntityFramework;

namespace BrandBook.Infrastructure.Data
{
    public class UserStore : UserStore<AppUser, UserRole, int, CustomUserLogin, CustomUserRole, CustomUserClaim>
    {
        public UserStore(BrandBookDbContext context)
            : base(context)
        {
        }
    }

    public class RoleStore : RoleStore<UserRole, int, CustomUserRole>
    {
        public RoleStore(BrandBookDbContext context)
            : base(context)
        {
        }
    }
}
