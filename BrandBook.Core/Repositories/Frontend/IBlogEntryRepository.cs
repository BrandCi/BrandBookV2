﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BrandBook.Core.Domain.Frontend;

namespace BrandBook.Core.Repositories.Frontend
{
    public interface IBlogEntryRepository : IRepository<BlogEntry>
    {

        bool BlogEntryExists(string blogEntryKey);
        BlogEntry FindBlogEntryByKey(string blogEntryKey);
        List<BlogEntry> GetAllPublishedBlogEntries();

    }
}