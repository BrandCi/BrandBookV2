using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrandBook.Core.Domain.Brand.Color
{
    public class ColorCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Brand Brand { get; set; }
    }
}
