namespace iugu.net
{
    public static class Constants
    {
        /// <summary>
        /// Forma de pagamento cartão ou boleto
        /// </summary>
        public static class PaymentMethod
        {
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
            public const string AUTHORIZED = "authorized";
            public const string CHARGEBACK = "chargeback";
            public const string REFUNDED = "refunded";
        }

        /// <summary>
        /// Os tipos de conta bancária puportados
        /// </summary>
        public static class BankAccountType
        {
            public const string SAVING_ACCOUNT = "Poupança";
            public const string CHECKING_ACCOUNT = "Corrente";
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
            public const string MONTLY = "months";
            public const string WEEKLY = "weeks";
        }
    }
}
