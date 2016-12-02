using iugu.net.Entity;
using iugu.net.Filters;
using iugu.net.Request;
using iugu.net.Response;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace iugu.net.Lib
{
    /// <summary>
    /// Os clientes efetuam pagamentos através das faturas. 
    /// As faturas contém itens que representam o que o cliente está pagando, o serviço ou produto.
    /// </summary>
    public class Invoice : APIResource
    {
        public Invoice()
        {
            BaseURI = "/invoices";
        }
        
        public async Task<InvoiceListModel> GetAsync()
        {
            //TODO: Implementar GET com parametros
            var retorno = await GetAsync<InvoiceListModel>().ConfigureAwait(false);
            return retorno;
        }

        /// <summary>
        /// Lista todas as ultimas(1000) faturas possibilitando enviar um ApiToken de subconta, geralmente utilizado em marketplaces
        /// </summary>
        /// <param name="customApiToken">ApiToken customizado</param>
        /// <returns></returns>
        public async Task<InvoiceListModel> GetAllAsync(string customApiToken)
        {
            var filter = new QueryStringFilter { MaxResults = 1000 };
            var queryStringFilter = filter?.ToQueryStringUrl();
            var retorno = await GetAsync<InvoiceListModel>(null, queryStringFilter, customApiToken).ConfigureAwait(false);
            return retorno;
        }

        /// <summary>
        /// Lista todas as faturas possibilitando enviar um ApiToken de subconta, geralmente utilizado em marketplaces e filtros customizaveis.
        /// </summary>
        /// <param name="customApiToken">ApiToken customizado</param>
        /// <param name="filter">Opções de filtros, para paginação e ordenação</param>
        /// <returns></returns>
        public async Task<PaggedResponseMessage<InvoiceModel>> GetAllAsync(string customApiToken, QueryStringFilter filter)
        {
            var queryStringFilter = filter?.ToQueryStringUrl();
            var retorno = await GetAsync<PaggedResponseMessage<InvoiceModel>>(null, queryStringFilter, customApiToken).ConfigureAwait(false);
            return retorno;
        }
        
        public async Task<InvoiceModel> GetAsync(string id)
        {
            var retorno = await GetAsync(id, null).ConfigureAwait(false);
            return retorno;
        }

        public async Task<InvoiceModel> GetAsync(string id, string customApiToken)
        {
            var retorno = await GetAsync<InvoiceModel>(id, null, customApiToken).ConfigureAwait(false);
            return retorno;
        }

        /// <summary>
        /// Cria uma Fatura para um Cliente
        /// </summary>
        /// <param name="invoice"></param>
        /// <param name="customApiToken">Token customizado opcional, mais utilizado em marketplaces</param>
        /// <returns>Objeto invoice resultante da requisição</returns>
        public async Task<InvoiceModel> CreateAsync(InvoiceRequestMessage invoice, string customApiToken = null)
        {
            var retorno = await PostAsync<InvoiceModel>(invoice, null, customApiToken).ConfigureAwait(false);
            return retorno;
        }

        public async Task<InvoiceModel> DeleteAsync(string id)
        {
            var retorno = await DeleteAsync<InvoiceModel>(id).ConfigureAwait(false);
            return retorno;
        }

        
        public async Task<InvoiceModel> PutAsync(string id, InvoiceModel model)
        {
            var retorno = await PutAsync<InvoiceModel>(id, model).ConfigureAwait(false);
            return retorno;
        }

        
        public async Task<InvoiceModel> RefundAsync(string id)
        {
            var retorno = await PostAsync<InvoiceModel>(null, $"{id}/refund").ConfigureAwait(false);
            return retorno;
        }

        public async Task<InvoiceModel> CancelAsync(string id)
        {
            var retorno = await CancelAsync(id, null).ConfigureAwait(false);
            return retorno;
        }

        public async Task<InvoiceModel> CancelAsync(string id, string customApiToken)
        {
            var retorno = await PutAsync<InvoiceModel>(default(object), $"{id}/cancel", customApiToken).ConfigureAwait(false);
            return retorno;
        }

        /// <summary>
        /// Gera segunda via de uma Fatura. Somente faturas pendentes podem ter segunda via gerada. A fatura atual é cancelada e uma nova é gerada com status ‘pending’.
        /// </summary>
        /// <param name="id">Identificador da fatura</param>
        /// <param name="data">Informações da nova fatura</param>
        /// <returns>Objeto invoice resultante da requisição</returns>
        public async Task<InvoiceModel> DuplicateAsync(string id, InvoiceDuplicateRequestMessage data)
        {
            var retorno = await PostAsync<InvoiceModel>(data, $"{id}/duplicate").ConfigureAwait(false);
            return retorno;
        }

        /// <summary>
        /// Gera segunda via de uma Fatura. Somente faturas pendentes podem ter segunda via gerada. A fatura atual é cancelada e uma nova é gerada com status ‘pending’.
        /// </summary>
        /// <param name="id">Identificador da fatura</param>
        /// <param name="data">Informações da nova fatura</param>
        /// <param name="customApiToken">Token customizado geralmente passado quando está se trabalhando como marketplace</param>
        /// <returns>Objeto invoice resultante da requisição</returns>
        public async Task<InvoiceModel> DuplicateAsync(string id, InvoiceDuplicateRequestMessage data, string customApiToken)
        {
            var retorno = await PostAsync<InvoiceModel>(data, $"{id}/duplicate", customApiToken).ConfigureAwait(false);
            return retorno;
        }

        /// <summary>
        /// Captura uma fatura com estado 'Em Análise'
        /// </summary>
        /// <param name="id">Identificador da fatura</param>
        /// <returns>Objeto invoice resultante da requisição</returns>
        public async Task<InvoiceModel> CaptureAsync(string id)
        {
            var retorno = await PostAsync<InvoiceModel>(default(object), $"{id}/capture").ConfigureAwait(false);
            return retorno;
        }

        /// <summary>
        /// Reenviar fatura para o email do cliente
        /// </summary>
        /// <param name="id">Identificador da fatura</param>
        /// <returns>Objeto invoice resultante da requisição</returns>
        public async Task<InvoiceModel> ResendInvoiceMail(string id)
        {
            var retorno = await ResendInvoiceMail(id, null).ConfigureAwait(false);
            return retorno;
        }

        /// <summary>
        /// Reenviar fatura para o email do cliente
        /// </summary>
        /// <param name="id">Identificador da fatura</param>
        /// <param name="customApiToken">Token customizado geralmente passado quando está se trabalhando como marketplace</param>
        /// <returns>Objeto invoice resultante da requisição</returns>
        public async Task<InvoiceModel> ResendInvoiceMail(string id, string customApiToken)
        {
            var retorno = await PostAsync<InvoiceModel>(default(object), $"{id}/send_email", customApiToken).ConfigureAwait(false);
            return retorno;
        }
    }
}
