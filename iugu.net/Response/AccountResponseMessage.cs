using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iugu.net.Response
{
    public class AccountResponseMessage
    {
        /// <summary>
        /// Id da conta
        /// </summary>
        [JsonProperty("account_id")]
        public string AccountId { get; set; }

        /// <summary>
        /// Nome da conta
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("live_api_token")]
        public string LiveApiToken { get; set; }

        [JsonProperty("test_api_token")]
        public string TestApiToken { get; set; }

        [JsonProperty("user_token")]
        public string UserToken { get; set; }
    }
}
