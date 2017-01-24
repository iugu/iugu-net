using System.Collections.Generic;
using Newtonsoft.Json;

namespace iugu.net.Entity
{
    //todo: verify this class as it does not look right
   
    // TODO: sem documentação
    public class PlanResponseMessage
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("id")]
        public string ID { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("identifier")]
        public string Identifier { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("interval")]
        public int Interval { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("interval_type")]
        public string IntervalType { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("created_at")]
        public string CreatedAt { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("updated_at")]
        public string UpdatedAt { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("prices")]
        public List<PlanPrice> Prices { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("features")]
        public List<PlanFeature> Features { get; set; }
    }

    // TODO: Precisa de documentação
    public class PlanPrice
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("created_at")]
        public string CreatedAt { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("currency")]
        public string Currency { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("id")]
        public string ID { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("plan_id")]
        public string PlanID { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("updated_at")]
        public string UpdatedAt { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("value_cents")]
        public int ValueCents { get; set; }
    }

    // TODO: Precisa de documentação
    public class PlanFeature
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("created_at")]
        public string CreatedAt { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("id")]
        public string ID { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("identifier")]
        public string Identifier { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("important")]
        public object Important { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("plan_id")]
        public string PlanID { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("position")]
        public int Position { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("updated_at")]
        public string UpdatedAt { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("value")]
        public int Value { get; set; }
    }
}
