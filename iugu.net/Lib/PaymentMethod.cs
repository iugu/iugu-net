﻿using iugu.net.Entity;
using System;
using System.Threading.Tasks;

namespace iugu.net.Lib
{
    public class PaymentMethod : APIResource
    {
        private string _customerID;

        public string CustomerID
        {
            get { return _customerID; }
            set { _customerID = value; }
        }


        public PaymentMethod(string customerid)
        {
            _customerID = customerid;
            BaseURI = string.Format("/customers/{0}/payment_methods", CustomerID);
        }

        
        public async Task<PaymentMethodModel> GetAsync()
        {
            var retorno = await GetAsync<PaymentMethodModel>().ConfigureAwait(false);
            return retorno;
        }

        public async Task<PaymentMethodModel> GetAsync(string id)
        {
            var retorno = await GetAsync<PaymentMethodModel>(id).ConfigureAwait(false);
            return retorno;
        }

        
        /// <summary>
        /// Cria uma Forma de Pagamento de Cliente.
        /// </summary>
        /// <param name="description">Descrição</param>
        /// <param name="data">Dados da Forma de Pagamento</param>
        /// <param name="set_as_default">(opcional)	Tipo da Forma de Pagamento. Atualmente suportamos apenas Cartão de Crédito (tipo credit_card). Só deve ser enviado caso não envie token.</param>
        /// <param name="token">(opcional)	Token de Pagamento, pode ser utilizado em vez de enviar os dados da forma de pagamento</param>
        /// <param name="item_type">(opcional)	Transforma a forma de pagamento na padrão do cliente</param>
        public async Task<PaymentMethodModel> CreateAsync(string description, CreditCard data, bool? set_as_default, string token = "", string item_type = "")
        {
            var paymentmethod = new
            {
                description = description,
                data = data,
                set_as_default = set_as_default,
                token = token,
                item_type = item_type
            };
            var retorno = await PostAsync<PaymentMethodModel>(paymentmethod).ConfigureAwait(false);
            return retorno;
        }

        public async Task<PaymentMethodModel> DeleteAsync(string id)
        {
            var retorno = await DeleteAsync<PaymentMethodModel>(id).ConfigureAwait(false);
            return retorno;
        }

        public async Task<PaymentMethodModel> PutAsync(string id, PaymentMethodModel model)
        {
            var retorno = await PutAsync<PaymentMethodModel>(id, model).ConfigureAwait(false);
            return retorno;
        }
    }
}
