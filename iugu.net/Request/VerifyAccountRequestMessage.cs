using iugu.net.Entity;
using iugu.net.Response;
using iugu.net.Response.Working;
using Newtonsoft.Json;

namespace iugu.net.Request
{
    /// <summary>
    /// Request para solicitar validação dos dados de uma conta
    /// </summary>
    public class VerifyAccountRequestMessage
    {
        /// <summary>
        /// Informações da conta a ser verificada
        /// Obs: Essas informações serão adicionadas as informações da conta
        /// </summary>
        [JsonProperty("data")]
        public readonly AccountResponseMessage Data;

        /// <summary>
        /// Habilitar a rerificação automática dos dados bancários
        /// </summary>
        [JsonProperty("automatic_validation")]
        public readonly bool AutomaticValidation;

        //public VerifyAccountRequestMessage(AccountVerificationData account, bool automaticValidation)
        //{
        //    Data = account;
        //    AutomaticValidation = automaticValidation;
        //}
    }
}