using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrandBook.Core.Domain.Resource
{
    public class Image : BaseEntity
    {

        public string Name { get; set; }
        public string ContentType { get; set; }
        public int Category { get; set; }

    }
}
