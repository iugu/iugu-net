using System.Collections.Generic;
using Newtonsoft.Json;

namespace iugu.net.Entity.Lists
{
    public class InvoicesModel
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
        public List<InvoiceModel> Items { get; set; }
    }
}
