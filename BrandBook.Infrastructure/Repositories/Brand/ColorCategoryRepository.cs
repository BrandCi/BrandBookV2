using BrandBook.Core.Domain.Brand.Color;
using BrandBook.Core.Repositories.Brand;
using BrandBook.Infrastructure.Data;
using System.Collections.Generic;
using System.Linq;

namespace BrandBook.Infrastructure.Repositories.Brand
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
