using iugu.net.JsonCustomConverters;
using Newtonsoft.Json;

namespace iugu.net.Response
{
    /// <summary>
    /// Resposta da Api de pedido de saque
    /// </summary>
    public class AccountRequestWithdrawResponse
    {
        /// <summary>
        /// Id que identifica o pedido de saque efetuado
        /// </summary>
        [JsonProperty("id")]
        public string OperationId { get; set; }

        /// <summary>
        /// Valor solicitado para saque
        /// </summary>
        [JsonProperty("amount")]
        [JsonConverter(typeof(BrazilianDecimalConverter))]
        public decimal WithdrawValue { get; set; }
    }
}
