using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrandBook.Core.Domain.Brand.Color
{
    public class Color : BaseEntity
    {
        public string Name { get; set; }
        public ColorCategory Category { get; set; }

        public RgbValue RgbValue { get; set; }
        public CmykValue CmykValue { get; set; }

    }
}
