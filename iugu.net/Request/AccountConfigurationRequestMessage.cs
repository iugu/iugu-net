using Newtonsoft.Json;

namespace iugu.net.Request
{
    public class AccountConfigurationRequestMessage
    {
        /// <summary>
        /// Percentual de comissionamento enviado para a conta que gerencia o marketplace (Valor entre 0 e 70)
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

    public class BankSlipOptions
    {
        /// <summary>
        /// Ativo
        /// </summary>
        [JsonProperty("active")]
        public bool Active { get; set; }

        /// <summary>
        /// Dias de Vencimento Extras no Boleto (Ex: 2)
        /// </summary>
        [JsonProperty("extra_due")]
        public int? ExtraDueDays { get; set; }

        /// <summary>
        /// Dias de Vencimento Extras na 2a Via do Boleto (Ex: 1)
        /// </summary>
        [JsonProperty("reprint_extra_due")]
        public bool ReprintExtraDueDays { get; set; }
    }

    public class CreditCardOptions
    {
        /// <summary>
        /// Ativo
        /// </summary>
        [JsonProperty("active")]
        public bool Active { get; set; }

        /// <summary>
        /// Descrição que apareça na Fatura do Cartão do Cliente (Máx: 12 Caractéres)
        /// </summary>
        [JsonProperty("soft_descriptor")]
        public string SoftDescriptor { get; set; }

        /// <summary>
        /// Ativar parcelamento
        /// </summary>
        [JsonProperty("installments")]
        public bool Installments { get; set; }

        /// <summary>
        /// Repasse de Juros de Parcelamento ativo? true ou false
        /// </summary>
        [JsonProperty("installments_pass_interest")]
        public bool InstallmentsPassInterest { get; set; }

        /// <summary>
        /// Número máximo de parcelas (Nr entre 1 a 12)
        /// </summary>
        [JsonProperty("max_installments")]
        public int? MaxInstallments { get; set; }

        /// <summary>
        /// Número de parcelas sem cobrança de juros ao cliente (Nr entre 1 a 12)
        /// </summary>
        [JsonProperty("max_installments_without_interest")]
        public int? MaxInstallmentsWithoutInterest { get; set; }

        /// <summary>
        /// Habilita o fluxo de pagamento em duas etapas (Autorização e Captura)
        /// </summary>
        [JsonProperty("two_step_transaction")]
        public bool TwoStepTransaction { get; set; }

    }
}
