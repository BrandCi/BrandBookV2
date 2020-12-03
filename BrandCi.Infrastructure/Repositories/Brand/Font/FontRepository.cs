using BrandCi.Core.Repositories.Brand.Font;
using BrandCi.Infrastructure.Data;
using System.Collections.Generic;
using System.Linq;

namespace BrandCi.Infrastructure.Repositories.Brand.Font
{
    public class FontRepository : Repository<Core.Domain.Brand.Font.Font>, IFontRepository
    {

        public FontRepository(ApplicationDbContext context)
            : base(context)
        {
        }

        public List<Core.Domain.Brand.Font.Font> GetAllFromBrand(int brandId)
        {
            return Set.Where(f => f.BrandId == brandId).ToList();
        }

    }
}
