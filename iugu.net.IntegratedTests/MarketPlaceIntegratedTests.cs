using iugu.net.Lib;
using iugu.net.Request;
using iugu.net.Response;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iugu.net.IntegratedTests
{
    [TestFixture]
    public class MarketPlaceIntegratedTests
    {
        [Test]
        [Ignore("É necessário que setar seu token de marketplace no app.config")]
        public async Task Create_a_under_acoount_with_success()
        {
            // Arrange
            var request = new AccountRequestMessage { Name = "any_market_place_under_account@gmail.com", CommissionPercent = 10 };
            AccountResponseMessage response;

            // Act
            using (var client = new MarketPlace())
            {
                response = await client.CreateUnderAccountAsync(request).ConfigureAwait(false);
            }

            // Assert
            Assert.That(response.AccountId, Is.Not.Null);
            Assert.That(response.Name, Is.EqualTo("any_market_place_under_account@gmail.com"));
        }
    }
}
