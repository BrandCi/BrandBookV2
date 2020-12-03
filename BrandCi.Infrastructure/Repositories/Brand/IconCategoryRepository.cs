using BrandCi.Core.Domain.Brand.Icon;
using BrandCi.Core.Repositories.Brand;
using BrandCi.Infrastructure.Data;
using System.Collections.Generic;
using System.Linq;

namespace BrandCi.Infrastructure.Repositories.Brand
{
    public class IconCategoryRepository : Repository<IconCategory>, IIconCategoryRepository
    {
        public IconCategoryRepository(ApplicationDbContext context)
            : base(context)
        {
        }

        public List<IconCategory> GetCategoriesForBrand(int brandId)
        {
            return Set
                .Where(ic => ic.BrandId == brandId)
                .OrderBy(ic => ic.Sorting)
                .ToList();
        }
    }
}
