using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrandBook.Core.RepositoryInterfaces.User
{
    public interface IUserRepository : IRepository<Domain.User.User>
    {
        Domain.User.User FindByUsername(string username);
    }
}
