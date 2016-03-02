using iugu.net.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace iugu.net.Lib
{
    public class Plans : APIResource
    {
        public Plans()
        {
            BaseURI += "/plans";
        }

        //limit (opcional)	Máximo de registros retornados
        //start (opcional)	Quantos registros pular do início da pesquisa (muito utilizado para paginação)
        //query (opcional)	Neste parâmetro pode ser passado um texto para pesquisa
        //updated_since (opcional)	Registros atualizados desde o valor passado no parâmetro
        //sortBy (opcional)	Um hash sendo a chave o nome do campo para ordenação e o valor sendo DESC ou ASC para descendente e ascendente, respectivamente
        public PlanModel Get()
        {
            var retorno = GetAsync().Result;
            return retorno;
        }

        public async Task<PlanModel> GetAsync()
        {
            var retorno = await GetAsync<PlanModel>().ConfigureAwait(false);
            return retorno;
        }

        public PlanModel Get(string id)
        {
            var retorno = GetAsync(id).Result;
            return retorno;
        }

        public async Task<PlanModel> GetAsync(string id)
        {
            var retorno = await GetAsync<PlanModel>(id).ConfigureAwait(false);
            return retorno;
        }

        /// <summary>
        /// Cria um Plano.
        /// </summary>
        /// <param name="name">Nome do Plano</param>
        /// <param name="identifier">Identificador do Plano</param>
        /// <param name="interval">Ciclo do Plano (Número inteiro maior que 0)</param>
        /// <param name="interval_type">Tipo de Interval ("weeks" ou "months")</param>
        /// <param name="value_cents">Preço do Plano em Centavos</param>
        /// <param name="currency">Moeda do Preço (Somente "BRL" por enquanto)</param>
        /// <param name="prices"> (opcional)	Preços do Plano</param>
        /// <param name="features"> (opcional)	Funcionalidades do Plano</param>
        public PlanModel Create(string name, string identifier, int interval, string interval_type, int value_cents,
            string currency = "BRL", List<PlanPrice> prices = null, List<PlanFeature> features = null)
        {
            var retorno = CreateAsync(name, identifier, interval, interval_type, value_cents, currency, prices, features).Result;
            return retorno;
        }

        /// <summary>
        /// Cria um Plano.
        /// </summary>
        /// <param name="name">Nome do Plano</param>
        /// <param name="identifier">Identificador do Plano</param>
        /// <param name="interval">Ciclo do Plano (Número inteiro maior que 0)</param>
        /// <param name="interval_type">Tipo de Interval ("weeks" ou "months")</param>
        /// <param name="value_cents">Preço do Plano em Centavos</param>
        /// <param name="currency">Moeda do Preço (Somente "BRL" por enquanto)</param>
        /// <param name="prices"> (opcional) Preços do Plano</param>
        /// <param name="features"> (opcional) Funcionalidades do Plano</param>
        /// <param name="payable_with">(opcional) Método de pagamento que será disponibilizado para as Faturas pertencentes a Assinaturas deste Plano ('all', 'credit_card' ou 'bank_slip')</param>
        public async Task<PlanModel> CreateAsync(string name, string identifier, int interval, string interval_type, int value_cents,
            string currency = "BRL", List<PlanPrice> prices = null, List<PlanFeature> features = null, string payable_with = null)
        {
            //TODO: implementar  custom_variables[]
            var user = new
            {
                name = name,
                interval = interval,
                identifier = identifier,
                interval_type = interval_type,
                value_cents = value_cents,
                currency = currency,
                prices = prices,
                features = features,
                payable_with = payable_with
            };
            var retorno = await PostAsync<PlanModel>(user).ConfigureAwait(false);
            return retorno;
        }

        public PlanModel Delete(string id)
        {
            var retorno = DeleteAsync(id).Result;
            return retorno;
        }

        public async Task<PlanModel> DeleteAsync(string id)
        {
            var retorno = await DeleteAsync<PlanModel>(id).ConfigureAwait(false);
            return retorno;
        }

        public PlanModel Put(string id, PlanModel model)
        {
            var retorno = PutAsync<PlanModel>(id, model).Result;
            return retorno;
        }

        public async Task<PlanModel> PutAsync(string id, PlanModel model)
        {
            var retorno = await PutAsync<PlanModel>(id, model).ConfigureAwait(false);
            return retorno;
        }
    }
}
