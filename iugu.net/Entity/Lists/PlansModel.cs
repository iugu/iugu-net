using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace iugu.net.Entity.Lists
{
    public class PlansModel
    {
        [JsonProperty("totalItems")]
        public int TotalItems { get; set; }
        [JsonProperty("items")]
        public List<PlanModel> Items { get; set; }
    }
}
