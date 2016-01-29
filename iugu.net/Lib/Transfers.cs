using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iugu.Lib
{
    class Transfers : APIResource
    {
        public Transfers()
        {
            BaseURI += "/transfers";
        }

        public TransferModel Get()
        {
            var retorno = GetAsync().Result;
            return retorno;
        }

        public async Task<TransferModel> GetAsync()
        {
            var retorno = await GetAsync<TransferModel>().ConfigureAwait(false);
            return retorno;
        }

        /// <summary>
        /// Transfere um determinado valor de sua conta para a conta destino.
        /// </summary>
        /// <param name="receiver_id">Account ID da conta que irá receber o valor</param>
        /// <param name="amount_cents">Valor a transferir em centavos</param>
        /// <returns></returns>
        public TransferModel Create(string receiver_id, int amount_cents)
        {
            var retorno = CreateAsync(receiver_id, amount_cents).Result;
            return retorno;
        }

        /// <summary>
        /// Transfere um determinado valor de sua conta para a conta destino.
        /// </summary>
        /// <param name="receiver_id">Account ID da conta que irá receber o valor</param>
        /// <param name="amount_cents">Valor a transferir em centavos</param>
        /// <returns></returns>
        public async Task<TransferModel> CreateAsync(string receiver_id, int amount_cents)
        {
            var user = new
            {
                receiver_id = receiver_id,
                amount_cents = amount_cents
            };
            var retorno = await PostAsync<TransferModel>(user).ConfigureAwait(false);
            return retorno;
        }
    }
}
