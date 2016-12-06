using System.Collections.Generic;
using Newtonsoft.Json;

namespace iugu.net.Entity
{
    // todo: sem documentação
    public class SubscriptionModel
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("id")]
        public string ID { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("suspended")]
        public bool Suspended { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("plan_identifier")]
        public string PlanIdentifier { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("price_cents")]
        public int PriceCents { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("currency")]
        public string Currency { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("features")]
        public SubscriptionFeatures Features { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("expires_at")]
        public object ExpiresAt { get; set; }

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
        [JsonProperty("customer_name")]
        public string CustomerName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("customer_email")]
        public string CustomerEmail { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("cycled_at")]
        public object CycledAt { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("credits_min")]
        public int CreditsMin { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("credits_cycle")]
        public object CreditsCycle { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("customer_id")]
        public string CustomerID { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("plan_name")]
        public string PlanName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("customer_ref")]
        public string CustomerRef { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("plan_ref")]
        public string PlanRef { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("active")]
        public bool Active { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("in_trial")]
        public object InTrial { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("credits")]
        public int Credits { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("credits_based")]
        public bool CreditsBased { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("recent_invoices")]
        public object RecentInvoices { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("subitems")]
        public List<SubscriptionSubitem> Subitems { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("logs")]
        public List<SubscriptionLog> Logs { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("custom_variables")]
        public List<CustomVariables> CustomVariables { get; set; }
    }

    public class Feat
    {
        /// <summary>
        /// Nome
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Valor
        /// </summary>
        [JsonProperty("value")]
        public int Value { get; set; }
    }

    public class SubscriptionFeatures
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("feat")]
        public Feat Feat { get; set; }
    }

    public class SubscriptionSubitem
    {
        /// <summary>
        /// ID
        /// </summary>
        [JsonProperty("id")]
        public string ID { get; set; }

        /// <summary>
        /// Descrição
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; set; }

        /// <summary>
        /// Quantidade
        /// </summary>
        [JsonProperty("quantity")]
        public int Quantity { get; set; }

        /// <summary>
        /// Valor em centavos
        /// </summary>
        [JsonProperty("price_cents")]
        public int PriceCents { get; set; }

        /// <summary>
        /// Preço
        /// </summary>
        [JsonProperty("price")]
        public string Price { get; set; }

        /// <summary>
        /// Total
        /// </summary>
        [JsonProperty("total")]
        public string Total { get; set; }

        /// <summary>
        /// Recorrente (Sim/Não)
        /// </summary>
        [JsonProperty("recurrent")]
        public bool? Recurrent { get; set; }
    }

    public class SubscriptionLog
    {
        /// <summary>
        /// ID
        /// </summary>
        [JsonProperty("id")]
        public string ID { get; set; }

        /// <summary>
        /// Descrição
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; set; }

        /// <summary>
        /// Observações
        /// </summary>
        [JsonProperty("notes")]
        public string Notes { get; set; }

        /// <summary>
        /// Data de criação
        /// </summary>
        [JsonProperty("created_at")]
        public string CreatedAt { get; set; }
    }
}
