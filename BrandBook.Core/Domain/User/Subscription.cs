using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrandBook.Core.Domain.User
{
    public class Subscription : BaseEntity
    {

        public DateTime StartDateTime { get; set; }
        public bool IsPaid { get; set; }
        public bool IsActive { get; set; }

        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }

        public int SubscriptionPlanId { get; set; }
        public SubscriptionPlan SubscriptionPlan { get; set; }
    }
}
