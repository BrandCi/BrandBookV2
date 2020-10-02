namespace BrandCi.Core.Domain.Brand.Font
{
    public class FontStyle : BaseEntity
    {
        public string Name { get; set; }
        public string Style { get; set; }
        public string Weight { get; set; }

        public int FontId { get; set; }
        public Font Font { get; set; }
    }
}
