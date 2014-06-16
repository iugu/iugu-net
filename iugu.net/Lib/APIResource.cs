using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace iugu.Lib
{
    public class APIResource : IDisposable
    {
        protected HttpClient client = new HttpClient();
        private string _version;
        private string _endpoint;
        private string _apiVersion;
        private string _apiKey;
        private string _baseURI;

        public string Version
        {
            get { return _version; }
            set { _version = value; }
        }
        public string Endpoint
        {
            get { return _endpoint; }
            set { _endpoint = value; }
        }
        public string ApiVersion
        {
            get { return _apiVersion; }
            set { _apiVersion = value; }
        }
        public string ApiKey
        {
            get { return _apiKey; }
            set { _apiKey = value; }
        }
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
                throw new Exception("Chave de API não configurada. Verifique a chave iuguApiKey em AppSettings de seu arquivo .config");
            }

            //_apiKey =

            _baseURI = Endpoint + "/" + ApiVersion;

            client.BaseAddress = new Uri(BaseURI);
            //client.DefaultRequestHeaders.Accept.Clear();
            //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes(ApiKey)));
        }

        protected async Task<T> GetAsync<T>()
        {
            HttpResponseMessage response = await client.GetAsync(BaseURI);
            if (response.IsSuccessStatusCode)
            {
                T data = await response.Content.ReadAsAsync<T>();
                return data;
            }
            else
            {
                throw new Exception(response.ReasonPhrase);
            }
        }

        protected async Task<T> GetAsync<T>(string id)
        {
            HttpResponseMessage response = await client.GetAsync(BaseURI + "/" + id);
            if (response.IsSuccessStatusCode)
            {
                T data = await response.Content.ReadAsAsync<T>();
                return data;
            }
            else
            {
                throw new Exception(response.ReasonPhrase);
            }
        }
        protected async Task<T> PostAsync<T>(object data)
        {
            HttpResponseMessage response = await client.PostAsJsonAsync(BaseURI, data);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsAsync<T>();
            }
            else
            {
                throw new Exception(response.ReasonPhrase);
            }
        }

        protected async Task<T> PutAsync<T>(string id, object data)
        {
            HttpResponseMessage response = await client.PutAsJsonAsync(BaseURI + "/" + id, data);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsAsync<T>();
            }
            else
            {
                throw new Exception(response.ReasonPhrase);
            }
        }

        protected async Task<T> DeleteAsync<T>(string id)
        {
            HttpResponseMessage response = await client.DeleteAsync(BaseURI + "/" + id);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsAsync<T>();
            }
            else
            {
                throw new Exception(response.ReasonPhrase);
            }
        }

        //public async Task RunAsync()
        //{
        //    // HTTP POST
        //    var gizmo = new Product() { Name = "Gizmo", Price = 100, Category = "Widget" };
        //    response = await client.PostAsJsonAsync("api/products", gizmo);
        //    if (response.IsSuccessStatusCode)
        //    {
        //        Uri gizmoUrl = response.Headers.Location;

        //        // HTTP PUT
        //        gizmo.Price = 80;   // Update price
        //        response = await client.PutAsJsonAsync(gizmoUrl, gizmo);

        //        // HTTP DELETE
        //        response = await client.DeleteAsync(gizmoUrl);
        //    }
        //}

        public void Dispose()
        {
            client.Dispose();
        }
    }
}
