﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrandBook.Web.Framework.ViewModels.App.Brand
{
    public class AddNewBrandViewModel
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string MainColor { get; set; }

        public string Image { get; set; }

        public bool AgreeTerms { get; set; }



    }
}