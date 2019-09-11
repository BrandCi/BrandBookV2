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
    }
}
