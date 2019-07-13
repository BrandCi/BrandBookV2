﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BrandBook.Core.Domain.Brand.Color;

namespace BrandBook.Core.Repositories.Brand
{
    public interface IColorCategoryRepository : IRepository<ColorCategory>
    {

        List<ColorCategory> GetCategoriesForBrand(int brandId);

    }
}