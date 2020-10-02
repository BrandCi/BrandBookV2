namespace BrandCi.Core.Domain.System
{
    public class Setting : BaseEntity
    {
        public string Key { get; set; }
        public string Value { get; set; }

        public Category Category { get; set; }
        public AccessLevel AccessLevel { get; set; }


    }
}
