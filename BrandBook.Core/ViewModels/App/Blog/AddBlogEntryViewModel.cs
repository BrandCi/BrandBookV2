﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Threading.Tasks;

namespace BrandBook.Core.ViewModels.App.Blog
{
    public class AddBlogEntryViewModel
    {
        [Required]
        public string Title { get; set; }
        public string SubTitle { get; set; }

        public string AdditionalStyles { get; set; }
        public string Content { get; set; }

        public string Author { get; set; }
        public DateTime PublishDate { get; set; }
    }
}
