using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iugu.Lib
{
    public class Customer : APIResource
    {
        public Customer()
        {
            BaseURI += "/customers";
        }
        public CustomersModel Get()
        {
            var retorno = GetAsync<CustomersModel>().Result;
            return retorno;
        }
        public CustomerModel Get(string id)
        {
            var retorno = GetAsync<CustomerModel>(id).Result;
            return retorno;
        }

        public CustomerModel Create(string email, string name = null, string notes = null, List<CustomVariables> custom_variables = null)
        {
            var user = new
            {
                email = email,
                name = name,
                notes = notes,
                custom_variables = custom_variables
            };
            var retorno = PostAsync<CustomerModel>(user).Result;
            return retorno;
        }
        public CustomerModel Delete(string id)
        {
            var retorno = DeleteAsync<CustomerModel>(id).Result;
            return retorno;
        }
        public CustomerModel Put(string id, CustomerModel model)
        {
            var retorno = PutAsync<CustomerModel>(id, model).Result;
            return retorno;
        }
    }
}
