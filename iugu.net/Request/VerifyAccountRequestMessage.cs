using iugu.net.Entity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iugu.net.Request
{
    /// <summary>
    /// Request para solicitar validação dos dados de uma conta
    /// </summary>
    public class VerifyAccountRequestMessage
    {
        [JsonProperty("data")]
        public readonly AccountModel Data;

        [JsonProperty("automatic_validation")]
        public readonly bool AutomaticValidation;

        public VerifyAccountRequestMessage(AccountModel account, bool automaticValidation)
        {
            Data = account;
            AutomaticValidation = automaticValidation;
        }
    }
}