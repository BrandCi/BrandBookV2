using System.Collections.Generic;
using System.Threading.Tasks;

namespace BrandCi.Core.Repositories.Brand
{
    public interface IBrandRepository : IRepository<Domain.Brand.Brand>
    {

        List<Domain.Brand.Brand> GetBrandsByCompany(int companyId);
        Task<List<Domain.Brand.Brand>> GetBrandsByCompanyAsync(int companyId);
        bool IsBrandExistingById(int brandId);

        int CountBrandsByCompany(int companyId);

    }
}
