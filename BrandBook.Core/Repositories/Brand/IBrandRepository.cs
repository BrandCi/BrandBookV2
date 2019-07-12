using System.Collections.Generic;

namespace BrandBook.Core.Repositories.Brand
{
    public interface IBrandRepository : IRepository<Domain.Brand.Brand>
    {

        List<Domain.Brand.Brand> GetBrandsByCompany(int companyId);

    }
}
