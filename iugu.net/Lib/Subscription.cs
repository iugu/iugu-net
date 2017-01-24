using iugu.net.Entity;
using iugu.net.Request;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using iugu.net.Response;

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
        public async Task<SubscriptionResponseMessage> CreateAsync(SubscriptionRequestMessage request)
        {
            var retorno = await CreateAsync(request, null).ConfigureAwait(false);
            return retorno;
        }

        /// <summary>
        /// Cria uma assinatura para um cliente cadastrado
        /// </summary>
        /// <param name="request">Request para criar uma assinatura</param>
        /// <param name="customApiToken">Um token customizado, por exemplo, de um cliente de uma subconta, comum em marketplaces</param>
        public async Task<SubscriptionResponseMessage> CreateAsync(SubscriptionRequestMessage request, string customApiToken)
        {
            var retorno = await PostAsync<SubscriptionResponseMessage>(request, null, customApiToken).ConfigureAwait(false);
            return retorno;
        }

        public async Task<SubscriptionResponseMessage> DeleteAsync(string id, string customApiToken)
        {
            var retorno = await DeleteAsync<SubscriptionResponseMessage>(id, customApiToken).ConfigureAwait(false);
            return retorno;
        }

        public async Task<SubscriptionResponseMessage> PutAsync(string id, SubscriptionResponseMessage responseMessage)
        {
            var retorno = await PutAsync<SubscriptionResponseMessage>(id, responseMessage).ConfigureAwait(false);
            return retorno;
        }

        public async Task<SubscriptionResponseMessage> SuspendAsync(string id)
        {
            var retorno = await PostAsync<SubscriptionResponseMessage>(null, $"{id}/suspend").ConfigureAwait(false);
            return retorno;
        }

        public async Task<SubscriptionResponseMessage> ActivateAsync(string id)
        {
            var retorno = await PostAsync<SubscriptionResponseMessage>(null, $"{id}/activate").ConfigureAwait(false);
            return retorno;
        }
        
        public async Task<SubscriptionResponseMessage> ChangePlanAsync(string id, string plan_identifier)
        {
            var retorno = await PostAsync<SubscriptionResponseMessage>(null, $"{id}/change_plan/{plan_identifier}").ConfigureAwait(false);
            return retorno;
        }
        public async Task<SubscriptionResponseMessage> AddCreditsAsync(string id, int quantity)
        {
            var retorno = await PostAsync<SubscriptionResponseMessage>(null, $"{id}/add_credits/{quantity}").ConfigureAwait(false);
            return retorno;
        }
    }
}
