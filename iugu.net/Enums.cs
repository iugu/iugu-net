namespace iugu.net
{
    /// <summary>
    /// Tipo de intervalos de plano
    /// </summary>
    public enum PlanIntervalType
    {
        /// <summary>
        /// Plano com um ciclo semanal
        /// </summary>
        Weekly,
        /// <summary>
        /// Plano com um ciclo mensal
        /// </summary>
        Monthly
    }

    /// <summary>
    /// Moedas suportadas
    /// </summary>
    public enum CurrencyType
    {
        /// <summary>
        /// Moeda brasileira
        /// </summary>
        BRL
    }

    /// <summary>
    /// Bancos disponíveis
    /// </summary>
    public enum AvailableBanks
    {
        CaixaEconomicaFederal = 104, BancoDoBrasil = 001, Bradesco = 237, Itau = 341, Santander = 033, HSBC = 399
    }

    /// <summary>
    /// Status da fatura
    /// </summary>
    public enum InvoiceAvailableStatus
    {
        Paid, Canceled, PartiallyPaid, Pending, Draft, Refunded, Expired
    }

    /// <summary>
    /// Person type
    /// </summary>
    public enum PersonType
    {
        /// <summary>
        /// Pessoa Jurídica
        /// </summary>
        CorporateEntity,

        /// <summary>
        /// Pessoa física
        /// </summary>
        IndividualPerson
    }

    /// <summary>
    /// Bank account type
    /// </summary>
    public enum BankAccountType
    {
        /// <summary>
        /// Conta poupança
        /// </summary>
        SavingAccount,

        /// <summary>
        /// Conta Corrente
        /// </summary>
        CheckingAccount
    }

    public enum BankAccountTypeAbbreviation
    {
        /// <summary>
        /// Conta poupança
        /// </summary>
        CP,

        /// <summary>
        /// Conta Corrente
        /// </summary>
        CC
    }

    /// <summary>
    /// Metodos de pagamento suportado
    /// </summary>
    public enum PaymentMethod
    {
        /// <summary>
        /// Todos os tipos de pagamentos serão aceitos
        /// </summary>
        All,
        /// <summary>
        /// Cartão de crédito
        /// </summary>
        CreditCard,

        /// <summary>
        /// Boleto bancário
        /// </summary>
        BankSlip
    }

    /// <summary>
    /// Ordenações suportadas
    /// </summary>
    public enum ResultOrderType
    {
        /// <summary>
        /// Menor para o maior
        /// </summary>
        Ascending,
        /// <summary>
        /// Maior para o menor
        /// </summary>
        Descending
    }
}
