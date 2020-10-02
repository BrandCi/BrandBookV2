using System;

namespace BrandBook.Core.Dto.Frontend.Blog
{
    public class BlogOverviewDto
    {
        public string UrlKey { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string Author { get; set; }
        public DateTime PublishDate { get; set; }
    }
}
