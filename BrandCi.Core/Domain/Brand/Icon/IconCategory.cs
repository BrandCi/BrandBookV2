namespace BrandCi.Core.Domain.Brand.Icon
{
    public class IconCategory : BaseEntity
    {
        public string Name { get; set; }
        public int Sorting { get; set; }

        public int BrandId { get; set; }
        public Brand Brand { get; set; }
    }
}
