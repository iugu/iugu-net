using System.Collections.Generic;
using Newtonsoft.Json;

namespace iugu.net.Response.Lists
{
    public class InvoicesResponseMessage
    {
        // TODO: Adicionar descrições
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("facets")]
        public Facets Facets { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("totalItems")]
        public int TotalItems { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("items")]
        public List<InvoiceResponseMessage> Items { get; set; }
    }
}
