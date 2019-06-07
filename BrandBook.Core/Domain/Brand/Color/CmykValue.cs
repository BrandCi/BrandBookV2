using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrandBook.Core.Domain.Brand.Color
{
    public class CmykValue : BaseEntity
    {

        public int C { get; set; }
        public int M { get; set; }
        public int Y { get; set; }
        public int K { get; set; }

    }
}
