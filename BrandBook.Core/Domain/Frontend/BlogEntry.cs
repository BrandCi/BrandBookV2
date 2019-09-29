using System;
using BrandBook.Core.Domain.User;

namespace BrandBook.Core.Domain.Frontend
{
    public class BlogEntry : BaseEntity
    {
        public bool IsPublished { get; set; }
        public bool IsVisibleForAnonymous { get; set; }
        public string UrlKey { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string AdditionalStyles { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }
        public DateTime CreationDateTime { get; set; }

        public int BlogImageId { get; set; }
        public BlogImage BlogImage { get; set; }

        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }
    }
}
