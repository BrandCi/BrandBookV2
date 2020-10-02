using BrandBook.Core.Domain.Brand.Color;
using BrandBook.Core.Repositories.Brand;
using BrandBook.Infrastructure.Data;
using System.Collections.Generic;
using System.Linq;

namespace BrandBook.Infrastructure.Repositories.Brand
{
    public class ColorRepository : Repository<Color>, IColorRepository
    {

        public ColorRepository(BrandBookDbContext context)
            : base(context)
        {
        }

        public List<Color> GetAllColorsFromCategory(int categoryId)
        {
            return Set
                .Where(c => c.CategoryId == categoryId)
                .OrderBy(c => c.Sorting)
                .ToList();
        }


    }
}
