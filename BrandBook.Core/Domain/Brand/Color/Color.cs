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

        public int CategoryId { get; set; }
        public ColorCategory Category { get; set; }

        public int BrandId { get; set; }
        public Brand Brand { get; set; }

        public string HexColorCode { get; set; }

        public int RgbValueId { get; set; }
        public RgbValue RgbValue { get; set; }

        public int CmykValueId { get; set; }
        public CmykValue CmykValue { get; set; }

    }
}
