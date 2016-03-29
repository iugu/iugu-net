using iugu.net.Entity;
using Newtonsoft.Json;

namespace iugu.net.Request
{
    public class PaymentTokenRequest
    {
        /// <summary>
        /// ID de sua Conta na Iugu (O ID de sua conta pode ser encontrado clicando na referência)
        /// <see cref="https://iugu.com/settings/account"/>
        /// </summary>
        [JsonProperty("account_id")]
        public string AccountId { get; set; }

        /// <summary>
        /// Método de Pagamento (atualmente somente credit_card)
        /// </summary>
        [JsonProperty("method")]
        public string Method { get; set; }

        /// <summary>
        /// Valor true para criar tokens de teste
        /// </summary>
        [JsonProperty("test")]
        public bool Test { get; set; }

        /// <summary>
        /// Dados do Método de Pagamento
        /// </summary>
        [JsonProperty("data")]
        public PaymentInfoModel PaymentData { get; set; }
    }
}
