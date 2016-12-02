﻿using iugu.net.Entity;
using iugu.net.Request;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using iugu.net.Entity.Lists;

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

        public async Task<CustomersModel> GetAsync()
        {
            var retorno = await GetAsync<CustomersModel>().ConfigureAwait(false);
            return retorno;
        }

        public async Task<CustomerModel> GetAsync(string id)
        {
            var retorno = await GetAsync<CustomerModel>(id).ConfigureAwait(false);
            return retorno;
        }
        
        public async Task<CustomerModel> GetFromCustomApiTokenAsync(string customApiToken)
        {
            var retorno = await GetAsync<CustomerModel>(null, customApiToken).ConfigureAwait(false);
            return retorno;
        }
        
        /// <summary>
        /// Cria um cliente em uma conta especifica
        /// </summary>
        /// <param name="request"></param>
        /// <param name="customApiToken"></param>
        /// <returns></returns>
        public async Task<CustomerModel> CreateAsync(CustomerRequestMessage request, string customApiToken = null)
        {
            var retorno = await PostAsync<CustomerModel>(request, null, customApiToken).ConfigureAwait(false);
            return retorno;
        }

        public async Task<CustomerModel> DeleteAsync(string id)
        {
            var retorno = await DeleteAsync<CustomerModel>(id).ConfigureAwait(false);
            return retorno;
        }

        public async Task<CustomerModel> PutAsync(string id, CustomerModel model)
        {
            var retorno = await PutAsync<CustomerModel>(id, model).ConfigureAwait(false);
            return retorno;
        }
    }
}
