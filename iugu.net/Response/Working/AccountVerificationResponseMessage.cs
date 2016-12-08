using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace iugu.net.Response.Working
{
    class AccountVerificationResponseMessage
    {
        /// <summary>
        /// Identificação da verificação
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// Identificação da conta
        /// </summary>
        [JsonProperty("account_id")]
        public string AccountId { get; set; }

        /// <summary>
        /// Dados da conta
        /// </summary>
        [JsonProperty("data")]
        public AccountVerificationData Data { get; set; }

        /// <summary>
        /// Data da criação da verificação
        /// </summary>
        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }
    }
}
