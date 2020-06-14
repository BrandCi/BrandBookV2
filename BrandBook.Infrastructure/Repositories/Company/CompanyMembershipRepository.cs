using BrandBook.Core.Domain.Company;
using BrandBook.Core.Repositories.Company;
using BrandBook.Infrastructure.Data;
using System.Linq;

namespace BrandBook.Infrastructure.Repositories.Company
{
    public class CompanyMembershipRepository : Repository<CompanyMembership>, ICompanyMembershipRepository
    {

        public CompanyMembershipRepository(BrandBookDbContext context)
            : base(context)
        {
        }


        public int GetAmountOfUsersForCompany(int companyId)
        {
            return Set
                .Where(x => x.CompanyId == companyId)
                .Count();
        }

        public int GetAmountOfManagersForCompany(int companyId)
        {
            return Set
                .Where(x => x.CompanyId == companyId && x.IsCompanyManager == true)
                .Count();
        }

        public int GetCompanyIdByUserId(int userId)
        {
            return Set
                .Where(x => x.Id == userId)
                .Select(x => x.CompanyId)
                .DefaultIfEmpty(0)
                .First();
        }


    }
}
