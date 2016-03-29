using iugu.net.Lib;
using iugu.net.Request;
using iugu.net.Response;
using NUnit.Framework;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using iugu.net.Entity;
using Ploeh.AutoFixture;
using Newtonsoft.Json;
using iugu.net.IntegratedTests.Stubs;
using System.Net.Http;

namespace iugu.net.IntegratedTests
{
    [TestFixture]
    public class AccountIntegratedTests
    {
        private AccountResponseMessage response;
        private VerifyAccountResponseMessage expectedResponse;

        [OneTimeSetUp]
        public async Task PrepareTests()
        {
            var request = new AccountRequestMessage { Name = "test_account@gmail.com", CommissionPercent = 10 };

            var responseContent = JsonConvert.SerializeObject(new Fixture().Build<AccountModel>()
                                                                           .With(a => a.Name, request.Name)
                                                                           .Create());

            using (IHttpClientWrapper stubHttpClient = new StubHttpClient(new StringContent(responseContent, Encoding.UTF8, "application/json")))
            using (IApiResources apiClient = new APIResource(stubHttpClient))
            using (var client = new MarketPlace(apiClient))
            {
                response = await client.CreateUnderAccountAsync(request).ConfigureAwait(false);
            }

            var address = new Fixture().Build<AddressModel>().Create();
            var fullAddress = $"{address.Street}, {address.Number} - {address.City} - {address.State}/{address.Country}";
            expectedResponse = new VerifyAccountResponseMessage
            {
                AccountId = response.AccountId,
                Data = new AccountModel(fullAddress)
                {
                    PriceRange = "Entre R$ 100,00 e R$ 500,00",
                    PhysicalProducts = false,
                    BusinessDescription = "Negócios online",
                    PersonType = Constants.PersonType.INDIVIDUAL_PERSON,
                    AcceptAutomaticTransfer = true,
                    CPF = "42753418306",
                    Name = "Meu Cliente",
                    Phone = "2199999999",
                    Bank = Constants.SupportedBanks.CAIXA_ECONOMICA,
                    AccountType = Constants.BankAccountType.CHECKING_ACCOUNT,
                    BankAgency = "1520",
                    BankAccountNumber = "00100021066-6"
                },
            };
        }


        [Test]
        public async Task Verify_if_account_is_valid()
        {
            // Arrange
            var requestAccountVerify = new VerifyAccountRequestMessage(expectedResponse.Data, true);
            VerifyAccountResponseMessage verifyAccountResponse;
            var responseContent = JsonConvert.SerializeObject(expectedResponse);

            // Act
            using (IHttpClientWrapper stubHttpClient = new StubHttpClient(new StringContent(responseContent, Encoding.UTF8, "application/json")))
            using (IApiResources apiClient = new APIResource(stubHttpClient))
            using (var client = new Account(apiClient))
            {
                verifyAccountResponse = await client.VerifyUnderAccountAsync(requestAccountVerify, response.AccountId, response.UserToken).ConfigureAwait(false);
            }

            // Assert
            Assert.That(expectedResponse.Data.Name, Is.EqualTo(verifyAccountResponse.Data.Name));
            Assert.That(expectedResponse.Data.Address, Is.EqualTo(verifyAccountResponse.Data.Address));
            Assert.That(expectedResponse.AccountId, Is.EqualTo(verifyAccountResponse.AccountId));

        }

        [Test]
        public async Task Get_a_created_account()
        {
            // Arrange
            var requestAccountVerify = new VerifyAccountRequestMessage(expectedResponse.Data, true);
            var request = new Fixture().Build<GetAccountResponseMessage>().Create();
            var responseContent = JsonConvert.SerializeObject(request);

            GetAccountResponseMessage response;

            // Act
            using (IHttpClientWrapper stubHttpClient = new StubHttpClient(new StringContent(responseContent, Encoding.UTF8, "application/json")))
            using (IApiResources apiClient = new APIResource(stubHttpClient))
            using (var client = new Account(apiClient))
            {
                response = await client.GetAsync(request.AccountId, "any-user-token").ConfigureAwait(false);
            }

            // Assert
            response.ShouldBeEquivalentTo(request);
        }


        [Test]
        [Ignore("Necessita do LiveApiToken")]
        public async Task Update_account_configurations_with_success()
        {
            // Arrange
            GetAccountResponseMessage response;
            var request = new AccountConfigurationRequestMessage
            {
                PerDayInterest = true,
                Fines = true,
                LatePaymentFine = 2,
            };

            // Act && Assert
            using (IApiResources apiClient = new APIResource())
            using (var client = new Account(apiClient))
            {
                Assert.DoesNotThrow(async () => { await client.ConfigureAccountAsync(request, "74c265aedbfaea379bc0148fae9b5526").ConfigureAwait(false); });
            }
        }

        [Test]
        [Ignore("Necessita do UserApiToken")]
        public async Task Request_withdraw()
        {
            // Arrange
            AccountRequestWithdrawResponse response;

            // Act && Assert
            using (IApiResources apiClient = new APIResource())
            using (var client = new Account(apiClient))
            {
                var value = 1273.50m;
                response = await client.RequestWithdrawAsync("74c265aedbfaea379bc0148fae9b5526", value, "74c265aedbfaea379bc0148fae9b5526").ConfigureAwait(false);
                Assert.That(response.WithdrawValue, Is.EqualTo(value));
            }
        }

        [Test]
        [Ignore("Necessita de dados bancários reais")]
        public async Task Update_account_information_configurations_with_success()
        {
            // Arrange
            SimpleResponseMessage response;
            var request = new BankVerificationRequestMessage(AvailableBanks.Santander, "1111", "99999999-9", BankAccountTypeAbbreviation.CC, true);
            // Act && Assert
            using (IApiResources apiClient = new APIResource())
            using (var client = new Account(apiClient))
            {
                response = await client.UpdateBankAccoutDataAsync(request, "74c265aedbfaea379bc0148fae9b5526").ConfigureAwait(false);
            }

            Assert.That(response.Success, Is.True);
        }
    }
}
