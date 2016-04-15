using iugu.net.Entity;
using iugu.net.Filters;
using iugu.net.Lib;
using iugu.net.Response;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iugu.net.IntegratedTests
{
    public class ReportsIntegratedTests
    {
        [Test]
        [Ignore("Funciona apenas com o live token")]
        public async Task Get_request_withdraw_report_data()
        {
            // Arrange
            PaggedResponseMessage<RequestWithdrawResponseMessage> response;

            // Act && Assert
            using (var client = new Reports())
            {
                var filter = new QueryStringFilter
                {
                    MaxResults = 10,
                    Since = DateTime.UtcNow.AddDays(-1),
                    SortBy = new OrderingFilter { FieldName = "updated_at", Order = ResultOrderType.Descending }
                };


                response = await client.ReportRequestWithdrawAsync("4e7c941b8647ea37faa75d3037cfab19", filter).ConfigureAwait(false);
                Assert.That(response.TotalItems, Is.GreaterThan(0));
                Assert.That(response.Items, Is.Not.Empty);
            }
        }

        [Test]
        [Ignore("Funciona apenas com o live token")]
        public async Task Get_all_transfers()
        {
            // Arrange
            TransfersReportResponseMessage response;

            // Act && Assert
            using (var client = new Reports())
            {
                response = await client.ReportTransfersHistoryAsync("").ConfigureAwait(false);
                Assert.That(response.TransfersReceived, Is.Not.Empty);
                Assert.That(response.TransfersSent, Is.Not.Empty);
            }
        }
    }
}
