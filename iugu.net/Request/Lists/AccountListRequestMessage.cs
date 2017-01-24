using Newtonsoft.Json;

namespace iugu.net.Request.Lists
{
    /// <summary>
    /// Request para a chamada GET https://api.iugu.com/v1/marketplace/
    /// </summary>
    public class AccountListRequestMessage
    {
        /// <summary>
        /// (opcional) Limita em até 1.000 o número de registros listados. Caso não seja enviado, aplica-se o limite padrão de 100 registros
        /// </summary>
        [JsonProperty("limit")]
        public string Limit { get; set; }

        /// <summary>
        /// (opcional) Quantos registros pular do início da pesquisa (muito utilizado para paginação)
        /// </summary>
        [JsonProperty("start")]
        public string Start { get; set; }

        /// <summary>
        /// (opcional) 	Neste parâmetro pode ser passado um texto para pesquisa
        /// </summary>
        [JsonProperty("query")]
        public string Query { get; set; }
    }
}