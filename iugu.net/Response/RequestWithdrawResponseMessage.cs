using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;

namespace iugu.net.Response
{
    public class RequestWithdrawResponseMessage
    {
        [JsonProperty("id")]
        public string OperationId { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("updated_at")]
        public DateTime UpdatedAt { get; set; }

        [JsonProperty("reference")]
        public object Reference { get; set; }

        [JsonProperty("amount")]
        public string Amount { get; set; }

        [JsonProperty("account_name")]
        public string AccountName { get; set; }

        [JsonProperty("account_id")]
        public string AccountId { get; set; }

        [JsonProperty("bank_address")]
        [JsonConverter(typeof(ObjectAsStringWithAddictionalQuotesConverter<BankInfo>))]
        public BankInfo BankInfo { get; set; }
    }

    public class BankInfo
    {

        /// <summary>
        /// Nome da instituição bancária 
        /// Suportados : 'Itaú', 'Bradesco', 'Caixa Econômica', 'Banco do Brasil', 'Santander'
        /// </summary>
        [JsonProperty("bank")]
        public string Name { get; set; }

        /// <summary>
        /// Número da Conta
        /// Formatos (99999999-D, XXX99999999-D onde X é Operação, 	9999999-D, 99999-D)
        /// </summary>
        [JsonProperty("bank_cc")]
        public string AccountNumber { get; set; }

        /// <summary>
        /// Agência da Conta
        /// Formatos (9999-D, 9999)
        /// </summary>
        [JsonProperty("bank_ag")]
        public string AgencyNumber { get; set; }

        /// <summary>
        /// Tipo da conta: 'Corrente', 'Poupança'
        /// </summary>
        [JsonProperty("account_type")]
        public string AccountType { get; set; }
    }

    public class ObjectAsStringWithAddictionalQuotesConverter<T> : CustomCreationConverter<T> where T : class, new()
    {
        public override T Create(Type objectType)
        {
            return new T();
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var contentValue = (reader.Value as string).Replace("\"{", "{").Replace("}\"", "}");

            using (var textReader = new StringReader(contentValue))
            using (var jsonTextReader = new JsonTextReader(textReader))
            {
                return base.ReadJson(jsonTextReader, objectType, existingValue, serializer);
            }
        }
    }
}
