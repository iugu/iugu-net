using iugu.net.Entity;
using iugu.net.Request;
using iugu.net.Response;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace iugu.net.Lib
{
    public class Plans : APIResource
    {
        public Plans()
        {
            BaseURI = "/plans";
        }

        public async Task<PaggedResponseMessage<PlanResponseMessage>> GetAllAsync()
        {
            var retorno = await GetAllAsync(null).ConfigureAwait(false);
            return retorno;
        }

        public async Task<PaggedResponseMessage<PlanResponseMessage>> GetAllAsync(string customApiToken)
        {
            var retorno = await GetAsync<PaggedResponseMessage<PlanResponseMessage>>(null, customApiToken).ConfigureAwait(false);
            return retorno;
        }
        public async Task<PlanResponseMessage> GetAsync()
        {
            var retorno = await GetAsync<PlanResponseMessage>().ConfigureAwait(false);
            return retorno;
        }
        //public async Task<PlansResponseMessage> GetAsync()
        //{
        //    var retorno = await GetAsync<PlansResponseMessage>().ConfigureAwait(false);
        //    return retorno;
        //}
        public async Task<PlanResponseMessage> GetAsync(string id, string customApiToken = null)
        {
            var retorno = await GetAsync<PlanResponseMessage>(id, customApiToken).ConfigureAwait(false);
            return retorno;
        }

        public async Task<PlanResponseMessage> GetByIdentifierAsync(string planIdentifier, string customApiToken = null)
        {
            var retorno = await GetAsync<PlanResponseMessage>(null, $"identifier/{planIdentifier}", customApiToken).ConfigureAwait(false);
            return retorno;
        }

        /// <summary>
        /// Cria um Plano possibilitando enviar um ApiToken customizado
        /// </summary>
        /// <param name="plan">todo: describe plan parameter on CreateAsync</param>
        /// <param name="customApiToken">todo: describe customApiToken parameter on CreateAsync</param>
        public async Task<PlanResponseMessage> CreateAsync(PlanRequestMessage plan, string customApiToken = null)
        {
            var retorno = await PostAsync<PlanResponseMessage>(plan, null, customApiToken).ConfigureAwait(false);
            return retorno;
        }

        public async Task<PlanResponseMessage> DeleteAsync(string id)
        {
            var retorno = await DeleteAsync(id, null).ConfigureAwait(false);
            return retorno;
        }

        public async Task<PlanResponseMessage> DeleteAsync(string id, string customApiToken)
        {
            var retorno = await DeleteAsync<PlanResponseMessage>(id, customApiToken).ConfigureAwait(false);
            return retorno;
        }

        public async Task<PlanResponseMessage> PutAsync(string id, PlanResponseMessage responseMessage)
        {
            var retorno = await PutAsync<PlanResponseMessage>(id, responseMessage).ConfigureAwait(false);
            return retorno;
        }
    }
}
