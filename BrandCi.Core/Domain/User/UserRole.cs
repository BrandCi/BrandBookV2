using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;

namespace BrandBook.Core.Domain.User
{
    public class CustomUserRole : IdentityUserRole<int> { }

    public class UserRole : IdentityRole<int, CustomUserRole>
    {
        public List<RolePermission> Permissions { get; set; }
    }
}
