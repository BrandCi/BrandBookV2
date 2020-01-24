

using System;
using System.ComponentModel.DataAnnotations;

namespace BrandBook.Core.ViewModels.App.Blog
{
    public class EditBlogEntryViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public bool IsPublished { get; set; }
        public bool IsVisibleForAnonymous { get; set; }

        [Required]
        public string UrlKey { get; set; }
        public string AdditionalStyles { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }
        public DateTime PublishDate { get; set; }
    }
}
