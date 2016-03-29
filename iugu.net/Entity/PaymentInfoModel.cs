using Newtonsoft.Json;

namespace iugu.net.Entity
{
    /// <summary>
    /// Modelo que contém informações de pagamento
    /// </summary>
    public class PaymentInfoModel
    {
        /// <summary>
        /// Número do Cartão de Crédito
        /// </summary>
        [JsonProperty("number")]
        public string Number { get; set; }

        /// <summary>
        /// CVV do Cartão de Crédito
        /// </summary>
        [JsonProperty("verification_value")]
        public string VerificationValue { get; set; }

        /// <summary>
        /// Nome do Cliente como está no Cartão
        /// </summary>
        [JsonProperty("first_name")]
        public string FirstName { get; set; }

        /// <summary>
        /// Sobrenome do Cliente como está no Cartão
        /// </summary>
        [JsonProperty("last_name")]
        public string LastName { get; set; }

        /// <summary>
        /// Mês de Vencimento no Formato MM (Ex: 01, 02, 12)
        /// </summary>
        [JsonProperty("month")]
        public string Month { get; set; }

        /// <summary>
        /// Ano de Vencimento no Formato YYYY (2014, 2015, 2016)
        /// </summary>
        [JsonProperty("year")]
        public string Year { get; set; }
    }
}
