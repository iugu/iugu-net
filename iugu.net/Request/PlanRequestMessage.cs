using iugu.net.Entity;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace iugu.net.Request
{
    /// <summary>
    /// Representa os parametros para se criar um plano
    /// </summary>
    public class PlanRequestMessage
    {
        /// <summary>
        /// Nome do Plano
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; }

        /// <summary>
        /// Identificador do Plano
        /// </summary>
        [JsonProperty("identifier")]
        public string UniqueIdentifier { get; }

        /// <summary>
        /// Ciclo do Plano (Número inteiro maior que 0)
        /// </summary>
        [JsonProperty("interval")]
        public int Cycle { get; }

        /// <summary>
        /// Tipo de Interval ("weeks" ou "months")
        /// </summary>
        [JsonProperty("interval_type")]
        public string IntervalType { get; }

        /// <summary>
        /// Moeda do Preço (Somente "BRL" por enquanto)
        /// </summary>
        [JsonProperty("currency")]
        public string CurrencyTypeName { get; }

        /// <summary>
        /// Preço do Plano em Centavos
        /// </summary>
        [JsonProperty("value_cents")]
        public int ValueInCents { get; }

        /// <summary>
        /// Método de pagamento que será disponibilizado para as Faturas pertencentes a Assinaturas deste Plano ('all', 'credit_card' ou 'bank_slip')
        /// </summary>
        [JsonProperty("payable_with")]
        public string PayableWith { get; set; }

        /// <summary>
        /// Preços do Plano
        /// </summary>
        [JsonProperty("prices")]
        List<PlanPrice> Prices { get; set; }

        /// <summary>
        /// Funcionalidades do Plano
        /// </summary>
        [JsonProperty("features")]
        List<PlanFeature> Features { get; set; }

        private static Dictionary<PlanIntervalType, string> IuguAvailableInterval = new Dictionary<PlanIntervalType, string>
        {
            [PlanIntervalType.Weekly] = Constants.GenerateCycleType.WEEKLY,
            [PlanIntervalType.Monthly] = Constants.GenerateCycleType.MONTHLY
        };

        private static Dictionary<CurrencyType, string> IuguAvailableCurrency = new Dictionary<CurrencyType, string>
        {
            [CurrencyType.BRL] = Constants.CurrencyTypes.BRL,
        };


        /// <summary>
        /// Plan request message
        /// </summary>
        /// <param name="name">Nome do plano</param>
        /// <param name="uniqueIdentifier">Identificador do plano Ex: basic_plan, 1x</param>
        /// <param name="cycle">Valor positivo, que representa de quanto em quanto tempo se aplica o intervalo Ex: ciclo 1, intervalo mensal (a cada mês)</param>
        /// <param name="interval">Tipo do intervalo, Mensal ou Semanal</param>
        /// <param name="valueInCents">valor do plano em centavos</param>
        /// <param name="currency">moeda utilizada, atualmente suportamos apenas Real</param>
        public PlanRequestMessage(string name, string uniqueIdentifier, int cycle, PlanIntervalType interval, int valueInCents, CurrencyType currency)
        {
            Name = name;
            UniqueIdentifier = uniqueIdentifier;
            Cycle = cycle;
            IntervalType = IuguAvailableInterval[interval];
            ValueInCents = valueInCents;
            CurrencyTypeName = IuguAvailableCurrency[currency];
        }

        /// <summary>
        /// Plan request message
        /// </summary>
        /// <param name="name">Nome do plano</param>
        /// <param name="uniqueIdentifier">Identificador do plano Ex: basic_plan, 1x</param>
        /// <param name="cycle">De quanto em quanto tempo se aplica o intervalo Ex: ciclo 1, intervalo mensal (a cada mês)</param>
        /// <param name="interval">Tipo do intervalo, Mensal ou Semanal</param>
        /// <param name="valueInCents">valor do plano em centavos</param>
        public PlanRequestMessage(string name, string uniqueIdentifier, int cycle, PlanIntervalType interval, int valueInCents) :
            this(name, uniqueIdentifier, cycle, interval, valueInCents, CurrencyType.BRL)
        {
        }
    }
}
