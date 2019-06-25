using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrandBook.Core.Domain.Brand.Font
{
    public class FontInclusion : BaseEntity
    {
        public string InlineIntegration { get; set; }
        public string CssImport { get; set; }
        public string CssProperty { get; set; }
    }
}
