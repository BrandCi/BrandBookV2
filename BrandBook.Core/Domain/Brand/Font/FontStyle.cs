using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrandBook.Core.Domain.Brand.Font
{
    public class FontStyle : BaseEntity
    {
        public string Name { get; set; }
        public string Style { get; set; }
        public string Weight { get; set; }

        public int FontId { get; set; }
        public Font Font { get; set; }
    }
}
