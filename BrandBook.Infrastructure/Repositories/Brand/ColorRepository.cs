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
    public class ColorRepository : Repository<Color>, IColorRepository
    {

        public ColorRepository(BrandBookDbContext context)
            : base(context)
        {
        }



        public List<Color> GetAllColorsFromBrand(int brandId)
        {
            return Set
                .Where(c => c.BrandId == brandId)
                .ToList();
        }


        public List<Color> GetAllColorsFromCategory(int categoryId)
        {
            return Set
                .Where(c => c.CategoryId == categoryId)
                .ToList();
        }


    }
}
