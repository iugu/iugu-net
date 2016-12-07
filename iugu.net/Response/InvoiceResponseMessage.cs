using System.Collections.Generic;
using iugu.net.Entity;
using Newtonsoft.Json;

namespace iugu.net.Response
{
    //TODO: faltando propriededas que não estão na documentação
    public class InvoiceResponseMessage
    {
        /// <summary>
        /// ID da fatura
        /// </summary>
        [JsonProperty("id")]
        public string ID { get; set; }

        /// <summary>
        /// Data de Expiração (DD/MM/AAAA)
        /// </summary>
        [JsonProperty("due_date")]
        public string DueDate { get; set; }

        /// <summary>
        /// Moeda
        /// </summary>
        [JsonProperty("currency")]
        public string Currency { get; set; }

        /// <summary>
        /// Disconto em centavos
        /// </summary>
        [JsonProperty("discount_cents")]
        public object DiscountCents { get; set; }

        /// <summary>
        /// E-Mail do cliente
        /// </summary>
        [JsonProperty("email")]
        public string Email { get; set; }

        /// <summary>
        /// Total de ítens em centavos
        /// </summary>
        [JsonProperty("items_total_cents")]
        public int ItemsTotalCents { get; set; }

        /// <summary>
        /// URL chamada para todas as notificações de Fatura, assim como os webhooks (Gatilhos) são chamados
        /// </summary>
        [JsonProperty("notification_url")]
        public object NotificationUrl { get; set; }

        /// <summary>
        /// Cliente é redirecionado para essa URL após efetuar o pagamento da Fatura pela página de Fatura da Iugu
        /// </summary>
        [JsonProperty("return_url")]
        public object ReturnUrl { get; set; }

        /// <summary>
        /// Status da fatura
        /// </summary>
        [JsonProperty("status")]
        public string Status { get; set; }

        /// <summary>
        /// Valor dos Impostos em centavos
        /// </summary>
        [JsonProperty("tax_cents")]
        public object TaxCents { get; set; }

        /// <summary>
        /// Data de modificação
        /// </summary>
        [JsonProperty("updated_at")]
        public string UpdatedAt { get; set; }

        /// <summary>
        /// Valor total da fatura em centavos
        /// </summary>
        [JsonProperty("total_cents")]
        public int TotalCents { get; set; }

        /// <summary>
        /// Valor total pago
        /// </summary>
        [JsonProperty("total_paid")]
        public string TotalPaid { get; set; }

        /// <summary>
        /// Valor total pago em centavos
        /// </summary>
        [JsonProperty("total_paid_cents")]
        public int TotalPaidCents { get; set; }

        /// <summary>
        /// Data de pagamento da fatura
        /// </summary>
        [JsonProperty("paid_at")]
        public object PaidAt { get; set; }

        /// <summary>
        /// Valoe pago em centavos
        /// </summary>
        [JsonProperty("paid_cents")]
        public int? PaidCents { get; set; }

        /// <summary>
        /// Valor pago
        /// </summary>
        [JsonProperty("paid")]
        public string Paid { get; set; }

        /// <summary>
        /// ID seguro da fatura
        /// </summary>
        [JsonProperty("secure_id")]
        public string SecureID { get; set; }

        /// <summary>
        /// URL seguro da fatura 
        /// </summary>
        [JsonProperty("secure_url")]
        public string SecureUrl { get; set; }

        /// <summary>
        /// ID do Cliente
        /// </summary>
        [JsonProperty("customer_id")]
        public object CustomerID { get; set; }

        /// <summary>
        /// ID do usuário
        /// </summary>
        [JsonProperty("user_id")]
        public object UserID { get; set; }

        /// <summary>
        /// Total da fatura
        /// </summary>
        [JsonProperty("total")]
        public string Total { get; set; }

        /// <summary>
        /// Valor dos impostos pagos
        /// </summary>
        [JsonProperty("taxes_paid")]
        public string TaxesPaid { get; set; }

        /// <summary>
        /// Valor dos juros
        /// </summary>
        [JsonProperty("interest")]
        public object Interest { get; set; }

        /// <summary>
        /// Valor do disconto
        /// </summary>
        [JsonProperty("discount")]
        public object Discount { get; set; }

        /// <summary>
        /// Data de criação
        /// </summary>
        [JsonProperty("created_at")]
        public string CreatedAt { get; set; }

        /// <summary>
        /// Reembolsável (Sim/Não)
        /// </summary>
        [JsonProperty("refundable")]
        public object Refundable { get; set; }

        /// <summary>
        /// Parcelas
        /// </summary>
        [JsonProperty("installments")]
        public object Installments { get; set; }

        /// <summary>
        /// Número do boleto bancário
        /// </summary>
        [JsonProperty("bank_slip")]
        public BankSlipResponseMessage BankSlipResponseMessage { get; set; }

        /// <summary>
        /// Itens da Fatura
        /// </summary>
        [JsonProperty("items")]
        public List<Item> Items { get; set; }

        /// <summary>
        /// Variaveis da fatura
        /// </summary>
        [JsonProperty("variables")]
        public List<Variable> Variables { get; set; }

        /// <summary>
        /// Variáveis customizadas da fatura
        /// </summary>
        [JsonProperty("custom_variables")]
        public List<CustomVariables> CustomVariables { get; set; }

        /// <summary>
        /// Logs da fatura
        /// </summary>
        [JsonProperty("logs")]
        public List<Logs> Logs { get; set; }
    }

    public class Item
    {
        /// <summary>
        /// ID do ítem
        /// </summary>
        [JsonProperty("id")]
        public string ID { get; set; }

        /// <summary>
        /// Descrição do ítem
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; set; }

        /// <summary>
        /// Preço em Centavos. Valores negativos entram como desconto no total da Fatura
        /// </summary>
        [JsonProperty("price_cents")]
        public int PriceCents { get; set; }

        /// <summary>
        /// Quantidade
        /// </summary>
        [JsonProperty("quantity")]
        public int Quantity { get; set; }

        /// <summary>
        /// Data de criação
        /// </summary>
        [JsonProperty("created_at")]
        public string CreatedAt { get; set; }

        /// <summary>
        /// Data de modificação
        /// </summary>
        [JsonProperty("updated_at")]
        public string UpdatedAt { get; set; }

        /// <summary>
        /// Preço
        /// </summary>
        [JsonProperty("price")]
        public string Price { get; set; }

        //TODO: descrição desse item
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("_destroy")]
        public bool? Destroy { get; set; }
    }

    public class Variable
    {
        /// <summary>
        /// ID da variavel
        /// </summary>
        [JsonProperty("id")]
        public string id { get; set; }
        
        /// <summary>
        /// Nome da variavel
        /// </summary>
        [JsonProperty("variable")]
        public string variable { get; set; }

        /// <summary>
        /// Valor
        /// </summary>
        [JsonProperty("value")]
        public string Value { get; set; }
    }

    public class Term
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("term")]
        public string term { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("count")]
        public int Count { get; set; }
    }

    public class Status
    {
        /// <summary>
        /// Type
        /// </summary>
        [JsonProperty("_type")]
        public string Type { get; set; }

        //TODO: descrição desse item
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("missing")]
        public int Missing { get; set; }
        
        
        /// <summary>
        /// Total
        /// </summary>
        [JsonProperty("total")]
        public int Total { get; set; }

        /// <summary>
        /// Outro
        /// </summary>
        [JsonProperty("other")]
        public int other { get; set; }
        
        /// <summary>
        /// Termo
        /// </summary>
        [JsonProperty("terms")]
        public List<Term> terms { get; set; }
    }

    public class Facets
    {
        /// <summary>
        /// Status
        /// </summary>
        [JsonProperty("status")]
        public Status Status { get; set; }
    }
}
