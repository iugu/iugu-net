using Newtonsoft.Json;

namespace iugu.net.Entity
{
    public class CustomVariables
    {
        /// <summary>
        /// Nome do atributo
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Valor do atributo
        /// </summary>
        [JsonProperty("value")]
        public string Value { get; set; }
    }

    public class Logs
    {
        /// <summary>
        /// Descrição da Entrada de Log
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; set; }

        /// <summary>
        /// Anotações da Entrada de Log
        /// </summary>
        [JsonProperty("notes")]
        public string Notes { get; set; }
    }

    public class Feature
    {
        /// <summary>
        /// Nome da Funcionalidade
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Identificador único da funcionalidade
        /// </summary>
        [JsonProperty("identifier")]
        public string Identifier { get; set; }

        /// <summary>
        /// Valor da Funcionalidade (número maior que 0)
        /// </summary>
        [JsonProperty("value")]
        public int Value { get; set; }
    }

    public class Prices
    {
        /// <summary>
        /// Moeda do Preço (Somente "BRL" por enquanto)
        /// </summary>
        [JsonProperty("currency")]
        public string Currency { get; set; }

        /// <summary>
        /// Preço do Plano em Centavos
        /// </summary>
        [JsonProperty("value_cents")]
        public int ValueCents { get; set; }
    }

    public class CreditCard
    {
        /// <summary>
        /// Número do Cartão de Crédito
        /// </summary>
        [JsonProperty("number")]
        public int Number { get; set; }

        /// <summary>
        /// CVV do Cartão de Crédito
        /// </summary>
        [JsonProperty("verification_value")]
        public int VerificationValue { get; set; }

        /// <summary>
        /// Nome do Cliente como está no Cartão
        /// </summary>
        [JsonProperty("first_name")]
        public string FirstName { get; set; }

        /// <summary>
        /// Sobrenome do Cliente como está no Cartão
        /// </summary>
        [JsonProperty("last_name")]
        public string LastName { get; set; }

        /// <summary>
        /// Mês de Vencimento no Formato MM (Ex: 01, 02, 12)
        /// </summary>
        [JsonProperty("month")]
        public int Month { get; set; }

        /// <summary>
        /// Ano de Vencimento no Formato YYYY (2014, 2015, 2016)
        /// </summary>
        [JsonProperty("year")]
        public int Year { get; set; }
    }
}
