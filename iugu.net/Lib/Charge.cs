using iugu.net.Request;
using iugu.net.Response;
using System.Threading.Tasks;

namespace iugu.Lib
{
    /// <summary>
    /// Cobrança Direta
    /// Podemos efetuar uma cobrança direta de um valor, utilizando um token de cartão de crédito, uma forma de pagamento de cliente ou gerando um boleto bancário.
    /// </summary>
    public class Charge : APIResource
    {
        public Charge()
        {
            BaseURI += "/charge";
        }

        /// <summary>
        /// Cria uma nova cobrança
        /// </summary>
        /// <param name="request">Parametros para criar uma cobrança</param>
        /// <returns>Uma cobrança do tipo boleto</returns>
        public ChargeBankSlipResponseMessage Create(ChargeRequestMessage request)
        {
            var retorno = CreateAsync(request).Result;
            return retorno;
        }

        /// <summary>
        /// Cria uma nova cobrança
        /// </summary>
        /// <param name="request">Parametros para criar uma cobrança</param>
        /// <returns>Uma cobrança do tipo boleto</returns>
        public async Task<ChargeBankSlipResponseMessage> CreateAsync(ChargeRequestMessage request)
        {
            var retorno = await PostAsync<ChargeBankSlipResponseMessage>(request).ConfigureAwait(false);
            return retorno;
        }
    }
}
