using BrandCi.Core.Domain.User;
using BrandCi.Core.Repositories.User;
using BrandCi.Infrastructure.Data;

namespace BrandCi.Infrastructure.Repositories.User
{
    internal class RolePermissionRepository : Repository<RolePermission>, IRolePermissionRepository
    {
        internal RolePermissionRepository(BrandBookDbContext context)
            : base(context)
        {
        }
    }
}
