using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace  iugu.net.Entity
{
    public class CustomersModel
    {
        public int totalItems { get; set; }
        public List<CustomerModel> items { get; set; }
    }

    public class CustomerModel
    {
        public string id { get; set; }
        public string email { get; set; }
        public string name { get; set; }
        public string notes { get; set; }
        public string created_at { get; set; }
        public string updated_at { get; set; }
        public List<object> custom_variables { get; set; }
    }
}
