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

        //limit (opcional)	Máximo de registros retornados
        //start (opcional)	Quantos registros pular do início da pesquisa (muito utilizado para paginação)
        //created_at_from (opcional)	Registros criados a partir desta data passada no parâmetro
        //created_at_to (opcional)	Registros criados até esta data passada no parâmetro
        //query (opcional)	Neste parâmetro pode ser passado um texto para pesquisa
        //updated_since (opcional)	Registros atualizados desde o valor passado no parâmetro
        //sortBy (opcional)	Um hash sendo a chave o nome do campo para ordenação e o valor sendo DESC ou ASC para descendente e ascendente, respectivamente
        //customer_id (opcional)	ID do Cliente
        [Obsolete("Sera descontinuado na versão 2.x do client, use a versão assincrona do método")]
        public SubscriptionModel Get()
        {
            var retorno = GetAsync<SubscriptionModel>().Result;
            return retorno;
        }

        [Obsolete("Sera descontinuado na versão 2.x do client, use a versão assincrona do método")]
        public SubscriptionModel Get(string id)
        {
            var retorno = GetAsync<SubscriptionModel>(id).Result;
            return retorno;
        }

        /// <summary>
        /// Cria uma assinatura para um cliente cadastrado
        /// </summary>
        /// <param name="customer_id">Identifucação do cliente</param>
        /// <param name="plan_identifier">Identificação do plano de pagamento</param>
        /// <param name="expires_at">Data de Expiração (Também é a data da próxima cobrança)</param>
        /// <param name="only_on_charge_success">Apenas Cria a Assinatura se a Cobrança for bem sucedida. Isso só funciona caso o cliente já tenha uma forma de pagamento padrão cadastrada</param>
        /// <param name="credits_based">É uma assinatura baseada em créditos</param>
        /// <param name="price_cents">Preço em centavos da recarga para assinaturas baseadas em crédito</param>
        /// <param name="credits_cycle">Quantidade de créditos adicionados a cada ciclo, só enviado para assinaturas credits_based</param>
        /// <param name="credits_min">Quantidade de créditos que ativa o ciclo, por ex: Efetuar cobrança cada vez que a assinatura tenha apenas 1 crédito sobrando. Esse 1 crédito é o credits_min</param>
        /// <param name="subitems">Itens de assinatura, sendo que estes podem ser recorrentes ou de cobrança única</param>
        /// <param name="custom_variables">Variáveis Personalizadas</param>
        /// <returns></returns>
        [Obsolete("Sera descontinuado na versão 2.x do client, use a versão assincrona do método que recebe SubscriptionRequestMessage como parametro")]
        public SubscriptionModel Create(string customer_id, string plan_identifier = null, DateTime? expires_at = null,
            bool? only_on_charge_success = null,
            bool? credits_based = null, int? price_cents = null, int? credits_cycle = null, int? credits_min = null,
            List<SubscriptionSubitem> subitems = null, List<CustomVariables> custom_variables = null)
        {
            var subscription = new
            {
                customer_id = customer_id,
                plan_identifier = plan_identifier,
                expires_at = expires_at,
                only_on_charge_success = only_on_charge_success,
                credits_based = credits_based,
                price_cents = price_cents,
                credits_cycle = credits_cycle,
                credits_min = credits_min,
                subitems = subitems,
                custom_variables = custom_variables
            };
            var retorno = PostAsync<SubscriptionModel>(subscription).Result;
            return retorno;
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

        [Obsolete("Sera descontinuado na versão 2.x do client, use a versão assincrona do método")]
        public SubscriptionModel Delete(string id)
        {
            var retorno = DeleteAsync(id, null).Result;
            return retorno;
        }

        public async Task<SubscriptionModel> DeleteAsync(string id, string customApiToken)
        {
            var retorno = await DeleteAsync<SubscriptionModel>(id, customApiToken).ConfigureAwait(false);
            return retorno;
        }

        [Obsolete("Sera descontinuado na versão 2.x do client, use a versão assincrona do método")]
        public SubscriptionModel Put(string id, SubscriptionModel model)
        {
            var retorno = PutAsync(id, model).Result;
            return retorno;
        }

        public async Task<SubscriptionModel> PutAsync(string id, SubscriptionModel model)
        {
            var retorno = await PutAsync<SubscriptionModel>(id, model).ConfigureAwait(false);
            return retorno;
        }

        [Obsolete("Sera descontinuado na versão 2.x do client, use a versão assincrona do método")]
        public SubscriptionModel Suspend(string id)
        {
            var retorno = SuspendAsync(id).Result;
            return retorno;
        }

        public async Task<SubscriptionModel> SuspendAsync(string id)
        {
            var retorno = await PostAsync<SubscriptionModel>(null, $"{id}/suspend").ConfigureAwait(false);
            return retorno;
        }

        [Obsolete("Sera descontinuado na versão 2.x do client, use a versão assincrona do método")]
        public SubscriptionModel Activate(string id)
        {
            var retorno = ActivateAsync(id).Result;
            return retorno;
        }

        public async Task<SubscriptionModel> ActivateAsync(string id)
        {
            var retorno = await PostAsync<SubscriptionModel>(null, $"{id}/activate").ConfigureAwait(false);
            return retorno;
        }

        [Obsolete("Sera descontinuado na versão 2.x do client, use a versão assincrona do método")]
        public SubscriptionModel ChangePlan(string id, string plan_identifier)
        {
            var retorno = ChangePlanAsync(id, plan_identifier).Result;
            return retorno;
        }

        public async Task<SubscriptionModel> ChangePlanAsync(string id, string plan_identifier)
        {
            var retorno = await PostAsync<SubscriptionModel>(null, $"{id}/change_plan/{plan_identifier}").ConfigureAwait(false);
            return retorno;
        }

        [Obsolete("Sera descontinuado na versão 2.x do client, use a versão assincrona do método")]
        public SubscriptionModel AddCredits(string id, int quantity)
        {
            var retorno = AddCreditsAsync(id, quantity).Result;
            return retorno;
        }

        public async Task<SubscriptionModel> AddCreditsAsync(string id, int quantity)
        {
            var retorno = await PostAsync<SubscriptionModel>(null, $"{id}/add_credits/{quantity}").ConfigureAwait(false);
            return retorno;
        }
    }
}
