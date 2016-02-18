using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace  iugu.net.Entity
{
    public class PaymentMethodModel
    {
        public string id { get; set; }
        public string description { get; set; }
        public string item_type { get; set; }
        public PaymentMethodData data { get; set; }
    }

    public class PaymentMethodData
    {
        public string token { get; set; }
        public string display_number { get; set; }
        public string brand { get; set; }
    }
}
