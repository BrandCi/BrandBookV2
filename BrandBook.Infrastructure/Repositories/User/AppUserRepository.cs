using BrandBook.Core.Domain.User;
using BrandBook.Core.Repositories.User;
using BrandBook.Infrastructure.Data;
using System.Linq;

namespace BrandBook.Infrastructure.Repositories.User
{
    public class AppUserRepository : Repository<AppUser>, IAppUserRepository
    {
        public AppUserRepository(BrandBookDbContext context)
            : base(context)
        {
        }


        public AppUser FindByUsername(string userName)
        {
            return Set.FirstOrDefault(x => x.UserName == userName);
        }


        public int CountUserForCompanyId(int companyId)
        {

            return Set.Where(x => x.Company.Id == companyId)
                .Count();

        }

        public int GetCompanyIdByUsername(string userName)
        {
            return Set
                .Where(x => x.UserName == userName)
                .Select(x => x.CompanyId)
                .DefaultIfEmpty(0)
                .First();
        }

        public int GetCompanyIdByUserId(string userId)
        {
            return Set
                .Where(x => x.Id == userId)
                .Select(x => x.CompanyId)
                .DefaultIfEmpty(0)
                .First();
        }

    }
}