using BrandCi.Core.Domain.Frontend;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BrandCi.Core.Repositories.Frontend
{
    public interface IBlogEntryRepository : IRepository<BlogEntry>
    {

        bool BlogEntryExistsAndPublished(string blogEntryKey);
        bool BlogEntryIdExists(int id);
        bool BlogEntryKeyExists(string blogEntryKey);
        BlogEntry FindBlogEntryByKey(string blogEntryKey);
        Task<List<BlogEntry>> GetAllPublishedBlogEntriesAsync();
        Task<List<BlogEntry>> GetAllPublishedBlogEntriesForAnonymousUserAsync();

    }
}
