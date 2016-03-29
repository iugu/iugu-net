using iugu.net.Lib;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace iugu.net.IntegratedTests.Stubs
{
    public class StubHttpClient : IHttpClientWrapper
    {
        private readonly HttpContent _expectedResponse;
        private readonly TimeSpan _responseDelay;
        private readonly HttpClient _client;

        public StubHttpClient(HttpContent expectedResponse) : this(expectedResponse, TimeSpan.FromMilliseconds(0)) { }

        public StubHttpClient(HttpContent expectedResponse, TimeSpan responseDelay)
        {
            _client = new HttpClient();
            _responseDelay = responseDelay;
            _expectedResponse = expectedResponse;
        }
        public async Task<HttpResponseMessage> SendAsync(HttpRequestMessage requestMessage)
        {
            return await Task.Factory.StartNew(() =>
            {
                Task.Delay(_responseDelay);
                return new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = _expectedResponse,
                    RequestMessage = requestMessage,
                };
            }).ConfigureAwait(false);
        }

        public void Dispose()
        {
            _client.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
