using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrandBook.Core.Dtos.Brand
{
    public class BrandDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageName { get; set; }
        public string ImageType { get; set; }
        public string Description { get; set; }
        public string MainHexColor { get; set; }
    }
}
