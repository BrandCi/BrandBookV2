using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.Collections.Generic;

namespace BrandCi.Core.Domain.User
{
    public class CustomUserRole : IdentityUserRole<int> { }

    public class UserRole : IdentityRole<int, CustomUserRole>
    {
        public List<RolePermission> Permissions { get; set; }
    }
}
