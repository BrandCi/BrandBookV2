namespace BrandCi.Core.Domain.Brand.Color
{
    public class ColorCategory : BaseEntity
    {
        public string Name { get; set; }

        public int BrandId { get; set; }
        public Brand Brand { get; set; }
    }
}
