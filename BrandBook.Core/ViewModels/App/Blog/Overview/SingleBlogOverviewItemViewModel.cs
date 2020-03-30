using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BrandBook.Core.ViewModels.App.Blog.Overview
{
    public class SingleBlogOverviewItemViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string UrlKey { get; set; }
        public DateTime PublishDate { get; set; }
    }
}