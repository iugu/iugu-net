using System;
using iugu.net.Response.Accounts.Data;
using Newtonsoft.Json;

namespace iugu.net.Response.Accounts
{
    /// <summary>
    /// Resposta para a chamada POST POST https://api.iugu.com/v1/accounts/ID_DA_CONTA/request_verification
    /// </summary>
    public class VerifyAccountResponseMessage
    {
        /// <summary>
        /// Identificação da verificação
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// Dados da conta
        /// </summary>
        [JsonProperty("data")]
        public AccountVerificationData Data { get; set; }

        /// <summary>
        /// Identificação da conta
        /// </summary>
        [JsonProperty("account_id")]
        public string AccountId { get; set; }

        /// <summary>
        /// Data da criação da verificação
        /// </summary>
        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }
    }
}