using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace iugu.net.Request.Accounts.Data
{
    public class BankSlipConfiguration
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("active")]
        public bool Active { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("extra_due")]
        public string ExtraDue { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("reprint_extra_due")]
        public string ReprintExtraDue { get; set; }
    }
}
