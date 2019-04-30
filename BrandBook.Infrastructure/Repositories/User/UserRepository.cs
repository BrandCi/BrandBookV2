using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BrandBook.Core.RepositoryInterfaces.User;
using BrandBook.Infrastructure.Data;

namespace BrandBook.Infrastructure.Repositories.User
{
    internal class UserRepository : Repository<Core.Domain.User.User>, IUserRepository
    {
        internal UserRepository(BrandBookDbContext context)
            : base(context)
        {
        }


        public Core.Domain.User.User FindByUsername(string username)
        {
            return Set.FirstOrDefault(x => x.UserName == username);
        }

    }
}
