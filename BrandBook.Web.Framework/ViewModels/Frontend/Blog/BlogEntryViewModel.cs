﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrandBook.Web.Framework.ViewModels.Frontend.Blog
{
    public class BlogEntryViewModel
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