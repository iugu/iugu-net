namespace iugu.net
{
    public static class Constants
    {
        /// <summary>
        /// Forma de pagamento cartão ou boleto
        /// </summary>
        public static class PaymentMethod
        {
            public const string ALL = "all";
            public const string CREDIT_CARD = "credit_card";
            public const string BANK_SLIP = "bank_slip";
        }

        /// <summary>
        /// Status da fatura ex: pago, draft, pendente, cancelado, etc.
        /// </summary>
        public static class InvoiceStatus
        {
            public const string DRAFT = "draft";
            public const string PENDING = "pending";
            public const string CANCELED = "canceled";
            public const string PAID = "paid";
            public const string PARTIALLY_PAID = "partially_paid";
            public const string REFUNDED = "refunded";
            public const string EXPIRED = "expired";
        }

        /// <summary>
        /// Os tipos de conta bancária puportados
        /// </summary>
        public static class BankAccountType
        {
            public const string SAVING_ACCOUNT = "Poupança";
            public const string CHECKING_ACCOUNT = "Corrente";
            public const string SAVING_ACCOUNT_ABBREVIATION = "cp";
            public const string CHECKING_ACCOUNT_ABBREVIATION = "cc";
        }

        /// <summary>
        /// Os tipos de pessoa puportados
        /// </summary>
        public static class PersonType
        {
            public const string CORPORATE_ENTITY = "Pessoa Jurídica";
            public const string INDIVIDUAL_PERSON = "Pessoa Física";
        }

        /// <summary>
        /// Os bancos suportados
        /// </summary>
        public static class SupportedBanks
        {
            public const string ITAU = "Itaú";
            public const string BRADESCO = "Bradesco";
            public const string CAIXA_ECONOMICA = "Caixa Econômica";
            public const string BANCO_DO_BRASIL = "Banco do Brasil";
            public const string SANTANDER = "Santander";
        }

        /// <summary>
        /// Os tipos de periodicidade e/ou recorrência
        /// </summary>
        public static class GenerateCycleType
        {
            public const string MONTHLY = "months";
            public const string WEEKLY = "weeks";
        }

        /// <summary>
        /// Modedas disponíveis
        /// </summary>
        public static class CurrencyTypes
        {
            public const string BRL = "BRL";
        }

        /// <summary>
        /// Símbolo de modedas disponíveis
        /// </summary>
        public static class CurrencySymbol
        {
            public const string BRL = "R$";
        }
    }
}
