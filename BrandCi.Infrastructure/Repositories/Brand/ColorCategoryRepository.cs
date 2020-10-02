using BrandCi.Core.Domain.Brand.Color;
using BrandCi.Core.Repositories.Brand;
using BrandCi.Infrastructure.Data;
using System.Collections.Generic;
using System.Linq;

namespace BrandCi.Infrastructure.Repositories.Brand
{
    public class ColorCategoryRepository : Repository<ColorCategory>, IColorCategoryRepository
    {

        public ColorCategoryRepository(BrandBookDbContext context)
            : base(context)
        {
        }

        public List<ColorCategory> GetCategoriesForBrand(int brandId)
        {
            return Set.Where(cc => cc.BrandId == brandId).ToList();
        }

    }
}
