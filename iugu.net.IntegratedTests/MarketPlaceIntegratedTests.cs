using iugu.net.Entity;
using iugu.net.IntegratedTests.Stubs;
using iugu.net.Lib;
using iugu.net.Request;
using iugu.net.Response;
using NUnit.Framework;
using Ploeh.AutoFixture;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using iugu.net.Interfaces;
using Newtonsoft.Json;
using iugu.net.Filters;
using System.Linq;
using System.IO;

namespace iugu.net.IntegratedTests
{
    [TestFixture]
    public class MarketPlaceIntegratedTests
    {
        [Test]
        public async Task Create_a_under_acoount_with_success()
        {
            // Arrange
            var request = new SubAccountRequestMessage { Name = "any_market_place_under_account@gmail.com", CommissionPercent = 10 };
            SubAccountResponseMessage response;

            var responseContent = JsonConvert.SerializeObject(new Fixture().Build<AccountModel>()
                                                                           .With(a => a.Name, request.Name)
                                                                           .Create());

            // Act
            using (IHttpClientWrapper stubHttpClient = new StubHttpClient(new StringContent(responseContent, Encoding.UTF8, "application/json")))
            using (IApiResources apiClient = new APIResource(stubHttpClient))
            using (var client = new MarketPlace(apiClient))
            {
                response = await client.CreateUnderAccountAsync(request).ConfigureAwait(false);
            }

            // Assert
            Assert.That(response.Name, Is.EqualTo(request.Name));
        }

        [Test]
        public async Task Get_all_accounts_in_marketplace_with_success()
        {
            // Arrange
            var request = new SubAccountRequestMessage { Name = "any_market_place_under_account@gmail.com", CommissionPercent = 10 };
            MarketplaceAccoutsResponseMessage response;


            // Act
            using (var client = new MarketPlace())
            {
                response = await client.GetAllSubAccountsAsync().ConfigureAwait(false);
            }

            // Assert
            Assert.That(response, Is.Not.Null);
        }

        [Test]
        [Ignore("Apenas com Live Api Token")]
        public async Task Get_all_accounts_in_marketplace_paggeed_with_success()
        {
            // Arrange
            PaggedResponseMessage<MarketPlaceAccountItem> response;
            var filter = new QueryStringFilter
            {
                MaxResults = 1000,
                SortBy = new OrderingFilter(FieldSort.AccountName, ResultOrderType.Ascending)
            };

            // Act
            using (var client = new MarketPlace())
            {
                response = await client.GetAllSubAccountsAsync("74c265aedbfaea379bc0148fae9b5526", filter).ConfigureAwait(false);
            }

            // Assert
            Assert.That(response, Is.Not.Null);
        }
    }
}
