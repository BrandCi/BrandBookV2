using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BrandBook.Core.Domain.Frontend;
using BrandBook.Core.Repositories.Frontend;
using BrandBook.Infrastructure.Data;

namespace BrandBook.Infrastructure.Repositories.Frontend
{
    public class BlogEntryRepository : Repository<BlogEntry>, IBlogEntryRepository
    {
        public BlogEntryRepository(BrandBookDbContext context)
            : base(context)
        {
        }


        public bool BlogEntryExists(string blogEntryKey)
        {
            return Set.Count(be => be.UrlKey == blogEntryKey) > 0;
        }

        public BlogEntry FindBlogEntryByKey(string blogEntryKey)
        {
            return Set.SingleOrDefault(be => be.UrlKey == blogEntryKey);
        }


    }
}
