using iugu.net.Response;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace iugu.net.Lib
{
    public class FinancialTransaction : APIResource
    {


        public FinancialTransaction()
        {
            BaseURI = "/financial_transaction_requests";
        }

        /// <summary>
        /// Listas todas as transações dentro de um marketplace
        /// </summary>
        /// <param name="customApiToken">api token customizado</param>
        /// <returns></returns>
        public async Task<FinancialTransactionResponse> GetAllTransactionsSubAccountsAsync(string customApiToken)
        {
            var data = await GetAsync(null, null, customApiToken).ConfigureAwait(false);

            JavaScriptSerializer JSserializer = new JavaScriptSerializer();
            var retorno = JSserializer.Deserialize<FinancialTransactionResponse>(data);

            return retorno;

        }

        /// <summary>
        /// serve pra vc simular o adiantamento, retorna as taxas e tudo mais
        /// </summary>
        /// <param name="customApiToken">api token customizado</param>
        /// <param name="transactions">é uma lista de ids de transações (vc pega os ids na outra chamada)</param>
        /// <returns></returns>
        public async Task<FinancialTransactionResponse> GetSimulAdvanceTransactionsSubAccountsAsync(string id, string customApiToken)
        {

            var data = await GetAsync("?transactions=" + id, "advance_simulation", customApiToken).ConfigureAwait(false);

            JavaScriptSerializer JSserializer = new JavaScriptSerializer();
            var retorno = JSserializer.Deserialize<FinancialTransactionResponse>(data);

            return retorno;
        }

        /// <summary>
        /// serve pra vc realizar o adiantamento
        /// </summary>
        /// <param name="customApiToken">api token customizado</param>
        /// <param name="transactions">é uma lista de ids de transações (vc pega os ids na outra chamada)</param>
        /// <returns></returns>
        public async Task<FinancialTransactionResponse> PostAdvanceTransactionsSubAccountsAsync(string id, string customApiToken)
        {
            var data = await PostAsync("?transactions=" + id, "advance", customApiToken).ConfigureAwait(false);

            JavaScriptSerializer JSserializer = new JavaScriptSerializer();
            var retorno = JSserializer.Deserialize<FinancialTransactionResponse>(data);

            return retorno;
        }
    }
}
