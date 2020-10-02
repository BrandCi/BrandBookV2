using BrandCi.Core.Repositories.Company;
using BrandCi.Infrastructure.Data;

namespace BrandCi.Infrastructure.Repositories.Company
{
    public class CompanyRepository : Repository<Core.Domain.Company.Company>, ICompanyRepository
    {

        public CompanyRepository(BrandBookDbContext context)
            : base(context)
        {
        }


    }
}
