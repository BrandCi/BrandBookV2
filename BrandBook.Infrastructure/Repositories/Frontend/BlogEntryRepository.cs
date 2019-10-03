using System;
using BrandBook.Core.Domain.Frontend;
using BrandBook.Core.Repositories.Frontend;
using BrandBook.Infrastructure.Data;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace BrandBook.Infrastructure.Repositories.Frontend
{
    public class BlogEntryRepository : Repository<BlogEntry>, IBlogEntryRepository
    {
        public BlogEntryRepository(BrandBookDbContext context)
            : base(context)
        {
        }


        public bool BlogEntryExistsAndPublished(string blogEntryKey)
        {
            return Set.Count(be => be.UrlKey == blogEntryKey && be.IsPublished) > 0;
        }


        public bool BlogEntryIdExists(int id)
        {
            return Set.Count(be => be.Id == id) > 0;
        }

        public BlogEntry FindBlogEntryByKey(string blogEntryKey)
        {
            return Set.SingleOrDefault(be => be.UrlKey == blogEntryKey);
        }


        public async Task<List<BlogEntry>> GetAllPublishedBlogEntriesAsync()
        {
            return await Set.Where(be => be.IsPublished && be.PublishDate >= DateTime.Now).ToListAsync();
        }


        public async Task<List<BlogEntry>> GetAllPublishedBlogEntriesForAnonymousUserAsync()
        {
            return await Set.Where(be => be.IsPublished && be.IsVisibleForAnonymous && be.PublishDate >= DateTime.Now).ToListAsync();
        }


    }
}
