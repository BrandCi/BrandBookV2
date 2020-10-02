namespace BrandCi.Core.Domain.Brand.Icon
{
    public class Icon : BaseEntity
    {

        public string ClassName { get; set; }
        public string Prefix { get; set; }

        public int IconCategoryId { get; set; }
        public IconCategory IconCategory { get; set; }

    }
}
