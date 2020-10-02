using BrandCi.Core.Domain.User;
using BrandCi.Core.Repositories.User;
using BrandCi.Infrastructure.Data;
using System;
using System.Data.Entity;
using System.Linq;

namespace BrandCi.Infrastructure.Repositories.User
{
    public class AppUserRepository : Repository<AppUser>, IAppUserRepository
    {
        private readonly BrandBookDbContext _brandBookDbContext;
        public AppUserRepository(BrandBookDbContext context)
            : base(context)
        {
            _brandBookDbContext = context;
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

        public int GetCompanyIdByUserId(int userId)
        {
            return Set
                .Where(x => x.Id == userId)
                .Select(x => x.CompanyId)
                .DefaultIfEmpty(0)
                .First();
        }


        public void UpdateWithModification(AppUser user)
        {
            user.LastModified = DateTime.Now;
            _brandBookDbContext.Entry(user).State = EntityState.Modified;
        }

    }
}