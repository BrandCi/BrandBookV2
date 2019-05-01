using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;

namespace BrandBook.Core.Domain.User
{
    public class UserRole : IdentityRole
    {
        public List<RolePermission> Permissions { get; set; }
    }
}
