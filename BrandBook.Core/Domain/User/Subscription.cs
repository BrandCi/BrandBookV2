﻿using System;

namespace BrandBook.Core.Domain.User
{
    public class Subscription : BaseEntity
    {
        public string Key { get; set; }
        public DateTime StartDateTime { get; set; }
        public bool IsPaid { get; set; }
        public bool IsActive { get; set; }

        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }

        public int SubscriptionPlanId { get; set; }
        public SubscriptionPlan SubscriptionPlan { get; set; }
    }
}
