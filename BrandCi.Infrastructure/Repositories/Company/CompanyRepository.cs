using BrandCi.Core.Repositories.Company;
using BrandCi.Infrastructure.Data;

namespace BrandCi.Infrastructure.Repositories.Company
{
    public class CompanyRepository : Repository<Core.Domain.Company.Company>, ICompanyRepository
    {

        public CompanyRepository(ApplicationDbContext context)
            : base(context)
        {
        }


    }
}
