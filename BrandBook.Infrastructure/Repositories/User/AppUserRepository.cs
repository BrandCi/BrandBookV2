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
    public class AppUserRepository : Repository<AppUser>, IAppUserRepository
    {
        public AppUserRepository(BrandBookDbContext context)
            : base(context)
        {
        }


        public AppUser FindByUsername(string username)
        {
            return Set.FirstOrDefault(x => x.UserName == username);
        }


        public int CountUserForCompanyId(int companyId)
        {

            return Set.Where(au => au.Company.Id == companyId)
                .Count();

        }

        public int GetCompanyIdByUsername(string username)
        {
            return Set.FirstOrDefault(x => x.UserName == username).CompanyId;
        }

    }
}