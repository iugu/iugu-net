using iugu.net.Entity;
using iugu.net.Request;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using iugu.net.Response;
using iugu.net.Response.Lists;

namespace iugu.net.Lib
{
    /// <summary>
    /// Utilizando o objeto cliente você pode controlar os pagamentos feito por um cliente específico, bem como controlar os dados de contato desse cliente. 
    /// Também permite a criação de formas de pagamento desse cliente para que então o pagamento recorrente (assinatura) possa ser automatizado utilizando a 
    /// forma de pagamento padrão deste cliente.
    /// </summary>
    public class Customer : APIResource
    {
        public Customer()
        {
            BaseURI = "/customers";
        }

        public async Task<CustomersResponseMessage> GetAsync()
        {
            var retorno = await GetAsync<CustomersResponseMessage>().ConfigureAwait(false);
            return retorno;
        }

        public async Task<CustomerResponseMessage> GetAsync(string id)
        {
            var retorno = await GetAsync<CustomerResponseMessage>(id).ConfigureAwait(false);
            return retorno;
        }
        
        public async Task<CustomerResponseMessage> GetFromCustomApiTokenAsync(string customApiToken)
        {
            var retorno = await GetAsync<CustomerResponseMessage>(null, customApiToken).ConfigureAwait(false);
            return retorno;
        }
        
        /// <summary>
        /// Cria um cliente em uma conta especifica
        /// </summary>
        /// <param name="request"></param>
        /// <param name="customApiToken"></param>
        /// <returns></returns>
        public async Task<CustomerResponseMessage> CreateAsync(CustomerRequestMessage request, string customApiToken = null)
        {
            var retorno = await PostAsync<CustomerResponseMessage>(request, null, customApiToken).ConfigureAwait(false);
            return retorno;
        }

        public async Task<CustomerResponseMessage> DeleteAsync(string id)
        {
            var retorno = await DeleteAsync<CustomerResponseMessage>(id).ConfigureAwait(false);
            return retorno;
        }

        public async Task<CustomerResponseMessage> PutAsync(string id, CustomerResponseMessage responseMessage)
        {
            var retorno = await PutAsync<CustomerResponseMessage>(id, responseMessage).ConfigureAwait(false);
            return retorno;
        }
    }
}
