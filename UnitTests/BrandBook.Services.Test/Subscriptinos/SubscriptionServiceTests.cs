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
        private string _subscriptionKeyChars;

        [TestInitialize]
        public void TestInitialization()
        {
            _subscriptionService = new SubscriptionService();
            _subscriptionKeyChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
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

        [TestMethod]
        public void GenerateSubscriptionKey_WhenGenerated_EnsureComplexityValidity()
        {
            var isCharInPool = false;
            var subscriptionKey = _subscriptionService.GenerateSubscriptionKey();

            foreach (var subscriptionKeyChar in subscriptionKey)
            {
                if (!_subscriptionKeyChars.Contains(subscriptionKeyChar.ToString())) break;

                isCharInPool = true;
            }

            Assert.IsTrue(isCharInPool);
        }
    }
}
