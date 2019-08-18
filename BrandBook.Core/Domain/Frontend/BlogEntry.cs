using System;

namespace BrandBook.Core.Domain.Frontend
{
    public class BlogEntry : BaseEntity
    {

        public string UrlKey { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string Image { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }
        public DateTime CreationDateTime { get; set; }


    }
}
