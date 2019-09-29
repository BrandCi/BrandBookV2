using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrandBook.Web.Framework.ViewModels.App.Blog.Overview
{
    public class SingleBlogOverviewItemViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string UrlKey { get; set; }
        public bool IsPublished { get; set; }
        public DateTime CreationDate { get; set; }
    }
}