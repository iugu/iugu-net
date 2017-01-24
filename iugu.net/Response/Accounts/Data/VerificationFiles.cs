using Newtonsoft.Json;

namespace iugu.net.Response.Accounts
{
    public class VerificationFiles
    {
        /// <summary>
        /// Multipart do Documento (RG, CPF)
        /// </summary>
        [JsonProperty("id")]
        public bool ID { get; set; }

        /// <summary>
        /// (opcional) Multipart do CPF (Caso não tenha CPF no id)
        /// </summary>
        [JsonProperty("cpf")]
        public bool Cpf { get; set; }

        /// <summary>
        /// Multipart de um documento que comprove a atividade exercida pela empresa/pessoa da conta
        /// </summary>
        [JsonProperty("activity")]
        public bool Activity { get; set; }
    }
}
