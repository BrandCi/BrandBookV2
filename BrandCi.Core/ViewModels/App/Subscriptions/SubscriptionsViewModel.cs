using System.Collections;
using System.Collections.Generic;

namespace BrandCi.Core.ViewModels.App.Subscriptions
{
    public class SubscriptionsViewModel : IEnumerable<SingleSubscriptionViewModel>
    {

        public List<SingleSubscriptionViewModel> Subscriptions { get; set; }
        public bool HasValidSubscription { get; set; }


        public IEnumerator<SingleSubscriptionViewModel> GetEnumerator()
        {
            return Subscriptions.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

    }
}
