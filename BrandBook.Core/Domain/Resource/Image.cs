namespace BrandBook.Core.Domain.Resource
{
    public class Image : BaseEntity
    {

        public string Name { get; set; }
        public string ContentType { get; set; }
        public int Category { get; set; }

    }
}
