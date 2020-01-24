using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrandBook.Core.Services.Subscriptions
{
    public interface ISubscriptionService
    {
        bool HasValidSubscription(string userId);
        string GenerateSubscriptionKey();
    }
}
