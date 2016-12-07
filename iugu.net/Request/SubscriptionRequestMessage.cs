using iugu.net.Entity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using iugu.net.Response;

namespace iugu.net.Request
{
    /// <summary>
    /// Cria uma assinatura para um cliente cadastrado
    /// <see cref="https://iugu.com/referencias/api#criar-uma-assinatura"/>
    /// </summary>
    public class SubscriptionRequestMessage
    {
        public SubscriptionRequestMessage(string customerId)
        {
            CustomerId = customerId;
        }

        /// <summary>
        /// ID do Cliente
        /// </summary>
        [JsonProperty("customer_id")]
        public string CustomerId { get; set; }

        /// <summary>
        /// Identificador do Plano. Só é enviado para assinaturas que não são credits_based
        /// </summary>
        [JsonProperty("plan_identifier")]
        public string PlanId { get; set; }

        /// <summary>
        /// Data de Expiração (Também é a data da próxima cobrança)
        /// </summary>
        [JsonProperty("expires_at")]
        public DateTime? ExpiresAt { get; set; }

        /// <summary>
        /// Apenas Cria a Assinatura se a Cobrança for bem sucedida. Isso só funciona caso o cliente já tenha uma forma de pagamento padrão cadastrada
        /// </summary>
        [JsonProperty("only_on_charge_success ")]
        public bool? OnlyOnChargeSuccess { get; set; }

        /// <summary>
        /// Método de pagamento que será disponibilizado para as Faturas desta Assinatura (all, credit_card ou bank_slip). 
        /// Obs: Dependendo do valor, este atributo será herdado, pois a prioridade é herdar o valor atribuído ao Plano desta Assinatura;
        /// Caso este esteja atribuído o valor ‘all’, o sistema considerará o payable_with da Assinatura; se não, o sistema considerará o payable_with do Plano
        /// </summary>
        [JsonProperty("payable_with ")]
        public string PayableWith { get; set; }

        /// <summary>
        /// É uma assinatura baseada em créditos
        /// </summary>
        [JsonProperty("credits_based ")]
        public bool? IsCreditBased { get; set; }

        /// <summary>
        /// Preço em centavos da recarga para assinaturas baseadas em crédito
        /// </summary>
        [JsonProperty("price_cents ")]
        public int? PriceCents { get; set; }

        /// <summary>
        /// Quantidade de créditos adicionados a cada ciclo, só enviado para assinaturas credits_based
        /// </summary>
        [JsonProperty("credits_cycle")]
        public int? CreditsCycle { get; set; }

        /// <summary>
        /// Quantidade de créditos que ativa o ciclo, por ex: Efetuar cobrança cada vez que a assinatura tenha apenas 1 crédito sobrando. Esse 1 crédito é o credits_min
        /// </summary>
        [JsonProperty("credits_min ")]
        public int? CreditsMin { get; set; }

        /// <summary>
        /// Itens de Assinatura, sendo que estes podem ser recorrentes ou de cobrança única
        /// </summary>
        [JsonProperty("subitems")]
        public List<SubscriptionSubitem> Subitems { get; set; }

        /// <summary>
        /// Variáveis Personalizadas
        /// </summary>
        [JsonProperty("custom_variables")]
        public List<CustomVariables> CustomVariables { get; set; }

    }
}
