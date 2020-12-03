using BrandCi.Core.Domain.User;
using BrandCi.Core.Repositories.User;
using BrandCi.Infrastructure.Data;
using System.Linq;

namespace BrandCi.Infrastructure.Repositories.User
{
    public class ApplicationUserRepository : Repository<ApplicationUser>, IApplicationUserRepository
    {
        private readonly ApplicationDbContext _ApplicationDbContext;
        public ApplicationUserRepository(ApplicationDbContext context)
            : base(context)
        {
            _ApplicationDbContext = context;
        }


        public ApplicationUser FindByUsername(string userName)
        {
            return Set.FirstOrDefault(x => x.UserName == userName);
        }


        public int CountUserForCompanyId(int companyId)
        {
            // TODO: Update Model
            // return Set.Count();
            return 1;

        }

        public int GetCompanyIdByUsername(string userName)
        {
            // TODO: Update Model
            return Set
                .Where(x => x.UserName == userName)
                .Select(x => x.AccessFailedCount)
                .DefaultIfEmpty(0)
                .First();
        }

        public int GetCompanyIdByUserId(int userId)
        {
            // TODO: Update Model
            return Set
                .Where(x => x.Id == "123")
                .Select(x => x.AccessFailedCount)
                .DefaultIfEmpty(0)
                .First();
        }


        public void UpdateWithModification(ApplicationUser user)
        {
            // TODO: Update Model
            // user.LastModified = DateTime.Now;
            // _ApplicationDbContext.Entry(user).State = EntityState.Modified;
        }

    }
}