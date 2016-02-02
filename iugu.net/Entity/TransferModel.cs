using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iugu.Entity
{
    public class TransferModel
    {
        public string id { get; set; }
        public string created_at { get; set; }
        public string amount_cents { get; set; }
        public string amount_localized { get; set; }
        public Receiver receiver { get; set; }
    }

    public class Receiver
    {
        public string id { get; set; }
        public string name { get; set; }
    }
}
