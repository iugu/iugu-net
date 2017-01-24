using System.Collections.Generic;
using iugu.net.Entity;
using Newtonsoft.Json;

namespace iugu.net.Response.Lists
{
    public class PlansResponseMessage
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("totalItems")]
        public int TotalItems { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("items")]
        public List<PlanResponseMessage> Items { get; set; }
    }
}
