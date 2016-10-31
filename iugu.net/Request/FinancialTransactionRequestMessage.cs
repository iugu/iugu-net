using Newtonsoft.Json;
using System.Collections.Generic;

namespace iugu.net.Request
{
    /// <summary>
    /// Requisição para a API de contas
    /// </summary>
    public class FinancialTransactionRequestMessage
    {
        /// <summary>
        ///  Variáveis Personalizadas
        /// </summary>
        [JsonProperty("transactions")]
        public List<Transactions> Transactions { get; set; }

    }

    public class Transactions
    {
        [JsonProperty("id")]
        public int Id { get; set; }
    }
}
