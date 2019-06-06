using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrandBook.Core.Domain.Brand
{
    public class Brand : BaseEntity
    {
        public string Name { get; set; }
        public string ImageName { get; set; }
        public string ImageType { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public string MainHexColor { get; set; }
    }
}