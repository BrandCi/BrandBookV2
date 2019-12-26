using System.Collections.Generic;

namespace BrandBook.Core.Repositories.Brand.Font
{
    public interface IFontRepository : IRepository<Domain.Brand.Font.Font>
    {
        List<Domain.Brand.Font.Font> GetAllFromBrand(int brandId);
    }
}
