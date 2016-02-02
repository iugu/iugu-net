using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iugu.net.Response
{
    /// <summary>
    /// Representa a resposta da API para uma requisição de cobrança que resulta em boleto
    /// </summary>
    public class ChargeBankSlipResponseMessage
    {
        /// <summary>
        /// Erros
        /// </summary>
        [JsonProperty("errors")]
        public Dictionary<string, object> Errors { get; set; }

        /// <summary>
        /// Url do boleto
        /// </summary>
        [JsonProperty("url")]
        public string Url { get; set; }

        /// <summary>
        /// Informa se a cobrança foi gerada com sucesso
        /// </summary>
        [JsonProperty("success")]
        public bool Success { get; set; }

        /// <summary>
        /// Número da fatura da cobrança
        /// </summary>
        [JsonProperty("invoice_id")]
        public string InvoiceId { get; set; }
    }

}
