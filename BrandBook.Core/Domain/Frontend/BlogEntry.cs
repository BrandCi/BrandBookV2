using System;
using BrandBook.Core.Domain.User;

namespace BrandBook.Core.Domain.Frontend
{
    public class BlogEntry : BaseEntity
    {
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string UrlKey { get; set; }
        public bool IsPublished { get; set; }
        public bool IsVisibleForAnonymous { get; set; }
        public string AdditionalStyles { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }
        public DateTime CreationDateTime { get; set; }
        public DateTime PublishDate { get; set; }

        public int BlogImageId { get; set; }
        public BlogImage BlogImage { get; set; }

        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }
    }
}
