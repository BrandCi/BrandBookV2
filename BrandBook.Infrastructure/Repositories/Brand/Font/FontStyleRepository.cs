using System.Collections.Generic;
using System.Linq;
using BrandBook.Core.Domain.Brand.Font;
using BrandBook.Core.Repositories.Brand.Font;
using BrandBook.Infrastructure.Data;

namespace BrandBook.Infrastructure.Repositories.Brand.Font
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
