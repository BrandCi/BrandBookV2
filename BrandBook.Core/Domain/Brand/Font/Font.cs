namespace BrandBook.Core.Domain.Brand.Font
{
    public class Font : BaseEntity
    {
        public string Name { get; set; }
        public string Family { get; set; }

        public Brand Brand { get; set; }

    }
}
