using BrandBook.Core.Repositories.Company;
using BrandBook.Infrastructure.Data;

namespace BrandBook.Infrastructure.Repositories.Company
{
    public class CompanyRepository : Repository<Core.Domain.Company.Company>, ICompanyRepository
    {

        public CompanyRepository(BrandBookDbContext context)
            : base(context)
        {
        }


    }
}
