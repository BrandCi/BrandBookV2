﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BrandBook.Core.Domain.User;

namespace BrandBook.Core.Services.Subscriptions
{
    public interface ISubscriptionService
    {
        bool HasValidSubscription(string userId);
        bool AllowedToCreateNewBrands(string userId);
        string GenerateSubscriptionKey();
        DateTime GetSubscriptionEndDate(Subscription subscription);
    }
}
