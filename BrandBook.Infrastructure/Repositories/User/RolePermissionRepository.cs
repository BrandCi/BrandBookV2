using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BrandBook.Core.Domain.User;
using BrandBook.Core.RepositoryInterfaces.User;
using BrandBook.Infrastructure.Data;

namespace BrandBook.Infrastructure.Repositories.User
{
    internal class RolePermissionRepository : Repository<RolePermission>, IRolePermissionRepository
    {
        internal RolePermissionRepository(BrandBookDbContext context)
            : base(context)
        {
        }
    }
}
