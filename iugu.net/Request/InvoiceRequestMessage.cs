using iugu.net.Entity;
using Newtonsoft.Json;
using System;
using iugu.net.Response;

namespace iugu.net.Request
{
    /// <summary>
    /// Objeto que representa request de criação de fartura
    /// </summary>
    public class InvoiceRequestMessage
    {
        /// <summary>
        /// E-Mail do cliente
        /// </summary>
        [JsonProperty("email")]
        public string Email { get; }

        /// <summary>
        /// Data de Expiração (DD/MM/AAAA)
        /// </summary>
        [JsonProperty("due_date")]
        public string DueDate { get; }

        /// <summary>
        ///  Itens da Fatura
        /// </summary>
        [JsonProperty("items")]
        public Item[] Items { get; }

        /// <summary>
        /// Informações do Cliente para o Anti Fraude ou Boleto
        /// </summary>
        [JsonProperty("payer")]
        public PayerModel Payer { get; set; }

        /// <summary>
        /// (opcional) Cliente é redirecionado para essa URL após efetuar o pagamento da Fatura pela página de Fatura da Iugu
        /// </summary>
        [JsonProperty("return_url ")]
        public string ReturnUrl { get; set; }

        /// <summary>
        /// (opcional) Cliente é redirecionado para essa URL se a Fatura que estiver acessando estiver expirada
        /// </summary>
        [JsonProperty("expired_url ")]
        public string ExpiredUrl { get; set; }

        /// <summary>
        /// (opcional) URL chamada para todas as notificações de Fatura, assim como os webhooks (Gatilhos) são chamados
        /// </summary>
        [JsonProperty("notification_url")]
        public string NotificationUrl { get; set; }

        /// <summary>
        /// (opcional) Valor dos Impostos em centavos
        /// </summary>
        [JsonProperty("tax_cents")]
        public int TaxCents { get; set; }

        /// <summary>
        /// (opcional) Booleano para Habilitar ou Desabilitar multa por atraso de pagamento
        /// </summary>
        [JsonProperty("fines")]
        public bool EnableLateFine { get; set; }

        /// <summary>
        /// (opcional) Determine a multa a ser cobrada para pagamentos efetuados após a data de vencimento
        /// </summary>
        [JsonProperty("late_payment_fine")]
        public string LatePaymentFine { get; set; }

        /// <summary>
        /// (opcional) Booleano que determina se cobra ou não juros por dia de atraso. 1% ao mês pro rata.
        /// </summary>
        [JsonProperty("per_day_interest")]
        public bool EnableProportionalDailyTax { get; set; }

        /// <summary>
        /// (opcional) Valor dos Descontos em centavos
        /// </summary>
        [JsonProperty("discount_cents")]
        public int DiscountCents { get; set; }

        /// <summary>
        /// (opcional) ID do Cliente
        /// </summary>
        [JsonProperty("customer_id")]
        public string CustomerId { get; set; }

        /// <summary>
        /// (opcional) Booleano que ignora o envio do e-mail de cobrança
        /// </summary>
        [JsonProperty("ignore_due_email")]
        public bool IgnoreDueDateMail { get; set; }

        /// <summary>
        /// (opcional) Amarra esta Fatura com a Assinatura especificada
        /// </summary>
        [JsonProperty("subscription_id")]
        public string SubscriptionId { get; set; }

        /// <summary>
        /// (opcional) Método de pagamento que será disponibilizado para esta Fatura (‘all’, ‘credit_card’ ou ‘bank_slip’). 
        /// Obs: Caso esta Fatura esteja atrelada à uma Assinatura, a prioridade é herdar o valor atribuído na Assinatura; 
        /// caso esta esteja atribuído o valor ‘all’, o sistema considerará o payable_with da Fatura; se não, o sistema considerará o payable_with da Assinatura.
        /// </summary>
        [JsonProperty("payable_with")]
        public string PaymentMethod { get; set; }

        /// <summary>
        /// (opcional) Caso tenha o subscription_id, pode-se enviar o número de créditos a adicionar nessa Assinatura quando a Fatura for paga
        /// </summary>
        [JsonProperty("credits")]
        public int? Credits { get; set; }

        /// <summary>
        /// (opcional) Logs da Fatura
        /// </summary>
        [JsonProperty("logs")]
        public Logs[] Logs { get; set; }

        /// <summary>
        /// (opcional) Variáveis Personalizadas
        /// </summary>
        [JsonProperty("custom_variables")]
        public CustomVariables[] CustomVariables { get; set; }

        public InvoiceRequestMessage(string email, DateTime dueDate, Item[] items)
        {
            Email = email;
            DueDate = dueDate.ToString("dd/MM/yyyy");
            Items = items;
        }

    }
}
