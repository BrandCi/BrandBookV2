using BrandBook.Core.Domain.Brand.Font;
using BrandBook.Core.Repositories.Brand.Font;
using BrandBook.Infrastructure.Data;

namespace BrandBook.Infrastructure.Repositories.Brand.Font
{
    public class FontInclusionRepository : Repository<FontInclusion>, IFontInclusionRepository
    {
        public FontInclusionRepository(BrandBookDbContext context)
            : base(context)
        {
        }
    }
}
