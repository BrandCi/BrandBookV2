using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrandBook.Web.Framework.ViewModels.App.Brand.Colors
{
    public class AddColorItemViewModel
    {
        public int BrandId { get; set; }
        public string Name { get; set; }

        [MaxLength(6)]
        public string HexColor { get; set; }

    }
}
