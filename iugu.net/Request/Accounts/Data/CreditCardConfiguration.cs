using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace iugu.net.Request.Accounts.Data
{
    public class CreditCardConfiguration
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("active")]
        public string Active { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("soft_description")]
        public string SoftDescription { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("installmentes")]
        public string Installments { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("installments_pass_interest")]
        public string InstallmentsPassInterest { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("max_installments")]
        public string MaxInstallments { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("max_installments_without_interest")]
        public string MaxInstallmentsWithoutInterest { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("two_step_transaction")]
        public string TwoStepTransaction { get; set; }
    }
}
