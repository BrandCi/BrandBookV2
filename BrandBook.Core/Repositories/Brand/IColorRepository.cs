using System.Collections.Generic;
using BrandBook.Core.Domain.Brand.Color;

namespace BrandBook.Core.Repositories.Brand
{
    public interface IColorRepository : IRepository<Color>
    {
        List<Color> GetAllColorsFromBrand(int brandId);
    }
}
