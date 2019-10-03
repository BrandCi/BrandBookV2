

using System;

namespace BrandBook.Web.Framework.ViewModels.App.Blog
{
    public class EditBlogEntryViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public bool IsPublished { get; set; }
        public bool IsVisibleForAnonymous { get; set; }
        public string UrlKey { get; set; }
        public string AdditionalStyles { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }
        public DateTime PublishDate { get; set; }
    }
}
