using iugu.net.Response;
using System;
using System.Threading.Tasks;

namespace iugu.net.Lib
{
    public class FinancialTransaction : IDisposable
    {
        protected readonly IApiResources Api;

        public FinancialTransaction() : this(new APIResource()) { }

        public FinancialTransaction(IApiResources api)
        {
            Api = api;
            Api.BaseURI = "/financial_transaction_requests";
        }

        /// <summary>
        /// Listas todas as transações de uma conta
        /// </summary>
        /// <returns></returns>
        public async Task<FinancialTransactionResponse> GetAllTransactionsAsync()
        {
            var retorno = await Api.GetAsync<FinancialTransactionResponse>().ConfigureAwait(false);
            return retorno;
        }

        /// <summary>
        /// Listas todas as transações dentro de um marketplace
        /// </summary>
        /// <param name="customApiToken">api token customizado</param>
        /// <returns></returns>
        public async Task<FinancialTransactionResponse> GetAllTransactionsSubAccountsAsync(string customApiToken)
        {
            var retorno = await Api.GetAsync<FinancialTransactionResponse>(null, null, customApiToken).ConfigureAwait(false);
            return retorno;
        }

        /// <summary>
        /// Simular um adiantamento de transações para a conta principal configurada
        /// </summary>
        /// <param name="transactionsIDs">String contendo os Ids no formato (transactions[]=1&transactions[]=2)</param>
        /// <returns>FinancialTransactionResponse com taxas e informações como se fosse executar o adiantamento</returns>
        public async Task<FinancialTransactionResponse> GetSimulAdvanceTransactionsAsync(string transactionsIDs)
        {
            var retorno = await Api.GetAsync<FinancialTransactionResponse>($"?{transactionsIDs}", "advance_simulation", null).ConfigureAwait(false);
            return retorno;
        }

        /// <summary>
        /// Simular um adiantamento de uma subconta
        /// </summary>
        /// <param name="transactionsIDs">String contendo os Ids no formato (transactions[]=1&transactions[]=2)</param>
        /// <param name="customApiToken">api token customizado</param>
        /// <returns>FinancialTransactionResponse com taxas e informações como se fosse executar o adiantamento</returns>
        public async Task<FinancialTransactionResponse> GetSimulAdvanceTransactionsSubAccountsAsync(string transactionsIDs, string customApiToken)
        {
            var retorno = await Api.GetAsync<FinancialTransactionResponse>($"?{transactionsIDs}", "advance_simulation", customApiToken).ConfigureAwait(false);
            return retorno;
        }

        /// <summary>
        /// Faz um pedido de adiantamento para de transações para uma subconta
        /// </summary>
        /// <param name="transactionsIDs">String contendo os Ids no formato (transactions[]=1&transactions[]=2)</param>
        /// <param name="customApiToken">api token customizado</param>
        /// <returns>FinancialTransactionResponse com taxas e informações como se fosse executar o adiantamento</returns>
        public async Task<FinancialTransactionResponse> PostAdvanceTransactionsSubAccountsAsync(string transactionsIDs, string customApiToken)
        {
            var retorno = await Api.PostAsync<FinancialTransactionResponse>($"?{transactionsIDs}", "advance", customApiToken).ConfigureAwait(false);
            return retorno;
        }

        /// <summary>
        /// Faz um pedido de adiantamento para de transações para a conta principal
        /// </summary>
        /// <param name="transactionsIDs">String contendo os Ids no formato (transactions[]=1&transactions[]=2)</param>
        /// <returns>FinancialTransactionResponse com taxas e informações </returns>
        public async Task<FinancialTransactionResponse> PostAdvanceTransactionsSubAccountsAsync(string transactionsIDs)
        {
            var retorno = await Api.PostAsync<FinancialTransactionResponse>($"?{transactionsIDs}", "advance", null).ConfigureAwait(false);
            return retorno;
        }

        public void Dispose()
        {
            Api.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
