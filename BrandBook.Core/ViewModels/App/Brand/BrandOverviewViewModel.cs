
namespace BrandBook.Core.ViewModels.App.Brand
{
    public class BrandOverviewViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public string MainHexColor { get; set; }
        public BrandImageViewModel Image { get; set; }
    }
}
