using BrandCi.Core.Domain.Brand.Font;
using BrandCi.Core.Repositories.Brand.Font;
using BrandCi.Infrastructure.Data;

namespace BrandCi.Infrastructure.Repositories.Brand.Font
{
    public class FontInclusionRepository : Repository<FontInclusion>, IFontInclusionRepository
    {
        public FontInclusionRepository(ApplicationDbContext context)
            : base(context)
        {
        }
    }
}
