using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iugu
{
    public class PlanModel
    {
        public string id { get; set; }
        public string name { get; set; }
        public string identifier { get; set; }
        public int interval { get; set; }
        public string interval_type { get; set; }
        public string created_at { get; set; }
        public string updated_at { get; set; }
        public List<Price> prices { get; set; }
        public List<Feature> features { get; set; }
    }

}
