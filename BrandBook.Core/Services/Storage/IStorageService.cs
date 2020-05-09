﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrandBook.Core.Services.Storage
{
    public interface IStorageService
    {
        string GetItemUrlByRelativePath(string relativePath);
    }
}