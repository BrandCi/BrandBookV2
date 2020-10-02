using BrandCi.Core.Domain.Brand.Icon;
using System.Collections.Generic;

namespace BrandCi.Core.Repositories.Brand
{
    public interface IIconCategoryRepository : IRepository<IconCategory>
    {
        List<IconCategory> GetCategoriesForBrand(int brandId);
    }
}
