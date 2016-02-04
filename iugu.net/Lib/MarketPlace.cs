using iugu.Lib;
using iugu.net.Request;
using iugu.net.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iugu.net.Lib
{
    public class MarketPlace : APIResource
    {
        public MarketPlace()
        {
            BaseURI += "/marketplace";
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
            var retorno = await PostAsync<AccountResponseMessage>(underAccount, "create_account").ConfigureAwait(false);
            return retorno;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="underAccountData"></param>
        /// <returns></returns>
        public VerifyAccountResponseMessage VerifyUnderAccount(VerifyAccountRequestMessage underAccountData)
        {
            var retorno = VerifyUnderAccountAsync(underAccountData).Result;
            return retorno;
        }

        public async Task<VerifyAccountResponseMessage> VerifyUnderAccountAsync(VerifyAccountRequestMessage underAccountData)
        {
            var retorno = await PostAsync<VerifyAccountResponseMessage>(underAccountData, "request_verification").ConfigureAwait(false);
            return retorno;
        }

    }
}
