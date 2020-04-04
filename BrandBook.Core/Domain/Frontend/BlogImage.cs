using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BrandBook.Core.Domain.Frontend
{
    public class BlogImage : BaseEntity
    {
        public string Name { get; set; }
        public string ContentType { get; set; }
    }
}
