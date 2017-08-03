using iugu.net.Lib;
using iugu.net.Entity;
using iugu.net.Request;
using iugu.net.Response;
using NUnit.Framework;
using System.Threading.Tasks;
using iugu.net.IntegratedTests.DataBuilders;

namespace iugu.net.IntegratedTests
{
    [TestFixture]
    public class ChargeIntegratedTests
    {
        [Test]
        public async Task Create_a_valid_charge_of_type_bank_slip()
        {
            // Arrange
            var chargeRequest = new ChargeRequestMessage
            {
                Method = Constants.PaymentMethod.BANK_SLIP,
                CustomerId = "31F26DC9D613403B837B678335B2CCB0",
                Email = "anyemail@gmail.com",
                InvoiceItems = new InvoiceItem[] { new InvoiceItem { Description = "Mensalidade", PriceCents = 100000, Quantity = 1 } },
                PayerCustomer = PayerModelDataBuilder.CreateValid()
            };

            ChargeResponseMessage chargeTokenResponse;

            // Act
            using (var apiClient = new Charge())
            {
                chargeTokenResponse = await apiClient.CreateAsync(chargeRequest).ConfigureAwait(false);
            }

            // Assert
            Assert.That(chargeTokenResponse.Success, Is.True);
            Assert.That(chargeTokenResponse.Url, Is.Not.Empty);
        }
    }
}
