using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BrandBook.Core.Domain.Resource;
using BrandBook.Core.Repositories.Resource;
using BrandBook.Infrastructure.Data;

namespace BrandBook.Infrastructure.Repositories.Resource
{
    public class ImageRepository : Repository<Image>, IImageRepository
    {
        public ImageRepository(BrandBookDbContext context)
            : base(context)
        {
        }
    }
}
