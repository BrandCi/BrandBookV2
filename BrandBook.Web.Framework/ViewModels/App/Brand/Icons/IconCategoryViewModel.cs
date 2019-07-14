﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrandBook.Web.Framework.ViewModels.App.Brand.Icons
{
    public class IconCategoryViewModel : IEnumerable<SingleIconViewModel>
    {
        public string Name { get; set; }
        public List<SingleIconViewModel> Colors { get; set; }



        public IEnumerator<SingleIconViewModel> GetEnumerator()
        {
            return Colors.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
