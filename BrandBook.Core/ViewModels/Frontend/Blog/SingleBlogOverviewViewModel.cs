using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BrandBook.Core.ViewModels.Frontend.Blog
{
    public class SingleBlogOverviewViewModel
    {
        public string UrlKey { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string Author { get; set; }
        public DateTime PublishDate { get; set; }

    }
}
