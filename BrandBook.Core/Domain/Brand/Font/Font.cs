﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrandBook.Core.Domain.Brand.Font
{
    public class Font : BaseEntity
    {
        public string Name { get; set; }
        public string Family { get; set; }

        public int FontInclusionId { get; set; }
        public FontInclusion FontInclusion { get; set; }

        public int BrandId { get; set; }
        public Brand Brand { get; set; }

    }
}
