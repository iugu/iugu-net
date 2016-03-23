using iugu.net.Request;
using iugu.net.Response;
using System;
using System.Threading.Tasks;

namespace iugu.net.Lib
{
    /// <summary>
    /// Api de operações em contas
    /// </summary>
    public class Account : IDisposable
    {
        public readonly IApiResources Api;

        public Account() : this(new APIResource()) { }

        public Account(IApiResources api)
        {
            Api = api;
            api.BaseURI += "/accounts";
        }

        /// <summary>
        /// Todas as contas devem ter sua documentação verificada antes de poder emitir faturas reais (porém permite criação de dados de teste).
        /// Essa API permite o envio da documentação da sub-conta criada.
        /// Obs: Essa API obriga a utilização do User API Token em vez do API Token de conta. A verificação demora em torno de 1 dia útil
        /// </summary>
        /// <param name="accountData">Dados da conta</param>
        /// <param name="userToken"> User API Token</param>
        /// <param name="accountId">Id da conta a ser validada</param>
        /// <returns>Resposta da API de validação da conta</returns>
        public VerifyAccountResponseMessage VerifyUnderAccount(VerifyAccountRequestMessage accountData, string accountId, string userToken)
        {
            var retorno = VerifyUnderAccountAsync(accountData, accountId, userToken).Result;
            return retorno;
        }

        /// <summary>
        /// Todas as contas devem ter sua documentação verificada antes de poder emitir faturas reais (porém permite criação de dados de teste).
        /// Essa API permite o envio da documentação da sub-conta criada.
        /// Obs: Essa API obriga a utilização do User API Token em vez do API Token de conta. A verificação demora em torno de 1 dia útil
        /// </summary>
        /// <param name="accountData">Dados da conta</param>
        /// <param name="userToken"> User API Token</param>
        /// <param name="accountId">Id da conta a ser validada</param>
        /// <returns>Resposta da API de validação da conta</returns>
        public async Task<VerifyAccountResponseMessage> VerifyUnderAccountAsync(VerifyAccountRequestMessage accountData, string accountId, string userToken)
        {
            var retorno = await Api.PostAsync<VerifyAccountResponseMessage>(accountData, $"{accountId}/request_verification", userToken).ConfigureAwait(false);
            return retorno;
        }

        /// <summary>
        /// Retorna as informações de uma conta
        /// </summary>
        /// <param name="accountId">Id da Conta</param>
        /// <param name="userToken">Token de Usuário</param>
        /// <returns></returns>
        public GetAccountResponseMessage Get(string accountId, string userToken)
        {
            var retorno = GetAsync(accountId, userToken).Result;
            return retorno;
        }

        /// <summary>
        /// Retorna as informações de uma conta
        /// </summary>
        /// <param name="accountId">Id da Conta</param>
        /// <param name="userToken">Token de Usuário</param>
        /// <returns></returns>
        public async Task<GetAccountResponseMessage> GetAsync(string accountId, string userToken)
        {
            var retorno = await Api.GetAsync<GetAccountResponseMessage>(accountId, userToken).ConfigureAwait(false);
            return retorno;
        }

        /// <summary>
        /// Faz um pedido de Saque de um valor de uma determinada conta, utilizando o apiToken previamente configurado
        /// </summary>
        /// <param name="targetAccountId">Id da conta a ser validada</param>
        /// <param name="amount">Valor da retirada</param>
        /// <returns>Resposta da API depedido de saque</returns>
        [Obsolete("Funciona apenas se o token de configuração for o UserApiToken - Descontinuado na versão 2.x do client")]
        public async Task<AccountRequestWithdrawResponse> RequestWithdrawAsync(string targetAccountId, decimal amount)
        {
            var retorno = await RequestWithdrawAsync(targetAccountId, amount, null).ConfigureAwait(false);
            return retorno;
        }

        /// <summary>
        /// Faz um pedido de Saque de um valor de uma determinada conta, utilizando um userApiToken customizado da conta de pedido de saque
        /// </summary>
        /// <param name="targetAccountId">Id da conta a ser validada</param>
        /// <param name="amount">Valor da retirada</param>
        /// <param name="customUserApiToken">Token customizado do usuário, utilizado em marketplaces</param>
        /// <returns>Resposta da API depedido de saque</returns>
        public async Task<AccountRequestWithdrawResponse> RequestWithdrawAsync(string targetAccountId, decimal amount, string customUserApiToken)
        {
            var retorno = await Api.PostAsync<AccountRequestWithdrawResponse>(new { amount = amount }, $"{targetAccountId}/request_withdraw", customUserApiToken).ConfigureAwait(false);
            return retorno;
        }

        /// <summary>
        /// Faz um pedido de saque de todo saldo de uma conta, utilizando o apiTokenPreviamente configurado
        /// </summary>
        /// <param name="targetAccountId">Id da conta a ser validada</param>
        /// <returns>Resposta da API depedido de saque</returns>
        [Obsolete("Funciona apenas se o token de configuração for o UserApiToken - Descontinuado na versão 2.x do client")]
        public async Task<AccountRequestWithdrawResponse> RequestWithdrawAllAsync(string targetAccountId)
        {
            var retorno = await RequestWithdrawAllAsync(targetAccountId, null).ConfigureAwait(false);
            return retorno;
        }

        /// <summary>
        /// Faz um pedido de saque de todo saldo de uma conta, utilizando um user token da conta de saque
        /// </summary>
        /// <param name="targetAccountId">Id da conta a ser validada</param>
        /// <param name="customUserApiToken">User token customizado da Api</param>
        /// <returns>Resposta da API depedido de saque</returns>
        public async Task<AccountRequestWithdrawResponse> RequestWithdrawAllAsync(string targetAccountId, string customUserApiToken)
        {
            var accountBalanceValue = await Api.GetAsync<GetAccountResponseMessage>(targetAccountId).ConfigureAwait(false);
            var convertedValue = Convert.ToDecimal(accountBalanceValue.Balance.Replace(Constants.CurrencySymbol.BRL, string.Empty).Replace(",", "."));
            var retorno = await Api.PostAsync<AccountRequestWithdrawResponse>(new { amount = convertedValue }, $"{targetAccountId}/request_withdraw", customUserApiToken).ConfigureAwait(false);
            return retorno;
        }


        /// <summary>
        /// Configura parâmetros de uma sub-conta, utilizando um apiToken customizado
        /// </summary>
        /// <param name="request">Configurações</param>
        /// <param name="accountApiToken">Live Api Token da conta</param>
        /// <returns></returns>
        public async Task<GetAccountResponseMessage> ConfigureAccountAsync(AccountConfigurationRequestMessage request, string accountApiToken)
        {
            var retorno = await Api.PostAsync<GetAccountResponseMessage>(request, $"/configuration", accountApiToken).ConfigureAwait(false);
            return retorno;
        }

        public void Dispose()
        {
            Api.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
