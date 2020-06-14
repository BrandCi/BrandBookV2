using BrandBook.Core.Domain.Company;
using BrandBook.Core.Repositories.Company;
using BrandBook.Infrastructure.Data;

namespace BrandBook.Infrastructure.Repositories.Company
{
    public class CompanyMembershipRepository : Repository<CompanyMembership>, ICompanyMembershipRepository
    {

        public CompanyMembershipRepository(BrandBookDbContext context)
            : base(context)
        {
        }


    }
}
