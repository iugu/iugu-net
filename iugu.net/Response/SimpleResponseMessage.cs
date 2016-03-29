using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
