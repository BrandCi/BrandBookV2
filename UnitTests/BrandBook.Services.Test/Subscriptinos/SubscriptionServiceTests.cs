using BrandBook.Core.Services.Subscriptions;
using BrandBook.Services.Resources;
using BrandBook.Services.Subscriptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BrandBook.Services.Test.Subscriptinos
{
    [TestClass]
    public class SubscriptionServiceTests
    {
        private ISubscriptionService _subscriptionService;

        [TestInitialize]
        public void TestInitialization()
        {
            _subscriptionService = new SubscriptionService();
        }


        [TestMethod]
        public void GenerateSubscriptionKey_WhenGenerated_EnsureLengthValidity()
        {
            var subscriptionKey = _subscriptionService.GenerateSubscriptionKey();

            Assert.IsTrue(subscriptionKey.Length == 8);
        }

        [TestMethod]
        public void GenerateSubscriptionKey_WhenGenerated_EnsureRandomnessValidity()
        {
            var subscriptionKey1 = _subscriptionService.GenerateSubscriptionKey();
            var subscriptionKey2 = _subscriptionService.GenerateSubscriptionKey();

            Assert.AreNotSame(subscriptionKey1, subscriptionKey2);
        }
    }
}
