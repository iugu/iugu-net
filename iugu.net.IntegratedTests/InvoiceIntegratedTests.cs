using iugu.net.Entity;
using iugu.net.Lib;
using iugu.net.Request;
using NUnit.Framework;
using System;
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
        public async Task Create_a_new_invoice_and_cancel_after()
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
                var current = await apiInvoice.CreateAsync("anyemail@gmail.com.br", invoiceDate, invoiceItems, null, null, null, 0, 0, null, false, subscription.id, null, null, customVariables);

                invoice = await apiInvoice.DuplicateAsync(current.id, new Request.InvoiceDuplicateRequestMessage(newDate)).ConfigureAwait(false);
            };

            // Assert
            Assert.That(invoice, Is.Not.Null);
        }

        [Test]
        public async Task Create_a_new_invoice_with_custom_api_token()
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
                var invoiceRequest = new InvoiceRequestMessage("anyemail@gmail.com.br", invoiceDate, invoiceItems)
                {
                    SubscriptionId = subscription.id,
                    CustomVariables = customVariables.ToArray(),
                };

                invoice = await apiInvoice.CreateAsync(invoiceRequest, "74c265aedbfaea379bc0148fae9b5526");
            };

            // Assert
            Assert.That(invoice, Is.Not.Null);
        }

        [Test]
        public async Task Create_a_new_invoice_with_custom_api_token_and_cancel_after()
        {
            // Arrange
            const string customApiToken = "74c265aedbfaea379bc0148fae9b5526";
            InvoiceModel invoice;
            InvoiceModel cancelInvoice;

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
                var subscription = await apiSubscription.CreateAsync(new SubscriptionRequestMessage(customerResponse.id)
                {
                    PlanId = plan.identifier,
                    IsCreditBased = false,
                    CustomVariables = customVariables,
                    Subitems = subscriptionItems
                }, customApiToken);

                var invoiceItems = new Item[] { new Item { description = "Mensalidade", price_cents = 65000, quantity = 1 } };
                var request = new InvoiceRequestMessage("anyemail@gmail.com.br", invoiceDate, invoiceItems)
                {
                    SubscriptionId = subscription.id,
                    CustomVariables = customVariables.ToArray()
                };

                var current = await apiInvoice.CreateAsync(request, customApiToken);
                invoice = await apiInvoice.DuplicateAsync(current.id, new InvoiceDuplicateRequestMessage(newDate), customApiToken).ConfigureAwait(false);
                cancelInvoice = await apiInvoice.GetAsync(current.id, customApiToken).ConfigureAwait(false);
            };

            // Assert
            Assert.That(invoice, Is.Not.Null);
            Assert.That(invoice.status, Is.EqualTo(Constants.InvoiceStatus.PENDING));
            Assert.That(cancelInvoice.status, Is.EqualTo(Constants.InvoiceStatus.CANCELED));
        }
    }
}
