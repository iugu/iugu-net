using Newtonsoft.Json;

namespace iugu.net.Response
{
    public class SimpleResponseMessage
    {
        /// <summary>
        /// Result of request
        /// </summary>
        [JsonProperty("success")]
        public bool Success { get; set; }
    }
}
