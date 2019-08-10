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
    
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public string MainHexColor { get; set; }

        public int BrandPublicSettingId { get; set; }
        public BrandPublicSetting BrandPublicSetting { get; set; }

        public int BrandSettingId { get; set; }
        public BrandSetting BrandSetting { get; set; }


        public List<Color.Color> Colors { get; set; }

        public int CompanyId { get; set; }
        public Company.Company Company { get; set; }
    }
}