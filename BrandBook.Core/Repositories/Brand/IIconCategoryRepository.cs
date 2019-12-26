using BrandBook.Core.Domain.Brand.Icon;
using System.Collections.Generic;

namespace BrandBook.Core.Repositories.Brand
{
    public interface IIconCategoryRepository : IRepository<IconCategory>
    {
        List<IconCategory> GetCategoriesForBrand(int brandId);
    }
}
