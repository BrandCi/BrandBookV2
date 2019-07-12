using System.Collections.Generic;
using System.Threading.Tasks;

namespace BrandBook.Core.Repositories.Brand
{
    public interface IBrandRepository : IRepository<Domain.Brand.Brand>
    {

        Task<List<Domain.Brand.Brand>> GetBrandsByCompanyAsync(int companyId);
        int IsBrandExistingById(int brandId);

    }
}
