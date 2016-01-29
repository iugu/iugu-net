using System;
using System.Net.Http;
using System.Net.Http.Headers;
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

            if (System.Configuration.ConfigurationManager.AppSettings["iuguApiKey"] != null
                || string.IsNullOrEmpty(System.Configuration.ConfigurationManager.AppSettings["iuguApiKey"]))
            {
                _apiKey = System.Configuration.ConfigurationManager.AppSettings["iuguApiKey"];
            }
            else
            {
                throw new MissingFieldException("Chave de API não configurada. Verifique a chave iuguApiKey em AppSettings de seu arquivo .config");
            }

            _baseURI = _endpoint + "/" + _apiVersion;

            client.BaseAddress = new Uri(BaseURI);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes(_apiKey)));
        }

        public void Dispose()
        {
            client.Dispose();
            GC.SuppressFinalize(this);
        }

        protected async Task<T> GetAsync<T>()
        {
            var response = await client.GetAsync(BaseURI).ConfigureAwait(false);
            return await ProcessResponse<T>(response).ConfigureAwait(false);
        }

        protected async Task<T> GetAsync<T>(string id)
        {
            var response = await client.GetAsync(BaseURI + "/" + id).ConfigureAwait(false);
            return await ProcessResponse<T>(response).ConfigureAwait(false);
        }

        protected async Task<T> PostAsync<T>(object data)
        {
            var response = await client.PostAsJsonAsync(BaseURI, data).ConfigureAwait(false);
            return await ProcessResponse<T>(response).ConfigureAwait(false);
        }

        protected async Task<T> PutAsync<T>(string id, object data)
        {
            var response = await client.PutAsJsonAsync(BaseURI + "/" + id, data).ConfigureAwait(false);
            return await ProcessResponse<T>(response).ConfigureAwait(false);
        }

        protected async Task<T> DeleteAsync<T>(string id)
        {
            var response = await client.DeleteAsync(BaseURI + "/" + id).ConfigureAwait(false);
            return await ProcessResponse<T>(response).ConfigureAwait(false);
        }

        private static async Task<T> ProcessResponse<T>(HttpResponseMessage response)
        {
            if (response.IsSuccessStatusCode)
            {
                T data = await response.Content.ReadAsAsync<T>().ConfigureAwait(false);
                return data;
            }
            else
            {
                throw new Exception(response.ReasonPhrase);
            }
        }
    }
}
