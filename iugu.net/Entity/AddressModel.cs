using Newtonsoft.Json;

namespace iugu.net.Entity
{
    /// <summary>
    /// Model que representa dados de endereço
    /// </summary>
    public class AddressModel
    {
        /// <summary>
        /// Rua
        /// </summary>
        [JsonProperty("street")]
        public string Street { get; set; }

        /// <summary>
        /// Número
        /// </summary>
        [JsonProperty("number")]
        public string Number { get; set; }

        /// <summary>
        /// Cidade
        /// </summary>
        [JsonProperty("city")]
        public string City { get; set; }

        /// <summary>
        /// Estado (Ex: SP)
        /// </summary>
        [JsonProperty("state")]
        public string State { get; set; }

        /// <summary>
        /// País
        /// </summary>
        [JsonProperty("country")]
        public string Country { get; set; }

        /// <summary>
        /// CEP
        /// </summary>
        [JsonProperty("zip_code")]
        public string ZipCode { get; set; }
    }
}
