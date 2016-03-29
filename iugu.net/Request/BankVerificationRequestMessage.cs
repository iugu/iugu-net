using Newtonsoft.Json;
using System.Collections.Generic;

namespace iugu.net.Request
{
    public class BankVerificationRequestMessage
    {
        private static readonly Dictionary<BankAccountTypeAbbreviation, string> BankAccountsAbbreviations =
            new Dictionary<BankAccountTypeAbbreviation, string>
            {
                [BankAccountTypeAbbreviation.CC] = Constants.BankAccountType.CHECKING_ACCOUNT_ABBREVIATION,
                [BankAccountTypeAbbreviation.CP] = Constants.BankAccountType.SAVING_ACCOUNT_ABBREVIATION,
            };

        /// <summary>
        /// Nome da instituição bancária 
        /// Suportados : "001" para Banco do Brasil, "033" para Santander, "104" para Caixa Econômica, "237" para Bradesco, "341" para Itaú e "399" para HSBC
        /// </summary>
        [JsonProperty("bank")]
        public string BankNumber { get; private set; }

        /// <summary>
        /// Agência da Conta
        /// Formatos com validação automática(9999-D, 9999)
        /// </summary>
        [JsonProperty("agency")]
        public string BankAgency { get; private set; }

        /// <summary>
        /// Tipo da Conta ("cc" para Conta Corrente e "cp" para Conta Poupança)
        /// </summary>
        [JsonProperty("account_type")]
        public string AccountType { get; private set; }

        /// <summary>
        /// Número da Conta
        /// Formatos com validação automática(99999999-D, XXX99999999-D onde X é Operação, 	9999999-D, 99999-D)
        /// </summary>
        [JsonProperty("account")]
        public string BankAccountNumber { get; private set; }

        /// <summary>
        /// Para validar os dados bancários através do dígito verificador
        /// </summary>
        [JsonProperty("automatic_validation")]
        public bool AutomaticValidation { get; private set; }


        public BankVerificationRequestMessage(
            AvailableBanks bankNumber,
            string agencyNumber,
            string accountNumber,
            BankAccountTypeAbbreviation accountType,
            bool automaticValidationEnable)
        {
            BankNumber = string.Format("{0:000}", (int)bankNumber);
            BankAgency = agencyNumber;
            BankAccountNumber = accountNumber;
            AccountType = BankAccountsAbbreviations[accountType];
            AutomaticValidation = automaticValidationEnable;
        }
    }
}
