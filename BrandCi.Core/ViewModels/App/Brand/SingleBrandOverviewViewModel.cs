
namespace BrandCi.Core.ViewModels.App.Brand
{
    public class SingleBrandOverviewViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string ShortDescription { get; set; }
        public string MainHexColor { get; set; }
        public BrandImageViewModel BrandImage { get; set; }
    }


}