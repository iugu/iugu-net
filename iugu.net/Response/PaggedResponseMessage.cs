using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iugu.net.Response
{
    public class PaggedResponseMessage<T> where T : class, new()
    {
        public int TotalItems { get; set; }
        public T[] Items { get; set; }
    }
}
