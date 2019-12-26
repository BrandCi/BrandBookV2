using BrandBook.Core.Domain.Brand.Icon;
using BrandBook.Core.Repositories.Brand;
using BrandBook.Infrastructure.Data;
using System.Collections.Generic;
using System.Linq;

namespace BrandBook.Infrastructure.Repositories.Brand
{
    public class IconCategoryRepository : Repository<IconCategory>, IIconCategoryRepository
    {
        public IconCategoryRepository(BrandBookDbContext context)
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
