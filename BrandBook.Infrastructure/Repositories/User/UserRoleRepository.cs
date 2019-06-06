using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BrandBook.Core.Domain.User;
using BrandBook.Core.Repositories.User;
using BrandBook.Infrastructure.Data;

namespace BrandBook.Infrastructure.Repositories.User
{
    internal class UserRoleRepository : Repository<UserRole>, IUserRoleRepository
    {
        internal UserRoleRepository(BrandBookDbContext context)
            : base(context)
        {
        }
    }
}
