using BrandCi.Core.Domain.Frontend;
using BrandCi.Core.Repositories.Frontend;
using BrandCi.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace BrandCi.Infrastructure.Repositories.Frontend
{
    public class BlogEntryRepository : Repository<BlogEntry>, IBlogEntryRepository
    {
        public BlogEntryRepository(BrandBookDbContext context)
            : base(context)
        {
        }


        public bool BlogEntryExistsAndPublished(string blogEntryKey)
        {
            return Set.Count(be => be.UrlKey == blogEntryKey && be.IsPublished && DateTime.Compare(DateTime.Now, be.PublishDate) >= 0) > 0;
        }


        public bool BlogEntryIdExists(int id)
        {
            return Set.Count(be => be.Id == id) > 0;
        }

        public bool BlogEntryKeyExists(string blogEntryKey)
        {
            return Set.Count(be => be.UrlKey == blogEntryKey) > 0;
        }

        public BlogEntry FindBlogEntryByKey(string blogEntryKey)
        {
            return Set.SingleOrDefault(be => be.UrlKey == blogEntryKey);
        }


        public async Task<List<BlogEntry>> GetAllPublishedBlogEntriesAsync()
        {
            return await Set
                .Where(be => be.IsPublished && DateTime.Compare(DateTime.Now, be.PublishDate) >= 0)
                .OrderByDescending(be => be.PublishDate)
                .ToListAsync();
        }


        public async Task<List<BlogEntry>> GetAllPublishedBlogEntriesForAnonymousUserAsync()
        {
            return await Set
                .Where(be => be.IsPublished && be.IsVisibleForAnonymous && DateTime.Compare(DateTime.Now, be.PublishDate) >= 0)
                .OrderByDescending(be => be.PublishDate)
                .ToListAsync();
        }


    }
}
