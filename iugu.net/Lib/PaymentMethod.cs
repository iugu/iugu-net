using iugu.net.Entity;
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

        [Obsolete("Sera descontinuado na versão 2.x do client, use a versão assincrona do método")]
        public PaymentMethodModel Get()
        {
            var retorno = GetAsync().Result;
            return retorno;
        }

        public async Task<PaymentMethodModel> GetAsync()
        {
            var retorno = await GetAsync<PaymentMethodModel>().ConfigureAwait(false);
            return retorno;
        }

        [Obsolete("Sera descontinuado na versão 2.x do client, use a versão assincrona do método")]
        public PaymentMethodModel Get(string id)
        {
            var retorno = GetAsync(id).Result;
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
        /// <param name="item_type">(opcional)	Tipo da Forma de Pagamento. Atualmente suportamos apenas Cartão de Crédito (tipo credit_card). Só deve ser enviado caso não envie token.</param>
        [Obsolete("Sera descontinuado na versão 2.x do client, use a versão assincrona do método")]
        public PaymentMethodModel Create(string description, CreditCard data, bool? set_as_default, string token = "", string item_type = "")
        {
            var retorno = CreateAsync(description, data, set_as_default, token, item_type).Result;
            return retorno;
        }

        /// <summary>
        /// Cria uma Forma de Pagamento de Cliente.
        /// </summary>
        /// <param name="description">Descrição</param>
        /// <param name="data">(opcional se enviar o token)	Dados da Forma de Pagamento (Em breve, este parâmetro será descontinuado. Para evitar problemas, use a partir de agora o parâmetro  token)</param>
        /// <param name="set_as_default">(opcional)	Tipo da Forma de Pagamento. Atualmente suportamos apenas Cartão de Crédito (tipo credit_card). Só deve ser enviado caso não envie token.</param>
        /// <param name="token">(opcional)	Token de Pagamento, pode ser utilizado em vez de enviar os dados da forma de pagamento</param>
        /// <param name="item_type">(opcional)	Tipo da Forma de Pagamento. Atualmente suportamos apenas Cartão de Crédito (tipo credit_card). Só deve ser enviado caso não envie token.</param>
        public async Task<PaymentMethodModel> CreateAsync(string description, CreditCard data, bool? set_as_default = null, string token = "", string item_type = "")
        {
            object paymentmethod = null;

            if (data == null && !string.IsNullOrEmpty(token))
            {
                paymentmethod = new
                {
                    description = description,
                    set_as_default = set_as_default,
                    token = token
                };
            }
            else
            {
                paymentmethod = new
                {
                    description = description,
                    data = data,
                    set_as_default = set_as_default,
                    item_type = item_type
                };
            }

            var retorno = await PostAsync<PaymentMethodModel>(paymentmethod).ConfigureAwait(false);
            return retorno;
        }

        [Obsolete("Sera descontinuado na versão 2.x do client, use a versão assincrona do método")]
        public PaymentMethodModel Delete(string id)
        {
            var retorno = DeleteAsync(id).Result;
            return retorno;
        }

        public async Task<PaymentMethodModel> DeleteAsync(string id)
        {
            var retorno = await DeleteAsync<PaymentMethodModel>(id).ConfigureAwait(false);
            return retorno;
        }

        [Obsolete("Sera descontinuado na versão 2.x do client, use a versão assincrona do método")]
        public PaymentMethodModel Put(string id, PaymentMethodModel model)
        {
            var retorno = PutAsync(id, model).Result;
            return retorno;
        }

        public async Task<PaymentMethodModel> PutAsync(string id, PaymentMethodModel model)
        {
            var retorno = await PutAsync<PaymentMethodModel>(id, model).ConfigureAwait(false);
            return retorno;
        }
    }
}
