using iugu.net.Entity;
using Newtonsoft.Json;
using System;

namespace iugu.net.Response
{
    /// <summary>
    /// Resposta da API de contas ao obter 1 conta
    /// </summary>
    public class GetAccountResponseMessage
    {
        /// <summary>
        /// Identificação da conta
        /// </summary>
        [JsonProperty("id")]
        public string AccountId { get; set; }

        /// <summary>
        /// Nome da conta
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Data de criação
        /// </summary>
        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Data da ultima atualização
        /// </summary>
        [JsonProperty("updated_at")]
        public DateTime UpdatedAt { get; set; }

        /// <summary>
        /// Pode receber pagamentos
        /// </summary>
        [JsonProperty("can_receive")]
        public bool CanReceive { get; set; }

        /// <summary>
        /// Conta já foi verificada
        /// </summary>
        [JsonProperty("is_verified")]
        public bool IsVerified { get; set; }

        /// <summary>
        /// Último status de verificação da conta
        /// </summary>
        [JsonProperty("last_verification_request_status")]
        public string LastAccountVerificationRequestStatus { get; set; }

        /// <summary>
        /// Dados enviados na última requisição de verificação
        /// </summary>
        [JsonProperty("last_verification_request_data")]
        public AccountModel LastAccountVerificationRequestData { get; set; }

        /// <summary>
        /// Descrição do motivo de rejeição da verificação da conta, caso contrário é nulo
        /// </summary>
        [JsonProperty("last_verification_request_feedback")]
        public string LastAccountVerificationRequestDataFeedback { get; set; }

        /// <summary>
        /// Tipo do plano
        /// </summary>
        [JsonProperty("change_plan_type")]
        public int ChangePlanType { get; set; }

        /// <summary>
        /// Dias do periodo trieal
        /// </summary>
        [JsonProperty("subscriptions_trial_period")]
        public int SubscriptionsTrialPeriod { get; set; }

        /// <summary>
        /// Desabilitar envio de emails
        /// </summary>
        [JsonProperty("disable_emails")]
        public bool DisableEmails { get; set; }

        /// <summary>
        /// Último saque
        /// </summary>
        [JsonProperty("last_withdraw")]
        public WithdrawModel LastWithdraw { get; set; }

        /// <summary>
        /// Total de assinantes
        /// </summary>
        [JsonProperty("total_subscriptions")]
        public int TotalSubscriptions { get; set; }

        /// <summary>
        /// Email de reply
        /// </summary>
        [JsonProperty("reply_to")]
        public string ReplyToEmail { get; set; }

        /// <summary>
        /// Está executando em modo teste
        /// </summary>
        [JsonProperty("webapp_on_test_mode")]
        public bool RunningInTestMode { get; set; }

        /// <summary>
        /// Identifica se a conta é de um marketplace
        /// </summary>
        [JsonProperty("marketplace")]
        public bool IsMarketplace { get; set; }

        /// <summary>
        /// Retirada automática habilitada
        /// </summary>
        [JsonProperty("auto_withdraw")]
        public bool EnableAutoWithdraw { get; set; }

        /// <summary>
        /// Balanço do periodo
        /// </summary>
        [JsonProperty("balance")]
        public string Balance { get; set; }

        /// <summary>
        /// Balanço protegido
        /// </summary>
        [JsonProperty("protected_balance")]
        public string ProtectedBalance { get; set; }

        /// <summary>
        /// Balanço a pagar
        /// </summary>
        [JsonProperty("payable_balance")]
        public string PayableBalance { get; set; }

        /// <summary>
        /// Balanço a receber
        /// </summary>
        [JsonProperty("receivable_balance")]
        public string ReceivableBalance { get; set; }

        /// <summary>
        /// Balanço de comissões
        /// </summary>
        [JsonProperty("commission_balance")]
        public string CommissionBalance { get; set; }

        /// <summary>
        /// Volume do último mês
        /// </summary>
        [JsonProperty("volume_last_month")]
        public string LastMonthVolume { get; set; }

        /// <summary>
        /// Volume do mês
        /// </summary>
        [JsonProperty("volume_this_month")]
        public string CurrentVolume { get; set; }

        /// <summary>
        /// Taxas pagas no ultimo mês
        /// </summary>
        [JsonProperty("taxes_paid_last_month")]
        public string TaxesPaidLastMonth { get; set; }

        /// <summary>
        /// Taxas pagas no mês
        /// </summary>
        [JsonProperty("taxes_paid_this_month")]
        public string TaxesPaidMonth { get; set; }

        /// <summary>
        /// Url da logo do cliente em tamanho padrão
        /// </summary>
        [JsonProperty("custom_logo_url")]
        public string ClientLogoUrl { get; set; }

        /// <summary>
        /// Url da logo do cliente em tamanho pequeno
        /// </summary>
        [JsonProperty("custom_logo_small_url")]
        public string ClientSmallLogoUrl { get; set; }

        /// <summary>
        /// Informações extras da conta, baseadas em chave valor
        /// </summary>
        [JsonProperty("informations")]
        public Information[] ExtraInformations { get; set; }
    }

    /// <summary>
    /// Modelo que representa as informações da retirada
    /// </summary>
    public class WithdrawModel
    {
        /// <summary>
        /// Identificação da retirada
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// Identificação da conta
        /// </summary>
        [JsonProperty("account_id")]
        public string AccountId { get; set; }

        /// <summary>
        /// Valor
        /// </summary>
        [JsonProperty("amount")]
        public string Amount { get; set; }

        /// <summary>
        /// Nome da instituição bancária 
        /// Suportados : 'Itaú', 'Bradesco', 'Caixa Econômica', 'Banco do Brasil', 'Santander'
        /// </summary>
        [JsonProperty("bank")]
        public string Bank { get; set; }

        /// <summary>
        /// Agência da Conta
        /// Formatos com validação automática(9999-D, 9999)
        /// </summary>
        [JsonProperty("bank_ag")]
        public string BankAgency { get; set; }

        /// <summary>
        /// Tipo da conta: 'Corrente', 'Poupança'
        /// </summary>
        [JsonProperty("account_type")]
        public string AccountType { get; set; }

        /// <summary>
        /// Número da Conta
        /// Formatos com validação automática(99999999-D, XXX99999999-D onde X é Operação, 	9999999-D, 99999-D)
        /// </summary>
        [JsonProperty("bank_cc")]
        public string BankAccountNumber { get; set; }

        /// <summary>
        /// Data de Criação
        /// </summary>
        [JsonProperty("created_at")]
        public string CreatedAt { get; set; }

        /// <summary>
        /// Feedback de verificação dos dados
        /// </summary>
        [JsonProperty("feedback")]
        public string Feedback { get; set; }

        /// <summary>
        /// Referência
        /// </summary>
        [JsonProperty("reference")]
        [Obsolete]
        public string Reference { get; set; }

        /// <summary>
        /// Status da transação
        /// </summary>
        [JsonProperty("status")]
        public string Status { get; set; }

        /// <summary>
        /// Data da retirada
        /// </summary>
        [JsonProperty("updated_at")]
        public string UpdatedAt { get; set; }
    }

    /// <summary>
    /// Informações extras da conta
    /// </summary>
    public class Information
    {
        [JsonProperty("key")]
        public string Key { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }
    }

}
