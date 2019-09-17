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
