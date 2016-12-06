using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using iugu.net.Interfaces;

namespace iugu.net.Lib
{
    /// <summary>
    /// Wrapper em cima do HttpClient que provê maior testabilidade e permite inclisive a substituição por qualquer
    /// outra implementação que o consumidor do client queira.
    /// </summary>
    

    /// <summary>
    /// Implementação padrão da interface IHpptClientWrapper da IUGU
    /// </summary>
    public class StandardHttpClient : IHttpClientWrapper
    {
        private readonly HttpClient client;

        public StandardHttpClient()
        {
            client = new HttpClient();
            client.DefaultRequestHeaders
                  .Accept
                  .Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        /// <summary>
        /// Enviar uma requisição
        /// </summary>
        /// <param name="requestMessage">Dados da mensagem da requisição</param>
        /// <returns>resposta da requisição</returns>
        public async Task<HttpResponseMessage> SendAsync(HttpRequestMessage requestMessage)
        {
            var response = await client.SendAsync(requestMessage).ConfigureAwait(false);
            return response;
        }

        public void Dispose()
        {
            client.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
