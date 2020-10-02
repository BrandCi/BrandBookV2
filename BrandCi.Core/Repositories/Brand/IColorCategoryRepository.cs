using BrandBook.Core.Domain.Brand.Color;
using System.Collections.Generic;

namespace BrandBook.Core.Repositories.Brand
{
    public interface IColorCategoryRepository : IRepository<ColorCategory>
    {

        List<ColorCategory> GetCategoriesForBrand(int brandId);

    }
}
