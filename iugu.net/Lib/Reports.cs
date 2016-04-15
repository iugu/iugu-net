using iugu.net.Filters;
using iugu.net.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iugu.net.Lib
{
    public class Reports : IDisposable
    {
        public readonly IApiResources Api;

        public Reports() : this(new APIResource()) { }

        public Reports(IApiResources api)
        {
            Api = api;
        }

        public void Dispose()
        {
            Api.Dispose();
            GC.SuppressFinalize(this);
        }


        /// <summary>
        /// Report com os pedidos de saque realizados e para que conta, sem filtros adicionais
        /// </summary>
        /// <returns>A lista de saques paginada</returns>
        public async Task<PaggedResponseMessage<RequestWithdrawResponseMessage>> ReportRequestWithdrawAsync()
        {
            var retorno = await ReportRequestWithdrawAsync(null, null).ConfigureAwait(false);
            return retorno;
        }

        /// <summary>
        /// Report com os pedidos de saque realizados e para que conta, com filtros e token customizados
        /// </summary>
        /// <param name="customApiToken">todo: describe customApiToken parameter on ReportAsync</param>
        /// <param name="filter">Opções de diltros e ordenação</param>
        /// <returns>A lista de saques paginada</returns>
        public async Task<PaggedResponseMessage<RequestWithdrawResponseMessage>> ReportRequestWithdrawAsync(string customApiToken, QueryStringFilter filter)
        {
            Api.BaseURI = "/withdraw_requests";
            var queryStringFilter = filter?.ToQueryStringUrl();
            var retorno = await Api.GetAsync<PaggedResponseMessage<RequestWithdrawResponseMessage>>(null, queryStringFilter, customApiToken).ConfigureAwait(false);
            Api.BaseURI = string.Empty;
            return retorno;
        }

        /// <summary>
        /// Report com as transferências enviadas e recebidas
        /// </summary>
        /// <returns>A lista de transferência</returns>
        public async Task<TransfersReportResponseMessage> ReportTransfersHistoryAsync()
        {
            var retorno = await ReportTransfersHistoryAsync().ConfigureAwait(false);
            return retorno;
        }

        /// <summary>
        /// Report com as transferências enviadas e recebidas, com token customizado
        /// </summary>
        /// <param name="customApiToken">token customizado</param>
        /// <returns>A lista de transferência</returns>
        public async Task<TransfersReportResponseMessage> ReportTransfersHistoryAsync(string customApiToken)
        {
            Api.BaseURI = "/transfers";
            var retorno = await Api.GetAsync<TransfersReportResponseMessage>(null, null, customApiToken).ConfigureAwait(false);
            Api.BaseURI = string.Empty;
            return retorno;
        }
    }
}
