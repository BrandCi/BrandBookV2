using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrandBook.Core.Domain.Brand
{
    public class BrandSetting : BaseEntity
    {
        public string ContactEmail { get; set; }
        public string PrimaryHexColor { get; set; }
        public bool RoundedButtons { get; set; }
        public int RoundedButtonsPixel { get; set; }
    }
}
