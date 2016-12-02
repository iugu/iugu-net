using iugu.net.Entity;
using iugu.net.Request;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace iugu.net.Lib
{
    public class Subscription : APIResource
    {
        public Subscription()
        {
            BaseURI = "/subscriptions";
        }

        /// <summary>
        /// Cria uma assinatura para um cliente cadastrado
        /// </summary>
        /// <param name="request">Request para criar uma assinatura</param>
        public async Task<SubscriptionModel> CreateAsync(SubscriptionRequestMessage request)
        {
            var retorno = await CreateAsync(request, null).ConfigureAwait(false);
            return retorno;
        }

        /// <summary>
        /// Cria uma assinatura para um cliente cadastrado
        /// </summary>
        /// <param name="request">Request para criar uma assinatura</param>
        /// <param name="customApiToken">Um token customizado, por exemplo, de um cliente de uma subconta, comum em marketplaces</param>
        public async Task<SubscriptionModel> CreateAsync(SubscriptionRequestMessage request, string customApiToken)
        {
            var retorno = await PostAsync<SubscriptionModel>(request, null, customApiToken).ConfigureAwait(false);
            return retorno;
        }

        public async Task<SubscriptionModel> DeleteAsync(string id, string customApiToken)
        {
            var retorno = await DeleteAsync<SubscriptionModel>(id, customApiToken).ConfigureAwait(false);
            return retorno;
        }

        public async Task<SubscriptionModel> PutAsync(string id, SubscriptionModel model)
        {
            var retorno = await PutAsync<SubscriptionModel>(id, model).ConfigureAwait(false);
            return retorno;
        }

        public async Task<SubscriptionModel> SuspendAsync(string id)
        {
            var retorno = await PostAsync<SubscriptionModel>(null, $"{id}/suspend").ConfigureAwait(false);
            return retorno;
        }

        public async Task<SubscriptionModel> ActivateAsync(string id)
        {
            var retorno = await PostAsync<SubscriptionModel>(null, $"{id}/activate").ConfigureAwait(false);
            return retorno;
        }
        
        public async Task<SubscriptionModel> ChangePlanAsync(string id, string plan_identifier)
        {
            var retorno = await PostAsync<SubscriptionModel>(null, $"{id}/change_plan/{plan_identifier}").ConfigureAwait(false);
            return retorno;
        }
        public async Task<SubscriptionModel> AddCreditsAsync(string id, int quantity)
        {
            var retorno = await PostAsync<SubscriptionModel>(null, $"{id}/add_credits/{quantity}").ConfigureAwait(false);
            return retorno;
        }
    }
}
