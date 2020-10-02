using BrandCi.Core.Domain.Brand.Font;
using BrandCi.Core.Repositories.Brand.Font;
using BrandCi.Infrastructure.Data;
using System.Collections.Generic;
using System.Linq;

namespace BrandCi.Infrastructure.Repositories.Brand.Font
{
    public class FontStyleRepository : Repository<FontStyle>, IFontStyleRepository
    {
        public FontStyleRepository(BrandBookDbContext context)
            : base(context)
        {
        }

        public List<FontStyle> GetAllForFont(int fontId)
        {
            return Set.Where(fs => fs.FontId == fontId).ToList();
        }
    }
}
