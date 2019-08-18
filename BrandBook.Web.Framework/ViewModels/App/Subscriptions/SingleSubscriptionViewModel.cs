using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrandBook.Web.Framework.ViewModels.App.Subscriptions
{
    public class SingleSubscriptionViewModel
    {
        public int Id { get; set; }
        public string Key { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public bool IsPaid { get; set; }
        public bool IsActive { get; set; }


        // subscription plan
        public string Name { get; set; }
        public int AmountOfBrands { get; set; }
        public int ValidityInMonths { get; set; }
        public double PricePerMonth { get; set; }
    }
}
