using iugu.net.Response.Accounts;
using iugu.net.Response.Accounts.Data;
using Newtonsoft.Json;

namespace iugu.net.Request.Accounts
{
    public class VerifyAccountRequestMessage
    {
        /// <summary>
        /// 'true' para validar os dados bancários através do dígito verificador
        /// </summary>
        [JsonProperty("automatic_validation")]
        public bool AutomaticValidation { get; set; }

        /// <summary>
        /// Dados para Verificação
        /// </summary>
        [JsonProperty("data")]
        public AccountVerificationData Data { get; set; }

        /// <summary>
        /// Documentos para Verificação
        /// </summary>
        [JsonProperty("files")]
        public VerificationFiles Vfiles { get; set; }
    }
}

