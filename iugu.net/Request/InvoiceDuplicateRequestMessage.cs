using iugu.net.Entity;
using Newtonsoft.Json;
using System.Collections.Generic;
using iugu.net.Response;

namespace iugu.net.Request
{
    /// <summary>
    ///  Gera segunda via de uma Fatura. Somente faturas pendentes podem ter segunda via gerada. A fatura atual é cancelada e uma nova é gerada com status ‘pending’.
    /// </summary>
    public class InvoiceDuplicateRequestMessage
    {
        public InvoiceDuplicateRequestMessage(string newDueDate)
        {
            NewDueDate = newDueDate;
        }

        /// <summary>
        /// Nova data de expiração (Formato: 'DD/MM/AAAA’).
        /// </summary>
        [JsonProperty("due_date")]
        public string NewDueDate { get; }

        /// <summary>
        /// Adicione, altere ou remova itens a nova fatura.
        /// </summary>
        [JsonProperty("items")]
        public List<Item> InvoiceItems { get; set; }

        /// <summary>
        /// Ignora o envio do e-mail de cobrança da nova fatura.
        /// </summary>
        [JsonProperty("ignore_due_email")]
        public bool? IgnoreDueEmail { get; set; }

        /// <summary>
        /// Ignora o envio do e-mail de cancelamento da fatura atual.
        /// </summary>
        [JsonProperty("ignore_canceled_email")]
        public bool? IgnoreCanceledEmail { get; set; }
    }
}
