using iugu.net.Entity;
using iugu.net.Request;
using System.Collections.Generic;
using System.Threading.Tasks;

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

        public async Task<CustomerModel> GetFromCustomApiTokenAsync(string customApiToken)
        {
            var retorno = await GetAsync<CustomerModel>(null, customApiToken).ConfigureAwait(false);
            return retorno;
        }

        /// <summary>
        /// Criar um cliente
        /// </summary>
        /// <param name="email">E-Mail do Cliente</param>
        /// <param name="name">(Opcional) Nome do Cliente</param>
        /// <param name="notes">(Opcional) Anotações Gerais do Cliente</param>
        /// <param name="custom_variables">(Opcional) Variáveis Personalizadas</param>
        /// <param name="withCopyEmail">(Opcional) Endereços de E-mail para cópia separados por vírgula.</param>
        /// <returns>O cliente criado</returns>
        public CustomerModel Create(string email, string name = null, string notes = null, List<CustomVariables> custom_variables = null, string withCopyEmail = null)
        {
            var retorno = CreateAsync(email, name, notes, custom_variables, withCopyEmail).Result;
            return retorno;
        }

        /// <summary>
        /// Criar um cliente
        /// </summary>
        /// <param name="email">E-Mail do Cliente</param>
        /// <param name="name">(Opcional) Nome do Cliente</param>
        /// <param name="notes">(Opcional) Anotações Gerais do Cliente</param>
        /// <param name="custom_variables">(Opcional) Variáveis Personalizadas</param>
        /// <param name="withCopyEmail">(Opcional) Endereços de E-mail para cópia separados por vírgula.</param>
        /// <returns>O cliente criado</returns>
        public async Task<CustomerModel> CreateAsync(string email, string name = null, string notes = null, List<CustomVariables> custom_variables = null, string withCopyEmail = null)
        {
            var user = new
            {
                email = email,
                name = name,
                notes = notes,
                cc_emails = withCopyEmail,
                custom_variables = custom_variables
            };
            var retorno = await PostAsync<CustomerModel>(user).ConfigureAwait(false);
            return retorno;
        }

        /// <summary>
        /// Cria um cliente em uma conta especifica
        /// </summary>
        /// <param name="request"></param>
        /// <param name="customApiToken"></param>
        /// <returns></returns>
        public async Task<CustomerModel> CreateAsync(CustomerRequestMessage request, string customApiToken)
        {
            var retorno = await PostAsync<CustomerModel>(request, null, customApiToken).ConfigureAwait(false);
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
