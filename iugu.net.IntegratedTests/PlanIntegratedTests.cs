using iugu.net.Entity;
using iugu.net.Lib;
using iugu.net.Request;
using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace iugu.net.IntegratedTests
{
    class PlanIntegratedTests
    {
        [Test]
        public async Task List_all_plans()
        {
            // Arrange
            var radomPlan = Guid.NewGuid().ToString();
            var planId = $"{radomPlan}-Plan";
            int originalCountPlans;
            var newCountPlans = 0;

            // Act
            using (var apiPlan = new Plans())
            {
                var planRequest = new PlanRequestMessage($"{radomPlan}-12x", planId, 1, PlanIntervalType.Monthly, 0)
                {
                    PaymentMethod = Constants.PaymentMethod.BANK_SLIP
                };

                var currentPlans = await apiPlan.GetAllAsync("2e90be2d765e374bed509f2d7676a921").ConfigureAwait(false);
                originalCountPlans = currentPlans.TotalItems;
                var response = await apiPlan.CreateAsync(planRequest, "2e90be2d765e374bed509f2d7676a921").ConfigureAwait(false);

                var newPlan = await apiPlan.GetByIdentifierAsync(response.Identifier).ConfigureAwait(false);
                newCountPlans = newPlan != null ? originalCountPlans + 1 : newCountPlans;
            };

            // Assert
            Assert.That(newCountPlans, Is.GreaterThan(originalCountPlans));
        }

        [Test]
        public async Task Create_a_valid_plan()
        {
            // Arrange
            var radomPlan = Guid.NewGuid().ToString();
            var planId = $"{radomPlan}-Plan";
            PlanModel plan;
            PlanRequestMessage prm = new PlanRequestMessage($"{radomPlan}-12x",planId,1,PlanIntervalType.Monthly,0,CurrencyType.BRL);
            // Act
            using (var apiPlan = new Plans())
            {
                plan = await apiPlan.CreateAsync(prm).ConfigureAwait(false);
            };

            // Assert
            Assert.That(plan, Is.Not.Null);
            Assert.That(plan.Identifier, Is.EqualTo(planId));
        }

        [Test]
        public async Task Create_a_valid_plan_with_custom_api_token()
        {
            // Arrange
            var radomPlan = Guid.NewGuid().ToString();
            var planId = $"{radomPlan}-Plan";
            PlanModel plan;

            // Act
            using (var apiPlan = new Plans())
            {
                var planRequest = new PlanRequestMessage($"{radomPlan}-12x", planId, 1, PlanIntervalType.Monthly, 0)
                {
                    PaymentMethod = Constants.PaymentMethod.BANK_SLIP
                };

                plan = await apiPlan.CreateAsync(planRequest, "74c265aedbfaea379bc0148fae9b5526").ConfigureAwait(false);
            };

            // Assert
            Assert.That(plan, Is.Not.Null);
            Assert.That(plan.Identifier, Is.EqualTo(planId));
        }


        [Test]
        public async Task Get_plan_by_identifier()
        {
            // Arrange
            var radomPlan = Guid.NewGuid().ToString();
            var planId = $"{radomPlan}-Plan";
            PlanModel plan;

            // Act
            using (var apiPlan = new Plans())
            {
                PlanRequestMessage prm = new PlanRequestMessage($"{radomPlan}-12x", planId, 1, PlanIntervalType.Monthly, 0, CurrencyType.BRL);
                await apiPlan.CreateAsync(prm).ConfigureAwait(false);

                plan = await apiPlan.GetByIdentifierAsync(planId).ConfigureAwait(false);
            };

            // Assert
            Assert.That(plan, Is.Not.Null);
            Assert.That(plan.Identifier, Is.EqualTo(planId));
        }
    }
}
