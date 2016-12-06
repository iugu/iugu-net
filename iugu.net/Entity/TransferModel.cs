using Newtonsoft.Json;

namespace iugu.net.Entity
{
    public class TransferModel
    {
        /// <summary>
        /// ID da transferência
        /// </summary>
        [JsonProperty("id")]
        public string ID { get; set; }

        /// <summary>
        /// Data de criação
        /// </summary>
        [JsonProperty("created_at")]
        public string CreatedAt { get; set; }

        /// <summary>
        /// Valor em centavos
        /// </summary>
        [JsonProperty("amount_cents")]
        public string AmountCents { get; set; }

        /// <summary>
        /// Valor localizado
        /// </summary>
        [JsonProperty("amount_localized")]
        public string AmountLocalized { get; set; }

        /// <summary>
        /// Recebedor
        /// </summary>
        [JsonProperty("receiver")]
        public Receiver Receiver { get; set; }
    }

    public class Receiver
    {
        /// <summary>
        /// ID
        /// </summary>
        [JsonProperty("id")]
        public string ID { get; set; }
        
        /// <summary>
        /// Nome
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
