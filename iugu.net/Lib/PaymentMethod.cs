using iugu.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iugu.Lib
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
            BaseURI += string.Format("/customers/{0}/payment_methods",CustomerID);
        }

        public PaymentMethodModel Get()
        {
            var retorno = GetAsync<PaymentMethodModel>().Result;
            return retorno;
        }

        public PaymentMethodModel Get(string id)
        {
            var retorno = GetAsync<PaymentMethodModel>(id).Result;
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
        public PaymentMethodModel Create(string description, CreditCard data, bool? set_as_default, string token = "", string item_type = "")
        {
            var paymentmethod = new
            {
                description = description,
                data = data,
                set_as_default = set_as_default,
                token = token,
                item_type = item_type
            };
            var retorno = PostAsync<PaymentMethodModel>(paymentmethod).Result;
            return retorno;
        }

        public PaymentMethodModel Delete(string id)
        {
            var retorno = DeleteAsync<PaymentMethodModel>(id).Result;
            return retorno;
        }

        public PaymentMethodModel Put(string id, PaymentMethodModel model)
        {
            var retorno = PutAsync<PaymentMethodModel>(id, model).Result;
            return retorno;
        }
    }
}
