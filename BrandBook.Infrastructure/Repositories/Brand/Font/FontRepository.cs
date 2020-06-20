using BrandBook.Core.Repositories.Brand.Font;
using BrandBook.Infrastructure.Data;
using System.Collections.Generic;
using System.Linq;

namespace BrandBook.Infrastructure.Repositories.Brand.Font
{
    public class FontRepository : Repository<Core.Domain.Brand.Font.Font>, IFontRepository
    {

        public FontRepository(BrandBookDbContext context)
            : base(context)
        {
        }

        public List<Core.Domain.Brand.Font.Font> GetAllFromBrand(int brandId)
        {
            return Set.Where(f => f.BrandId == brandId).ToList();
        }

    }
}
