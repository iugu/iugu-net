using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        CaixaEconomicaFederal, BancoDoBrasil, Bradesco, Itau, Santander
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
    /// Person type
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
}
