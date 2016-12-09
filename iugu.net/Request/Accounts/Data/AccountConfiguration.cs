using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iugu.net.Response;
using Newtonsoft.Json;

namespace iugu.net.Request.Accounts.Data
{
    public class AccountConfiguration
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("commission_percent")]
        public string CommissionPercent { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("bank_slip")]
        public BankSlipConfiguration BankSlip { get; set; }
    }
}
