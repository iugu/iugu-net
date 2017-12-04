using System.Collections.Generic;
using Newtonsoft.Json;

namespace iugu.net.Entity
{
    /// <summary>
    /// Model que representa dados do cliente
    /// </summary>
    public class CustomerModel
    {
        /// <summary>
        /// ID do clinte
        /// </summary>
        [JsonProperty("id")]
        public string ID { get; set; }
        /// <summary>
        /// Email do cliente
        /// </summary>
        [JsonProperty("email")]
        public string Email { get; set; }
        /// <summary>
        /// Nome do cliente (opcional)
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }
        /// <summary>
        /// Anotações Gerais do Cliente (opcional)
        /// </summary>
        [JsonProperty("notes")]
        public string Notes { get; set; }
        /// <summary>
        /// Data de criação do Cliente (opcional)
        /// </summary>
        [JsonProperty("created_at")]
        public string CreatedAt { get; set; }
        /// <summary>
        /// Data de modificação do Cliente (opcional)
        /// </summary>
        [JsonProperty("updated_at")]
        public string UpdatedAt { get; set; }
        /// <summary>
        /// Variáveis Personalizadas do Cliente (opcional)
        /// </summary>
        [JsonProperty("custom_variables")]
        public List<object> CustomVariables { get; set; }

        [JsonProperty("zip_code")]
        public string zip_code { get; set; }

        [JsonProperty("number")]
        public int number { get; set; }

        [JsonProperty("complement")]
        public string complement { get; set; }

        [JsonProperty("cpf_cnpj")]
        public string cpf_cnpj { get; set; }
    }
}
