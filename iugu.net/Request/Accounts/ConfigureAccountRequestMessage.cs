using iugu.net.Request.Accounts.Data;
using Newtonsoft.Json;

namespace iugu.net.Request.Accounts
{
    /// <summary>
    /// Requisição para a API de contas, usado em POST https://api.iugu.com/v1/accounts/configuration
    /// </summary>
    public class ConfigureAccountRequestMessage
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("commission_percent")]
        public int? CommissionPercent { get; set; }

        /// <summary>
        /// Saque automático
        /// </summary>
        [JsonProperty("auto_withdraw")]
        public bool AutoWithdraw { get; set; }

        /// <summary>
        /// Multa
        /// </summary>
        [JsonProperty("fines")]
        public bool Fines { get; set; }

        /// <summary>
        /// Juros de mora
        /// </summary>
        [JsonProperty("per_day_interest")]
        public bool PerDayInterest { get; set; }

        /// <summary>
        /// Valor da multa em % (Ex: 2)
        /// </summary>
        [JsonProperty("late_payment_fine")]
        public decimal LatePaymentFine { get; set; }

        /// <summary>
        /// Antecipação Automática. Só pode ser atribuído caso a conta tenha a funcionalidade de Novo Adiantamento habilitado (entre em contato com o Suporte para habilitar)
        /// </summary>
        [JsonProperty("auto_advance")]
        public bool AutoAdvance { get; set; }

        /// <summary>
        /// Opções de Antecipação Automática. Obrigatório caso auto_advance seja true. Recebe os valores 'daily' (Antecipação diária), 'weekly' 
        /// (Antecipação semanal, que ocorre no dia da semana determinado pelo usuário), 'monthly' (Antecipação mensal, que ocorre no dia do
        /// mês determinado pelo usuário) e 'days_after_payment' (Antecipação que ocorre em um número de dias após o pagamento especificado pelo usuário)
        /// </summary>
        [JsonProperty("auto_advance_type")]
        public string AutoAdvanceType { get; set; }

        /// <summary>
        /// Obrigatório caso auto_advance seja true e auto_advance_type diferente de 'daily'. Em caso de auto_advance_type = weekly, recebe valores de 0 a 6
        /// (Número correspondente ao dia da semana que a antecipação será realizada, 0 para domingo, 1 para segunda e assim por diante). Em caso de auto_advance_type = monthly, 
        /// recebe valores de 1 a 28 (Número correspondente ao dia do mês que a antecipação será realizada).  Em caso de auto_advance_type = days_after_payment,
        /// recebe valores de 1 a 30 (Número de dias após o pagamento em que a antecipação será realizada)
        /// </summary>
        [JsonProperty("auto_advance_option")]
        public string AutoAdvanceOption { get; set; }

        /// <summary>
        /// Configurações de Boleto Bancário
        /// </summary>
        [JsonProperty("bank_slip")]
        public BankSlipOptions BankSlipOptions { get; set; }

        /// <summary>
        /// Configurações de Cartão de Crédito
        /// </summary>
        [JsonProperty("credit_card")]
        public CreditCardOptions CreditCardOptions { get; set; }
    }

    

    
}
