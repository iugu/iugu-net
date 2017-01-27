using iugu.net.Entity;
using iugu.net.Filters;
using iugu.net.Lib;
using iugu.net.Request;
using iugu.net.Response;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
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
                }).ConfigureAwait(false);

                var invoiceItems = new Item[] { new Item { description = "Mensalidade", price_cents = 65000, quantity = 1 } };
                invoice = await apiInvoice.CreateAsync("anyemail@gmail.com.br", invoiceDate, invoiceItems, null, null, null, 0, 0, null, false, subscription.id, null, null, customVariables).ConfigureAwait(false);
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
                }).ConfigureAwait(false);

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
                }).ConfigureAwait(false);

                var invoiceItems = new Item[] { new Item { description = "Mensalidade", price_cents = 65000, quantity = 1 } };
                var invoiceRequest = new InvoiceRequestMessage("anyemail@gmail.com.br", invoiceDate, invoiceItems)
                {
                    SubscriptionId = subscription.id,
                    CustomVariables = customVariables.ToArray(),
                };

                invoice = await apiInvoice.CreateAsync(invoiceRequest, "74c265aedbfaea379bc0148fae9b5526").ConfigureAwait(false);
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
                }, customApiToken).ConfigureAwait(false);

                var invoiceItems = new Item[] { new Item { description = "Mensalidade", price_cents = 65000, quantity = 1 } };
                var request = new InvoiceRequestMessage("anyemail@gmail.com.br", invoiceDate, invoiceItems)
                {
                    SubscriptionId = subscription.id,
                    CustomVariables = customVariables.ToArray(),
                    Payer = new PayerModel
                    {
                        Address = new AddressModel
                        {
                            City = "São Paulo",
                            Country = "Brasil",
                            State = "São Paulo",
                            Number = "100",
                            Street = "Any Street",
                            ZipCode = "123.123-123"
                        },
                        CpfOrCnpj = "712.652.024-78",
                        Name = "Cliente da IUGU",
                        PhonePrefix = "99",
                        Phone = "9999-9999",
                    },
                    EnableLateFine = true,
                    LatePaymentFine = "2%",
                    EnableProportionalDailyTax = true,
                    PaymentMethod = Constants.PaymentMethod.BANK_SLIP,

                };

                var current = await apiInvoice.CreateAsync(request, customApiToken).ConfigureAwait(false);
                invoice = await apiInvoice.DuplicateAsync(current.id, new InvoiceDuplicateRequestMessage(newDate), customApiToken).ConfigureAwait(false);
                cancelInvoice = await apiInvoice.GetAsync(current.id, customApiToken).ConfigureAwait(false);
            };

            // Assert
            Assert.That(invoice, Is.Not.Null);
            Assert.That(invoice.status, Is.EqualTo(Constants.InvoiceStatus.PENDING));
            Assert.That(cancelInvoice.status, Is.EqualTo(Constants.InvoiceStatus.CANCELED));
        }


        [Test]
        public async Task List_invoices()
        {
            // Arrange
            InvoiceListModel invoices = null;

            // Act
            using (var apiInvoice = new Invoice())
            {
                invoices = await apiInvoice.GetAsync().ConfigureAwait(false);
            };

            // Assert
            Assert.That(invoices, Is.Not.Null);
            Assert.That(invoices?.items, Is.Not.Empty);
        }

        [Test]
        public async Task Resend_invoice_mail()
        {
            // Arrange
            InvoiceListModel invoices = null;
            InvoiceModel resendInvoiceModel = null;
            var resendInvoiceId = "";

            // Act
            using (var apiInvoice = new Invoice())
            {
                invoices = await apiInvoice.GetAsync().ConfigureAwait(false);
                resendInvoiceId = invoices.items.First().id;
                resendInvoiceModel = await apiInvoice.ResendInvoiceMail(resendInvoiceId).ConfigureAwait(false);
            };

            // Assert
            Assert.That(resendInvoiceModel, Is.Not.Null);
            Assert.That(resendInvoiceModel.id, Is.EqualTo(resendInvoiceId));
        }


        [Test]
        public async Task Get_all_invoices_by_custom_api_token()
        {
            // Arrange
            InvoiceListModel invoicesByCustomToken;

            // Act
            using (var apiInvoice = new Invoice())
            {
                invoicesByCustomToken = await apiInvoice.GetAllAsync("74c265aedbfaea379bc0148fae9b5526").ConfigureAwait(false);
            };

            // Assert
            Assert.That(invoicesByCustomToken, Is.Not.Null);
            Assert.That(invoicesByCustomToken.items.Count, Is.GreaterThan(0));
        }

        [Test]
        public async Task Get_all_invoices_pagged_by_custom_api_token()
        {
            // Arrange
            PaggedResponseMessage<InvoiceModel> response;
            var filter = new QueryStringFilter
            {
                MaxResults = 1000,
            };

            // Act
            using (var apiInvoice = new Invoice())
            {
                response = await apiInvoice.GetAllAsync("74c265aedbfaea379bc0148fae9b5526", filter).ConfigureAwait(false);
            };

            // Assert
            Assert.That(response.Items, Is.Not.Null);
            Assert.That(response.TotalItems, Is.GreaterThan(0));
        }

    }
}
