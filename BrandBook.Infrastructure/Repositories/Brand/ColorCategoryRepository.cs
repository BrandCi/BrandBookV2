using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BrandBook.Core.Domain.Brand.Color;
using BrandBook.Core.Repositories.Brand;
using BrandBook.Infrastructure.Data;

namespace BrandBook.Infrastructure.Repositories.Brand
{
    public class ColorCategoryRepository : Repository<ColorCategory>, IColorCategoryRepository
    {

        public ColorCategoryRepository(BrandBookDbContext context)
            : base(context)
        {
        }

    }
}
