using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iugu.net.Response.Accounts;

namespace iugu.net.Response.Lists
{
    class AccountListResponseMessage
    {
        public int totalItems { get; set; }
        public List<AccountResponseMessage> items { get; set; }

    }
}
