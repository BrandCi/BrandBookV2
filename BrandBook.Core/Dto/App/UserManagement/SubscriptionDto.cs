using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrandBook.Core.Dto.App.UserManagement
{
    public class SubscriptionDto
    {
        public int Id { get; set; }
        public string Key { get; set; }
        public bool IsActive { get; set; }
        public string SubscriptionPlanName { get; set; }
        public double PricePerMonth { get; set; }

        public string StartDateTime { get; set; }
        public string EndDateTime { get; set; }

        public int PossibleAmountOfBrands { get; set; }
        public int CurrentAmountOfBrands { get; set; }

        public string PaidOrPending { get; set; }
        public string ActiveOrInactive { get; set; }
    }
}
