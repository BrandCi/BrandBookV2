using BrandBook.Core.Domain.Resource;
using System.Collections.Generic;

namespace BrandBook.Core.Domain.Brand
{
    public class Brand : BaseEntity
    {
        public string Name { get; set; }

        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public string MainHexColor { get; set; }


        public int ImageId { get; set; }
        public Image Image { get; set; }



        public List<Color.Color> Colors { get; set; }

        public int CompanyId { get; set; }
        public Company.Company Company { get; set; }
    }
}