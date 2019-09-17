using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;

namespace BrandBook.Core.Domain.User
{
    public class UserRole : IdentityRole
    {
        public List<RolePermission> Permissions { get; set; }
    }
}
