using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrandBook.Core.Domain.Brand.Font
{
    public class FontInclusion : BaseEntity
    {
        public string HtmlInline { get; set; }
        public string CssImport { get; set; }
        public string CssProperty { get; set; }

        public int FontId { get; set; }
        public Font Font { get; set; }
    }
}
