using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace iugu.net.Request.Accounts.Data
{
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
