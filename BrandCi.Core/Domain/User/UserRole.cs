using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.Collections.Generic;

namespace BrandCi.Core.Domain.User
{
    public class UserRole : IdentityRole
    {
        public List<RolePermission> Permissions { get; set; }
    }
}
