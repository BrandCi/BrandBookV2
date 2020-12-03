namespace BrandCi.Core.Domain.Brand.Font
{
    public class FontInclusion : BaseEntity
    {
        public string HtmlInline { get; set; }
        public string CssImport { get; set; }
        public string CssProperty { get; set; }
    }
}
