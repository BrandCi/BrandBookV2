using BrandCi.Core.Domain.Resource;
using BrandCi.Core.Repositories.Resource;
using BrandCi.Infrastructure.Data;

namespace BrandCi.Infrastructure.Repositories.Resource
{
    public class ImageRepository : Repository<Image>, IImageRepository
    {
        public ImageRepository(BrandBookDbContext context)
            : base(context)
        {
        }
    }
}
