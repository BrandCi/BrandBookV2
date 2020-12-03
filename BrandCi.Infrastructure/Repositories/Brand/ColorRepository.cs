using BrandCi.Core.Domain.Brand.Color;
using BrandCi.Core.Repositories.Brand;
using BrandCi.Infrastructure.Data;
using System.Collections.Generic;
using System.Linq;

namespace BrandCi.Infrastructure.Repositories.Brand
{
    public class ColorRepository : Repository<Color>, IColorRepository
    {

        public ColorRepository(ApplicationDbContext context)
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
