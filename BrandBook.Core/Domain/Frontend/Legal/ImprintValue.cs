using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrandBook.Core.Domain.Frontend.Legal
{
    public class ImprintValue : BaseEntity
    {
        public string Name { get; set; }
        public string Value { get; set; }
        public int Position { get; set; }
        public ImprintCategory Category { get; set; }
    }
}