using iugu.Entity;
using System.Collections.Generic;
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
            var retorno = GetAsync().Result;
            return retorno;
        }

        public async Task<CustomersModel> GetAsync()
        {
            var retorno = await GetAsync<CustomersModel>().ConfigureAwait(false);
            return retorno;
        }

        public CustomerModel Get(string id)
        {
            var retorno = GetAsync(id).Result;
            return retorno;
        }

        public async Task<CustomerModel> GetAsync(string id)
        {
            var retorno = await GetAsync<CustomerModel>(id).ConfigureAwait(false);
            return retorno;
        }

        public CustomerModel Create(string email, string name = null, string notes = null, List<CustomVariables> custom_variables = null)
        {
            var retorno = CreateAsync(email, name, notes, custom_variables).Result;
            return retorno;
        }

        public async Task<CustomerModel> CreateAsync(string email, string name = null, string notes = null, List<CustomVariables> custom_variables = null)
        {
            var user = new
            {
                email = email,
                name = name,
                notes = notes,
                custom_variables = custom_variables
            };
            var retorno = await PostAsync<CustomerModel>(user).ConfigureAwait(false);
            return retorno;
        }

        public CustomerModel Delete(string id)
        {
            var retorno = DeleteAsync(id).Result;
            return retorno;
        }

        public async Task<CustomerModel> DeleteAsync(string id)
        {
            var retorno = await DeleteAsync<CustomerModel>(id).ConfigureAwait(false);
            return retorno;
        }

        public CustomerModel Put(string id, CustomerModel model)
        {
            var retorno = PutAsync(id, model).Result;
            return retorno;
        }

        public async Task<CustomerModel> PutAsync(string id, CustomerModel model)
        {
            var retorno = await PutAsync<CustomerModel>(id, model).ConfigureAwait(false);
            return retorno;
        }
    }
}
