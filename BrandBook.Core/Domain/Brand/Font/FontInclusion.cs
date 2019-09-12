namespace BrandBook.Core.Domain.Brand.Font
{
    public class FontInclusion : BaseEntity
    {
        public string InlineIntegration { get; set; }
        public string CssImport { get; set; }
        public string CssProperty { get; set; }

        public Font Font { get; set; }
    }
}
