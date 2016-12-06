using iugu.net.Entity;
using iugu.net.Lib;
using iugu.net.Response;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FluentAssertions;
using iugu.net.Request;

namespace iugu.net.IntegratedTests
{
    public class SubscriptionIntegratedTests
    {
        private Plans PlanApi { get; set; }
        private Subscription SubscriptionApi { get; set; }
        private Customer CustomerApi { get; set; }

        private PlanModel createdPlan { get; set; }
        private CustomerModel createdCustomer { get; set; }

        [OneTimeSetUp]
        public async Task PrepareTests()
        {
            PlanApi = new Plans();
            SubscriptionApi = new Subscription();
            CustomerApi = new Customer();

            var radomPlan = Guid.NewGuid().ToString();
            PlanRequestMessage prm = new PlanRequestMessage($"{radomPlan}-12x", radomPlan, 1, PlanIntervalType.Monthly, 0, CurrencyType.BRL);
            createdPlan = await PlanApi.CreateAsync(prm).ConfigureAwait(false);

            var customer = new Request.CustomerRequestMessage
            {
                Email = "anyemail@email.com",
                Name = "Client Name",
            };

            createdCustomer = await CustomerApi.CreateAsync(customer, null).ConfigureAwait(false);
        }

        [OneTimeTearDown]
        public async Task FinalizeTests()
        {
            PlanApi.Dispose();
            SubscriptionApi.Dispose();
            CustomerApi.Dispose();
        }

        [Test]
        public async Task Create_a_new_subscription()
        {
            // Arrange 
            var subscriptionRequest = await SubscriptionApi.GetAsync<PaggedResponseMessage<SubscriptionModel>>().ConfigureAwait(false);
            var subscriptionItems = new List<SubscriptionSubitem> { new SubscriptionSubitem { Description = "Mensalidade", PriceCents = 65000, Quantity = 1, Recurrent = true } };
            var request = new Request.SubscriptionRequestMessage(createdCustomer.ID)
            {
                PlanId = createdPlan.Identifier,
                IsCreditBased = false,
                Subitems = subscriptionItems
            };

            // Act
            var subscription = await SubscriptionApi.CreateAsync(request).ConfigureAwait(false);

            // Assert
            Assert.That(subscription.ID, Is.Not.Null);
            Assert.That(subscription.PlanIdentifier, Is.EqualTo(createdPlan.Identifier));
        }


        [Test]
        public async Task Suspended_a_subscription()
        {
            // Arrange 
            var subscriptionRequest = await SubscriptionApi.GetAsync<PaggedResponseMessage<SubscriptionModel>>().ConfigureAwait(false);
            var subscriptionItems = new List<SubscriptionSubitem> { new SubscriptionSubitem { Description = "Mensalidade", PriceCents = 65000, Quantity = 1, Recurrent = true } };
            var request = new Request.SubscriptionRequestMessage(createdCustomer.ID)
            {
                PlanId = createdPlan.Identifier,
                IsCreditBased = false,
                Subitems = subscriptionItems
            };
            var subscription = await SubscriptionApi.CreateAsync(request).ConfigureAwait(false);

            // Act
            var suspendendSubscription = await SubscriptionApi.SuspendAsync(subscription.ID).ConfigureAwait(false);

            // Assert
            Assert.That(suspendendSubscription.Suspended, Is.True);
        }

        [Test]
        public async Task Change_a_subscription_plan()
        {
            // Arrange 
            var subscriptionRequest = await SubscriptionApi.GetAsync<PaggedResponseMessage<SubscriptionModel>>().ConfigureAwait(false);
            var subscriptionItems = new List<SubscriptionSubitem> { new SubscriptionSubitem { Description = "Mensalidade", PriceCents = 65000, Quantity = 1, Recurrent = true } };
            var request = new Request.SubscriptionRequestMessage(createdCustomer.ID)
            {
                PlanId = createdPlan.Identifier,
                IsCreditBased = false,
                Subitems = subscriptionItems
            };
            var currentSubscription = await SubscriptionApi.CreateAsync(request).ConfigureAwait(false);

            var radomPlan = Guid.NewGuid().ToString();
            PlanRequestMessage prm = new PlanRequestMessage($"{radomPlan}-12x", radomPlan, 1, PlanIntervalType.Monthly, 0, CurrencyType.BRL);
            var newdPlan = await PlanApi.CreateAsync(prm).ConfigureAwait(false);

            // Act
            var suspendendSubscription = await SubscriptionApi.ChangePlanAsync(currentSubscription.ID, newdPlan.Identifier).ConfigureAwait(false);

            // Assert
            suspendendSubscription.Should().NotBeSameAs(currentSubscription);
        }
    }
}
