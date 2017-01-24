using Newtonsoft.Json;

namespace iugu.net.Response.Accounts.Data
{
    /// <summary>
    /// Informações extras da conta
    /// </summary>
    public class AccountInformation
    {
        [JsonProperty("key")]
        public string Key { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }
    }
}
