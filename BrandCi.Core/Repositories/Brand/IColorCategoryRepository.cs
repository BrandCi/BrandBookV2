using BrandCi.Core.Domain.Brand.Color;
using System.Collections.Generic;

namespace BrandCi.Core.Repositories.Brand
{
    public interface IColorCategoryRepository : IRepository<ColorCategory>
    {

        List<ColorCategory> GetCategoriesForBrand(int brandId);

    }
}
