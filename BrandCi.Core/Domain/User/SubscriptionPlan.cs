namespace BrandBook.Core.Domain.User
{
    public class SubscriptionPlan : BaseEntity
    {

        public string Name { get; set; }
        public int AmountOfBrands { get; set; }
        public int ValidityInMonths { get; set; }
        public double PricePerMonth { get; set; }

    }
}
