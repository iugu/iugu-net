using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace iugu.net.Lib
{
    /// <summary>
    /// Wrapper em cima do HttpClient que provê maior testabilidade e permite inclisive a substituição por qualquer
    /// outra implementação que o consumidor do client queira.
    /// </summary>
    public interface IHttpClientWrapper : IDisposable
    {
        Task<HttpResponseMessage> SendAsync(HttpRequestMessage request);
    }

    /// <summary>
    /// Implementação padrão da interface IHpptClientWrapper da IUGU
    /// </summary>
    public class StandardHttpClient : IHttpClientWrapper
    {
        private readonly HttpClient client;

        public StandardHttpClient()
        {
            client = new HttpClient();
        }
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
