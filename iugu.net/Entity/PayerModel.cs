using Newtonsoft.Json;

namespace iugu.net.Entity
{
    /// <summary>
    /// Modelo que representa os dados do cliente que efetua o pagamento
    /// </summary>
    public class PayerModel
    {
        /// <summary>
        /// CPF ou CNPJ do Cliente
        /// </summary>
        [JsonProperty("cpf_cnpj")]
        public string CpfOrCnpj { get; set; }

        /// <summary>
        /// Nome (utilizado como sacado em caso de pagamentos em boleto)
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Prefixo do Telefone (Ex: 11 para São Paulo)
        /// </summary>
        [JsonProperty("phone_prefix")]
        public string PhonePrefix { get; set; }

        /// <summary>
        /// Telefone
        /// </summary>
        [JsonProperty("phone")]
        public string Phone { get; set; }

        /// <summary>
        /// E-mail do Cliente
        /// </summary>
        [JsonProperty("email")]
        public string Email { get; set; }

        /// <summary>
        /// Endereço do Cliente (utilizado em caso de pagamento em boleto)
        /// </summary>
        [JsonProperty("address")]
        public AddressRequestMessage Address { get; set; }
    }
}
