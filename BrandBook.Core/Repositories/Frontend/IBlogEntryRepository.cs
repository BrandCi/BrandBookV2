using BrandBook.Core.Domain.Frontend;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BrandBook.Core.Repositories.Frontend
{
    public interface IBlogEntryRepository : IRepository<BlogEntry>
    {

        bool BlogEntryExistsAndPublished(string blogEntryKey);
        bool BlogEntryIdExists(int id);
        BlogEntry FindBlogEntryByKey(string blogEntryKey);
        Task<List<BlogEntry>> GetAllPublishedBlogEntriesAsync();
        Task<List<BlogEntry>> GetAllPublishedBlogEntriesForAnonymousUserAsync();

    }
}
