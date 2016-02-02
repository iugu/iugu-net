using iugu.net.Entity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iugu.net.Request
{
    public class ChargeRequestMessage
    {
        /// <summary>
        /// Método de Pagamento (Atualmente só suporta bank_slip, que é o boleto) - Opicional se enviar o Token
        /// </summary>
        [JsonProperty("method")]
        public string Method { get; set; }

        /// <summary>
        /// ID do Token. Em caso de Marketplace, é possível enviar um token criado pela conta mestre - Opicional caso method seja bank_slip
        /// </summary>
        [JsonProperty("token")]
        public string Token { get; set; }

        /// <summary>
        /// ID da Forma de Pagamento do Cliente. Em caso de Marketplace, é possível enviar um customer_payment_method_id de um Cliente criado pela conta mestre
        /// Opcional caso method seja bank_slip ou utilize token)
        /// </summary>
        [JsonProperty("customer_payment_method_id")]
        public string CustomerPaymentMethodId { get; set; }

        /// <summary>
        /// ID do Cliente. Utilizado para vincular a Fatura a um Cliente - Opcional
        /// </summary>
        [JsonProperty("customer_id ")]
        public string CustomerId { get; set; }

        /// <summary>
        /// ID da Fatura a ser utilizada para pagamento - Opcional
        /// </summary>
        [JsonProperty("invoice_id ")]
        public string InvoiceId { get; set; }

        /// <summary>
        /// E-mail do Cliente - Opcional caso seja enviado um invoice_id
        /// </summary>
        [JsonProperty("email")]
        public string Email { get; set; }

        /// <summary>
        /// Número de Parcelas (2 até 12), não é necessário passar 1 - Opcional
        /// </summary>
        [JsonProperty("months")]
        public int? Months { get; set; }

        /// <summary>
        /// Valor dos Descontos em centavos. Funciona apenas para Cobranças Diretas criadas com Itens - Opcional
        /// </summary>
        [JsonProperty("discount_cents")]
        public int? DiscountCents { get; set; }

        /// <summary>
        /// Itens da Fatura que será gerada - Opcional caso seja enviado um invoice_id
        /// </summary>
        [JsonProperty("items")]
        public InvoiceItem[] InvoiceItems { get; set; }

        /// <summary>
        /// Informações do Cliente para o Anti Fraude ou Boleto
        /// Necessário caso sua conta necessite de anti fraude ou para informações do boleto
        /// </summary>
        [JsonProperty("payer")]
        public PayerModel PayerCustomer { get; set; }

    }
}
