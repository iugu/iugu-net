using iugu.net.Lib;
using iugu.net.Request;
using iugu.net.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iugu.net.Lib
{
    public class MarketPlace : IDisposable
    {
        public readonly IApiResources Api;

        public MarketPlace() : this(new APIResource()) { }

        public MarketPlace(IApiResources api)
        {
            Api = api;
            api.BaseURI += "/marketplace";
        }

        /// <summary>
        /// Permite a criação das sub-contas gerenciadas pela conta que gerencia o marketplace.
        /// </summary>
        /// <param name="underAccount">Informações da conta que se deseja criar</param>
        /// <returns>informações da conta recém criada</returns>
        public AccountResponseMessage CreateUnderAccount(AccountRequestMessage underAccount)
        {
            var retorno = CreateUnderAccountAsync(underAccount).Result;
            return retorno;
        }

        /// <summary>
        /// Permite a criação das sub-contas gerenciadas pela conta que gerencia o marketplace.
        /// </summary>
        /// <param name="underAccount">Informações da conta que se deseja criar</param>
        /// <returns>informações da conta recém criada</returns>
        public async Task<AccountResponseMessage> CreateUnderAccountAsync(AccountRequestMessage underAccount)
        {
            var retorno = await Api.PostAsync<AccountResponseMessage>(underAccount, "create_account").ConfigureAwait(false);
            return retorno;
        }

        public void Dispose()
        {
            Api.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
