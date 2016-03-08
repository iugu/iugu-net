using iugu.net.Entity;
using iugu.net.Lib;
using NUnit.Framework;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace iugu.net.IntegratedTests
{
    [TestFixture]
    public class InvoiceIntegratedTests
    {
        [Test]
        public async Task Create_a_valid_invoice()
        {
            // Arrange
            InvoiceModel invoice;

            var customVariables = new List<CustomVariables>
            {
                new CustomVariables { name = "TaxaIugu", value = "2,50" },
                new CustomVariables { name = "TaxaPlataformaEdux", value = "1,00" }
            };

            var invoiceDate = DateTime.Now.AddDays(2);
            var items = new List<InvoiceItem> {
                new InvoiceItem { Description = "Mensalidade", PriceCents = 100000, Quantity = 1 }
            };
            var customer = new Request.CustomerRequestMessage
            {
                Email = "anyemail@email.com",
                Name = "Client Name",
                CustomVariables = customVariables
            };

            // Act
            using (var apiInvoice = new Invoice())
            using (var apiCustomer = new Customer())
            using (var apiSubscription = new Subscription())
            using (var apiPlan = new Plans())
            {
                var customerResponse = await apiCustomer.CreateAsync(customer, null).ConfigureAwait(false);
                var radomPlan = Guid.NewGuid().ToString();
                var plan = await apiPlan.CreateAsync($"{radomPlan}-12x", $"{radomPlan}-Plan", 1, "months", 0, "BRL", null, null, Constants.PaymentMethod.BANK_SLIP).ConfigureAwait(false);
                var subscriptionItems = new List<SubscriptionSubitem> { new SubscriptionSubitem { description = "Mensalidade", price_cents = 65000, quantity = 1, recurrent = true } };
                var subscription = await apiSubscription.CreateAsync(new Request.SubscriptionRequestMessage(customerResponse.id)
                {
                    PlanId = plan.identifier,
                    IsCreditBased = false,
                    CustomVariables = customVariables,
                    Subitems = subscriptionItems
                });

                var invoiceItems = new Item[] { new Item { description = "Mensalidade", price_cents = 65000, quantity = 1 } };
                invoice = await apiInvoice.CreateAsync("anyemail@gmail.com.br", invoiceDate, invoiceItems, null, null, null, 0, 0, null, false, subscription.id, null, null, customVariables);
            };

            // Assert
            Assert.That(invoice, Is.Not.Null);
            Assert.That(invoice.due_date, Does.Contain(invoiceDate.ToString("yyyy-MM-dd")));
        }

        [Test]
        public async Task Create_a_new_invoice_cancel_last()
        {
            // Arrange
            InvoiceModel invoice;

            var customVariables = new List<CustomVariables>
            {
                new CustomVariables { name = "TaxaIugu", value = "2,50" },
                new CustomVariables { name = "TaxaPlataformaEdux", value = "1,00" }
            };

            var invoiceDate = DateTime.Now.AddDays(2);
            var newDate = invoiceDate.AddDays(3).ToString("dd/MM/yyyy");

            var items = new List<InvoiceItem> {
                new InvoiceItem { Description = "Mensalidade", PriceCents = 100000, Quantity = 1 }
            };
            var customer = new Request.CustomerRequestMessage
            {
                Email = "anyemail@email.com",
                Name = "Client Name",
                CustomVariables = customVariables
            };

            // Act
            using (var apiInvoice = new Invoice())
            using (var apiCustomer = new Customer())
            using (var apiSubscription = new Subscription())
            using (var apiPlan = new Plans())
            {
                var customerResponse = await apiCustomer.CreateAsync(customer, null).ConfigureAwait(false);
                var radomPlan = Guid.NewGuid().ToString();
                var plan = await apiPlan.CreateAsync($"{radomPlan}-12x", $"{radomPlan}-Plan", 1, "months", 0, "BRL", null, null, Constants.PaymentMethod.BANK_SLIP).ConfigureAwait(false);
                var subscriptionItems = new List<SubscriptionSubitem> { new SubscriptionSubitem { description = "Mensalidade", price_cents = 65000, quantity = 1, recurrent = true } };
                var subscription = await apiSubscription.CreateAsync(new Request.SubscriptionRequestMessage(customerResponse.id)
                {
                    PlanId = plan.identifier,
                    IsCreditBased = false,
                    CustomVariables = customVariables,
                    Subitems = subscriptionItems
                });

                var invoiceItems = new Item[] { new Item { description = "Mensalidade", price_cents = 65000, quantity = 1 } };
                var current = invoice = await apiInvoice.CreateAsync("anyemail@gmail.com.br", invoiceDate, invoiceItems, null, null, null, 0, 0, null, false, subscription.id, null, null, customVariables);

                invoice = await apiInvoice.DuplicateAsync(invoice.id, new Request.InvoiceDuplicateRequestMessage(newDate)).ConfigureAwait(false);
            };

            // Assert
            Assert.That(invoice, Is.Not.Null);
        }


        [Test]
        public async Task When_create_a_subscription_with_sub_items_the_subitens_should_be_a_new_invoice()
        {
            // Arrange
            InvoiceModel invoice;

            var customVariables = new List<CustomVariables>
            {
                new CustomVariables { name = "TaxaIugu", value = "2,50" },
                new CustomVariables { name = "TaxaPlataformaEdux", value = "1,00" }
            };

            var invoiceDate = DateTime.Now.AddDays(2);
            var newDate = invoiceDate.AddDays(3).ToString("dd/MM/yyyy");

            var items = new List<InvoiceItem> {
                new InvoiceItem { Description = "Mensalidade", PriceCents = 100000, Quantity = 1 }
            };
            var customer = new Request.CustomerRequestMessage
            {
                Email = "anyemail@email.com",
                Name = "Client Name",
                CustomVariables = customVariables
            };

            // Act
            using (var apiInvoice = new Invoice())
            using (var apiCustomer = new Customer())
            using (var apiSubscription = new Subscription())
            using (var apiPlan = new Plans())
            {
                var customerResponse = await apiCustomer.CreateAsync(customer, null).ConfigureAwait(false);
                var radomPlan = Guid.NewGuid().ToString();
                var plan = await apiPlan.CreateAsync($"{radomPlan}-12x", $"{radomPlan}-Plan", 1, "months", 0, "BRL", null, null, Constants.PaymentMethod.BANK_SLIP).ConfigureAwait(false);
                var subscriptionItems = new List<SubscriptionSubitem> { new SubscriptionSubitem { description = "Mensalidade", price_cents = 65000, quantity = 1, recurrent = true } };
                var subscription = await apiSubscription.CreateAsync(new Request.SubscriptionRequestMessage(customerResponse.id)
                {
                    PlanId = plan.identifier,
                    IsCreditBased = false,
                    CustomVariables = customVariables,
                    Subitems = subscriptionItems,
                    ExpiresAt = DateTime.Now.AddDays(1)
                });

                invoice = await apiInvoice.CaptureAsync(subscription.subitems.First().id).ConfigureAwait(false);
            };

            // Assert
            Assert.That(invoice, Is.Not.Null);
        }
    }
}
