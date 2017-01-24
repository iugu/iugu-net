using Newtonsoft.Json;

namespace iugu.net.Response.Accounts
{
    /// <summary>
    /// Resposta da chamada GET https://api.iugu.com/v1/marketplace/
    /// </summary>
    public class AccountResponseMessage
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("id")]
        public string ID { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("verified")]
        public string Verified { get; set; }
    }
}