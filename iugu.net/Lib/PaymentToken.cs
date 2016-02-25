using Newtonsoft.Json;
using System.Threading.Tasks;

namespace iugu.net.Lib
{
    /// <summary>
    /// O processo para cobrança transparente funciona da seguinte maneira:
    /// Primeiramente, os dados de cartão de crédito do cliente são enviados a Iugu através que conexão segura SSL.A Iugu então retorna um token que representa o meio de pagamento desse cliente.
    // Esse token é então utilizado para que seja feita uma cobrança através deste meio de pagamento.
    /// Pronto! Pagamento efetuado!
    /// </summary>
    public class PaymentToken : APIResource
    {
        public PaymentToken()
        {
            BaseURI += "/payment_token";
        }

        /// <summary>
        /// O Token é uma representação do meio de pagamento do cliente (por ex: seu cartão de crédito), sendo totalmente seguro, de forma que não é possível que 
        /// alguém consiga as informações do cartão de crédito do cliente utilizando esse token. O token é gerado para uma transação específica, tornando-o ainda mais seguro.
        /// <see cref="https://iugu.com/referencias/api#tokens-e-cobranca-direta"/>
        /// </summary>
        /// <param name="request">Parametros de entrada da request</param>
        /// <returns>Resposta da Api para o PaymentToken</returns>
        public PaymentTokenResponse Create(PaymentTokenRequest request)
        {
            var retorno = CreateAsync(request).Result;
            return retorno;
        }

        /// <summary>
        /// O Token é uma representação do meio de pagamento do cliente (por ex: seu cartão de crédito), sendo totalmente seguro, de forma que não é possível que 
        /// alguém consiga as informações do cartão de crédito do cliente utilizando esse token. O token é gerado para uma transação específica, tornando-o ainda mais seguro.
        /// <see cref="https://iugu.com/referencias/api#tokens-e-cobranca-direta"/>
        /// </summary>
        /// <param name="request">Parametros de entrada da request</param>
        /// <returns>Resposta da Api para o PaymentToken</returns>
        public async Task<PaymentTokenResponse> CreateAsync(PaymentTokenRequest request)
        {
            var retorno = await PostAsync<PaymentTokenResponse>(request).ConfigureAwait(false);
            return retorno;
        }
    }

    public class PaymentTokenRequest
    {
        /// <summary>
        /// ID de sua Conta na Iugu (O ID de sua conta pode ser encontrado clicando na referência)
        /// <see cref="https://iugu.com/settings/account"/>
        /// </summary>
        [JsonProperty("account_id")]
        public string AccountId { get; set; }

        /// <summary>
        /// Método de Pagamento (atualmente somente credit_card)
        /// </summary>
        [JsonProperty("method")]
        public string Method { get; set; }

        /// <summary>
        /// Valor true para criar tokens de teste
        /// </summary>
        [JsonProperty("test")]
        public bool Test { get; set; }

        /// <summary>
        /// Dados do Método de Pagamento
        /// </summary>
        [JsonProperty("data")]
        public PaymentInfoModel PaymentData { get; set; }

    }

    public class PaymentInfoModel
    {
        /// <summary>
        /// Número do Cartão de Crédito
        /// </summary>
        [JsonProperty("number")]
        public string Number { get; set; }

        /// <summary>
        /// CVV do Cartão de Crédito
        /// </summary>
        [JsonProperty("verification_value")]
        public string VerificationValue { get; set; }

        /// <summary>
        /// Nome do Cliente como está no Cartão
        /// </summary>
        [JsonProperty("first_name")]
        public string FirstName { get; set; }

        /// <summary>
        /// Sobrenome do Cliente como está no Cartão
        /// </summary>
        [JsonProperty("last_name")]
        public string LastName { get; set; }

        /// <summary>
        /// Mês de Vencimento no Formato MM (Ex: 01, 02, 12)
        /// </summary>
        [JsonProperty("month")]
        public string Month { get; set; }

        /// <summary>
        /// Ano de Vencimento no Formato YYYY (2014, 2015, 2016)
        /// </summary>
        [JsonProperty("year")]
        public string Year { get; set; }
    }


    public class PaymentTokenResponse
    {
        /// <summary>
        /// Token Criado
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// Método de Pagamento (atualmente somente credit_card)
        /// </summary>
        [JsonProperty("method")]
        public string Method { get; set; }
    }

}
