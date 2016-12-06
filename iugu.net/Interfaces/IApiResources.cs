using System;
using System.Threading.Tasks;

namespace iugu.net.Interfaces
{
    /// <summary>
    /// Inteface básica de um recurso de API
    /// </summary>
    public interface IApiResources : IDisposable
    {
        string BaseURI { get; set; }

        #region GET
        Task<T> GetAsync<T>();
        Task<T> GetAsync<T>(string id);
        Task<T> GetAsync<T>(string id, string apiUserToken);
        Task<T> GetAsync<T>(string id, string partOfUrl, string apiUserToken);
        #endregion

        #region POST
        Task<T> PostAsync<T>(object data);
        Task<T> PostAsync<T>(object data, string partOfUrl);
        Task<T> PostAsync<T>(object data, string partOfUrl, string apiUserToken);
        #endregion

        #region PUT
        Task<T> PutAsync<T>(string id, object data);
        #endregion

        #region DELETE
        Task<T> DeleteAsync<T>(string id);
        #endregion
    }
}
