using iugu.net.Entity;
using iugu.net.Lib;
using iugu.net.Response;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FluentAssertions;

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
            createdPlan = await PlanApi.CreateAsync($"{radomPlan}-12x", $"{radomPlan}-Plan", 1, "months", 0, "BRL", null, null, Constants.PaymentMethod.BANK_SLIP).ConfigureAwait(false);

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
            var subscriptionItems = new List<SubscriptionSubitem> { new SubscriptionSubitem { description = "Mensalidade", price_cents = 65000, quantity = 1, recurrent = true } };
            var request = new Request.SubscriptionRequestMessage(createdCustomer.id)
            {
                PlanId = createdPlan.identifier,
                IsCreditBased = false,
                Subitems = subscriptionItems
            };

            // Act
            var subscription = await SubscriptionApi.CreateAsync(request).ConfigureAwait(false);

            // Assert
            Assert.That(subscription.id, Is.Not.Null);
            Assert.That(subscription.plan_identifier, Is.EqualTo(createdPlan.identifier));
        }


        [Test]
        public async Task Suspended_a_subscription()
        {
            // Arrange 
            var subscriptionRequest = await SubscriptionApi.GetAsync<PaggedResponseMessage<SubscriptionModel>>().ConfigureAwait(false);
            var subscriptionItems = new List<SubscriptionSubitem> { new SubscriptionSubitem { description = "Mensalidade", price_cents = 65000, quantity = 1, recurrent = true } };
            var request = new Request.SubscriptionRequestMessage(createdCustomer.id)
            {
                PlanId = createdPlan.identifier,
                IsCreditBased = false,
                Subitems = subscriptionItems
            };
            var subscription = await SubscriptionApi.CreateAsync(request).ConfigureAwait(false);

            // Act
            var suspendendSubscription = await SubscriptionApi.SuspendAsync(subscription.id).ConfigureAwait(false);

            // Assert
            Assert.That(suspendendSubscription.suspended, Is.True);
        }

        [Test]
        public async Task Change_a_subscription_plan()
        {
            // Arrange 
            var subscriptionRequest = await SubscriptionApi.GetAsync<PaggedResponseMessage<SubscriptionModel>>().ConfigureAwait(false);
            var subscriptionItems = new List<SubscriptionSubitem> { new SubscriptionSubitem { description = "Mensalidade", price_cents = 65000, quantity = 1, recurrent = true } };
            var request = new Request.SubscriptionRequestMessage(createdCustomer.id)
            {
                PlanId = createdPlan.identifier,
                IsCreditBased = false,
                Subitems = subscriptionItems
            };
            var currentSubscription = await SubscriptionApi.CreateAsync(request).ConfigureAwait(false);

            var radomPlan = Guid.NewGuid().ToString();
            var newdPlan = await PlanApi.CreateAsync($"{radomPlan}-12x", $"{radomPlan}-Plan", 1, "months", 0, "BRL", null, null, Constants.PaymentMethod.BANK_SLIP).ConfigureAwait(false);

            // Act
            var suspendendSubscription = await SubscriptionApi.ChangePlanAsync(currentSubscription.id, newdPlan.identifier).ConfigureAwait(false);

            // Assert
            suspendendSubscription.Should().NotBeSameAs(currentSubscription);
        }
    }
}
