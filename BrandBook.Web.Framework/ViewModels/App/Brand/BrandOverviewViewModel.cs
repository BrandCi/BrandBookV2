using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrandBook.Web.Framework.ViewModels.App.Brand
{
    public class BrandOverviewViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageName { get; set; }
        public string ImageType { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public string MainHexColor { get; set; }
    }
}
