using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iugu.Lib
{
    public class Subscription : APIResource
    {
        public Subscription()
        {
            BaseURI += "/subscriptions";
        }

        //limit (opcional)	Máximo de registros retornados
        //start (opcional)	Quantos registros pular do início da pesquisa (muito utilizado para paginação)
        //created_at_from (opcional)	Registros criados a partir desta data passada no parâmetro
        //created_at_to (opcional)	Registros criados até esta data passada no parâmetro
        //query (opcional)	Neste parâmetro pode ser passado um texto para pesquisa
        //updated_since (opcional)	Registros atualizados desde o valor passado no parâmetro
        //sortBy (opcional)	Um hash sendo a chave o nome do campo para ordenação e o valor sendo DESC ou ASC para descendente e ascendente, respectivamente
        //customer_id (opcional)	ID do Cliente
        public SubscriptionModel Get()
        {
            var retorno = GetAsync<SubscriptionModel>().Result;
            return retorno;
        }
        public SubscriptionModel Get(string id)
        {
            var retorno = GetAsync<SubscriptionModel>(id).Result;
            return retorno;
        }

        //plan_identifier (opcional)	Identificador do Plano. Só é enviado para assinaturas que não são credits_based
        //customer_id	ID do Cliente
        //expires_at (opcional)	Data de Expiração (Também é a data da próxima cobrança)
        //only_on_charge_success (opcional)	Apenas Cria a Assinatura se a Cobrança for bem sucedida. Isso só funciona caso o cliente já tenha uma forma de pagamento padrão cadastrada
        //credits_based (opcional)	É uma assinatura baseada em créditos? booleano
        //price_cents (opcional)	Preço em centavos da recarga para assinaturas baseadas em crédito
        //credits_cycle (opcional)	Quantidade de créditos adicionados a cada ciclo, só enviado para assinaturas credits_based
        //credits_min (opcional)	Quantidade de créditos que ativa o ciclo, por ex: Efetuar cobrança cada vez que a assinatura tenha apenas 1 crédito sobrando. Esse 1 crédito é o credits_min
        //subitems[] (opcional)	Array com Itens de Assinatura, sendo que estes podem ser recorrentes ou de cobrança única
        //custom_variables[] (opcional)	Variáveis Personalizadas

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
                subitems = subitems
            };
            var retorno = PostAsync<SubscriptionModel>(subscription).Result;
            return retorno;
        }
        public SubscriptionModel Delete(string id)
        {
            var retorno = DeleteAsync<SubscriptionModel>(id).Result;
            return retorno;
        }
        public SubscriptionModel Put(string id, SubscriptionModel model)
        {
            var retorno = PutAsync<SubscriptionModel>(id, model).Result;
            return retorno;
        }

        public SubscriptionModel Suspend(string id)
        {
            BaseURI += string.Format("{0}/suspend", id);
            var retorno = PostAsync<SubscriptionModel>(null).Result;
            return retorno;
        }

        public SubscriptionModel Activate(string id)
        {
            BaseURI += string.Format("{0}/activate", id);
            var retorno = PostAsync<SubscriptionModel>(null).Result;
            return retorno;
        }

        public SubscriptionModel ChangePlan(string id, string plan_identifier)
        {
            BaseURI += string.Format("{0}/change_plan/{1}", id, plan_identifier);
            var retorno = PostAsync<SubscriptionModel>(null).Result;
            return retorno;
        }

        public SubscriptionModel AddCredits(string id, int quantity)
        {
            BaseURI += string.Format("{0}/add_credits/{1}", id, quantity);
            var retorno = PostAsync<SubscriptionModel>(null).Result;
            return retorno;
        }
    }
}
