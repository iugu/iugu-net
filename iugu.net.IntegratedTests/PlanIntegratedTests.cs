using iugu.net.Entity;
using iugu.net.Lib;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iugu.net.IntegratedTests
{
    class PlanIntegratedTests
    {
        [Test]
        public async Task Create_a_valid_plan()
        {
            // Arrange
            var radomPlan = Guid.NewGuid().ToString();
            var planId = $"{radomPlan}-Plan";
            PlanModel plan;

            // Act
            using (var apiPlan = new Plans())
            {
                plan = await apiPlan.CreateAsync($"{radomPlan}-12x", planId, 1, Constants.GenerateCycleType.MONTLY,
                    0, "BRL", null, null, Constants.PaymentMethod.BANK_SLIP).ConfigureAwait(false);
            };

            // Assert
            Assert.That(plan, Is.Not.Null);
            Assert.That(plan.identifier, Is.EqualTo(planId));
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
                await apiPlan.CreateAsync($"{radomPlan}-12x", planId, 1, Constants.GenerateCycleType.MONTLY,
                    0, "BRL", null, null, Constants.PaymentMethod.BANK_SLIP).ConfigureAwait(false);

                plan = await apiPlan.GetByIdentifierAsync(planId).ConfigureAwait(false);
            };

            // Assert
            Assert.That(plan, Is.Not.Null);
            Assert.That(plan.identifier, Is.EqualTo(planId));
        }
    }
}
