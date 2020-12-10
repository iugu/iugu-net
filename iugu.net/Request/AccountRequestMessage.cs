using Newtonsoft.Json;

namespace iugu.net.Request
{
    /// <summary>
    /// Requisição para a API de contas
    /// </summary>
    public class AccountRequestMessage
    {
        /// <summary>
        /// Nome da Conta. Caso não seja enviado, um valor padrão com o ID da conta é atribuído
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Percentual de comissionamento enviado para a conta que gerencia o marketplace (Valor entre 0 e 70)
        /// </summary>
        [JsonProperty("commission_percent")]
        public int? CommissionPercent { get; set; }
    }
}
