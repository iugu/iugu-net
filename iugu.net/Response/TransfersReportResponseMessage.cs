using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iugu.net.Response
{
    public class TransfersReportResponseMessage
    {
        [JsonProperty("sent")]
        public IList<TransferSentInfo> TransfersSent { get; set; }

        [JsonProperty("received")]
        public IList<TransferReceivedInfo> TransfersReceived { get; set; }

    }

    public class TransferReceivedInfo
    {
        [JsonProperty("amount_cents")]
        public int AmountInCents { get; set; }

        [JsonProperty("amount_localized")]
        public string AmountLocalized { get; set; }

        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("id")]
        public string TransferId { get; set; }

        [JsonProperty("sender")]
        public AccountInfo Sender { get; set; }
    }


    public class TransferSentInfo
    {
        [JsonProperty("amount_cents")]
        public int AmountInCents { get; set; }

        [JsonProperty("amount_localized")]
        public string AmountLocalized { get; set; }

        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("id")]
        public string TransferId { get; set; }

        [JsonProperty("receiver")]
        public AccountInfo Receiver { get; set; }
    }


    public class AccountInfo
    {
        [JsonProperty("id")]
        public string AccountId { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
