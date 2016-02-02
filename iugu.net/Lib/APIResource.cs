using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace iugu.Lib
{
    public class APIResource : IDisposable
    {
        protected HttpClient client = new HttpClient();
        private readonly string _version;
        private readonly string _endpoint;
        private readonly string _apiVersion;
        private readonly string _apiKey;
        private string _baseURI;


        public string BaseURI
        {
            get { return _baseURI; }
            set { _baseURI = value; }
        }

        public APIResource()
        {
            _version = "1.0.5";
            _apiVersion = "v1";
            _endpoint = "https://api.iugu.com";
            _apiKey = System.Configuration.ConfigurationManager.AppSettings["iuguApiKey"];

            if (string.IsNullOrEmpty(_apiKey))
            {
                throw new MissingFieldException("Chave de API não configurada. Verifique a se a chave iuguApiKey com seu token está presente no seu arquivo .config");
            }

            _baseURI = _endpoint + "/" + _apiVersion;
        }

        public void Dispose()
        {
            client.Dispose();
            GC.SuppressFinalize(this);
        }

        protected async Task<T> GetAsync<T>()
        {
            var response = await SendRequestAsync(HttpMethod.Get, BaseURI).ConfigureAwait(false);
            return await ProcessResponse<T>(response).ConfigureAwait(false);
        }

        protected async Task<T> GetAsync<T>(string id)
        {
            var response = await SendRequestAsync(HttpMethod.Get, BaseURI + "/" + id).ConfigureAwait(false);
            return await ProcessResponse<T>(response).ConfigureAwait(false);
        }

        protected async Task<T> PostAsync<T>(object data)
        {
            var response = await SendRequestAsync(HttpMethod.Post, BaseURI, data).ConfigureAwait(false);
            return await ProcessResponse<T>(response).ConfigureAwait(false);
        }

        protected async Task<T> PutAsync<T>(string id, object data)
        {
            var response = await SendRequestAsync(HttpMethod.Put, BaseURI + "/" + id, data).ConfigureAwait(false);
            return await ProcessResponse<T>(response).ConfigureAwait(false);
        }

        protected async Task<T> DeleteAsync<T>(string id)
        {
            var response = await SendRequestAsync(HttpMethod.Delete, BaseURI + "/" + id).ConfigureAwait(false);
            return await ProcessResponse<T>(response).ConfigureAwait(false);
        }

        private static async Task<T> ProcessResponse<T>(HttpResponseMessage response)
        {
            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsAsync<T>().ConfigureAwait(false);
                return data;
            }
            else
            {
                throw new Exception(response.ReasonPhrase);
            }
        }
        private async Task<HttpResponseMessage> SendRequestAsync(HttpMethod method, string url, object data = null)
        {
            var jsonSettings = new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore };

            using (var requestMessage = new HttpRequestMessage(method, url))
            {
                requestMessage.Headers.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.ASCII.GetBytes(_apiKey)));

                if (data != null)
                {
                    var content = await Task.Factory.StartNew(() => JsonConvert.SerializeObject(data, jsonSettings)).ConfigureAwait(false);
                    requestMessage.Content = new StringContent(content, Encoding.UTF8, "application/json");
                }

                var response = await client.SendAsync(requestMessage).ConfigureAwait(false);
                return response;
            }
        }
    }
}
