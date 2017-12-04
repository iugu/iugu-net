using iugu.net.Lib;
using iugu.net.Entity;
using iugu.net.Request;
using iugu.net.Response;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace iugu.net.IntegratedTests
{
    [TestFixture]
    public class ChargeIntegratedTests
    {

        [Test]
        public async Task Create_a_valid_charge_of_type_bank_slip()
        {
            // Arrange
            var expectedResponse = new ChargeResponseMessage
            {
                Errors = new Dictionary<string, object>(),
                Success = true,
                Url = "http://url_do_boleto"
            };

            var chargeRequest = new ChargeRequestMessage
            {
                Method = Constants.PaymentMethod.BANK_SLIP,
                CustomerId = "B78AA2E22FAF4CF994A67380BBFFECD8",
                Email = "anyemail@email.com",
                InvoiceItems = new InvoiceItem[] { new InvoiceItem { Description = "Mensalidade", PriceCents = 100000, Quantity = 1 } },   
                PayerCustomer = new PayerModel
                {
                    Email = "anyemail@email.com",
                    Name = "Client Name",                    
                    CpfOrCnpj = "20250884000140", //from http://www.geradorcnpj.com/                
                    Address = new AddressModel
                    {                        
                        ZipCode = "01310940",
                        Number = "900",
                        City = "São Paulo",
                        State = "SP",
                        Country = "Brasil",
                        Street = "Avenida Paulista"                        
                    }
                    
                }
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
