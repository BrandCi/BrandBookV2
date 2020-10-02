using BrandCi.Core.Domain.User;
using BrandCi.Core.Repositories.User;
using BrandCi.Infrastructure.Data;

namespace BrandCi.Infrastructure.Repositories.User
{
    internal class UserRoleRepository : Repository<UserRole>, IUserRoleRepository
    {
        internal UserRoleRepository(BrandBookDbContext context)
            : base(context)
        {
        }
    }
}
