using iugu.net.Entity;
using iugu.net.Request;
using iugu.net.Response;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using iugu.net.Entity.Lists;

namespace iugu.net.Lib
{
    public class Plans : APIResource
    {
        public Plans()
        {
            BaseURI = "/plans";
        }

        public async Task<PaggedResponseMessage<PlanModel>> GetAllAsync()
        {
            var retorno = await GetAllAsync(null).ConfigureAwait(false);
            return retorno;
        }

        public async Task<PaggedResponseMessage<PlanModel>> GetAllAsync(string customApiToken)
        {
            var retorno = await GetAsync<PaggedResponseMessage<PlanModel>>(null, customApiToken).ConfigureAwait(false);
            return retorno;
        }
        public async Task<PlanModel> GetAsync()
        {
            var retorno = await GetAsync<PlanModel>().ConfigureAwait(false);
            return retorno;
        }
        //public async Task<PlansModel> GetAsync()
        //{
        //    var retorno = await GetAsync<PlansModel>().ConfigureAwait(false);
        //    return retorno;
        //}
        public async Task<PlanModel> GetAsync(string id, string customApiToken = null)
        {
            var retorno = await GetAsync<PlanModel>(id, customApiToken).ConfigureAwait(false);
            return retorno;
        }

        public async Task<PlanModel> GetByIdentifierAsync(string planIdentifier, string customApiToken = null)
        {
            var retorno = await GetAsync<PlanModel>(null, $"identifier/{planIdentifier}", customApiToken).ConfigureAwait(false);
            return retorno;
        }

        /// <summary>
        /// Cria um Plano possibilitando enviar um ApiToken customizado
        /// </summary>
        /// <param name="plan">todo: describe plan parameter on CreateAsync</param>
        /// <param name="customApiToken">todo: describe customApiToken parameter on CreateAsync</param>
        public async Task<PlanModel> CreateAsync(PlanRequestMessage plan, string customApiToken = null)
        {
            var retorno = await PostAsync<PlanModel>(plan, null, customApiToken).ConfigureAwait(false);
            return retorno;
        }

        public async Task<PlanModel> DeleteAsync(string id)
        {
            var retorno = await DeleteAsync(id, null).ConfigureAwait(false);
            return retorno;
        }

        public async Task<PlanModel> DeleteAsync(string id, string customApiToken)
        {
            var retorno = await DeleteAsync<PlanModel>(id, customApiToken).ConfigureAwait(false);
            return retorno;
        }

        public async Task<PlanModel> PutAsync(string id, PlanModel model)
        {
            var retorno = await PutAsync<PlanModel>(id, model).ConfigureAwait(false);
            return retorno;
        }
    }
}
