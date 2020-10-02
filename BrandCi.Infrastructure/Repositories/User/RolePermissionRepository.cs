using BrandBook.Core.Domain.User;
using BrandBook.Core.Repositories.User;
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
