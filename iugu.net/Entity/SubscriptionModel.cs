using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iugu
{
    public class SubscriptionModel
    {
        public string id { get; set; }
        public bool suspended { get; set; }
        public string plan_identifier { get; set; }
        public int price_cents { get; set; }
        public string currency { get; set; }
        public SubscriptionFeatures features { get; set; }
        public object expires_at { get; set; }
        public string created_at { get; set; }
        public string updated_at { get; set; }
        public string customer_name { get; set; }
        public string customer_email { get; set; }
        public object cycled_at { get; set; }
        public int credits_min { get; set; }
        public object credits_cycle { get; set; }
        public string customer_id { get; set; }
        public string plan_name { get; set; }
        public string customer_ref { get; set; }
        public string plan_ref { get; set; }
        public bool active { get; set; }
        public object in_trial { get; set; }
        public int credits { get; set; }
        public bool credits_based { get; set; }
        public object recent_invoices { get; set; }
        public List<SubscriptionSubitem> subitems { get; set; }
        public List<SubscriptionLog> logs { get; set; }
        public List<CustomVariables> custom_variables { get; set; }
    }

    public class Feat
    {
        public string name { get; set; }
        public int value { get; set; }
    }

    public class SubscriptionFeatures
    {
        public Feat feat { get; set; }
    }

    public class SubscriptionSubitem
    {
        public string id { get; set; }
        public string description { get; set; }
        public int quantity { get; set; }
        public int price_cents { get; set; }
        public string price { get; set; }
        public string total { get; set; }
    }

    public class SubscriptionLog
    {
        public string id { get; set; }
        public string description { get; set; }
        public string notes { get; set; }
        public string created_at { get; set; }
    }
}
