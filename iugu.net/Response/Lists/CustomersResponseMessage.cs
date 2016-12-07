using System.Collections.Generic;

namespace iugu.net.Response.Lists
{
    public class CustomersResponseMessage
    {
        public int totalItems { get; set; }
        public List<CustomerResponseMessage> items { get; set; }
    }
}
