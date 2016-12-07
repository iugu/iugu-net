using Newtonsoft.Json;

namespace iugu.net.Entity
{
    /// <summary>
    /// Modelo que representa a conta de um cliente seja ele pessoa física ou jurídica
    /// </summary>
    public class AccountModel
    {
        private readonly AddressRequestMessage _address;
        private readonly string _fullAddress;

        [JsonConstructor]
        public AccountModel(string address)
        {
            _fullAddress = address;
        }

        public AccountModel(AddressRequestMessage address)
        {
            this._address = address;

        }
        /// <summary>
        /// Valor máximo da venda('Até R$ 100,00', 'Entre R$ 100,00 e R$ 500,00', 'Mais que R$ 500,00')
        /// </summary>
        [JsonProperty("price_range")]
        public string PriceRange { get; set; }

        /// <summary>
        /// Vende produtos físicos
        /// </summary>
        [JsonProperty("physical_products")]
        public bool PhysicalProducts { get; set; }

        /// <summary>
        /// Descrição do negócio
        /// </summary>
        [JsonProperty("business_type")]
        public string BusinessDescription { get; set; }

        /// <summary>
        /// 'Pessoa Física' ou 'Pessoa Jurídica'
        /// </summary>
        [JsonProperty("person_type")]
        public string PersonType { get; set; }

        /// <summary>
        /// Saque automático(Recomendamos que envie 'true')
        /// </summary>
        [JsonProperty("automatic_transfer")]
        public bool AcceptAutomaticTransfer { get; set; }

        /// <summary>
        /// CNPJ caso Pessoa Jurídica
        /// </summary>
        [JsonProperty("cnpj")]
        public string CNPJ { get; set; }

        /// <summary>
        /// Nome da Empresa, caso Pessoa Jurídica
        /// </summary>
        [JsonProperty("company_name")]
        public string CompanyName { get; set; }

        /// <summary>
        /// CPF caso Pessoa Física
        /// </summary>
        [JsonProperty("cpf")]
        public string CPF { get; set; }

        /// <summary>
        /// Nome caso Pessoa Física
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Endreço Completo
        /// </summary>
        [JsonProperty("address")]
        public string Address
        {
            get
            {
                return _address == null ? _fullAddress : $"{_address.Street}, {_address.Number} - {_address.City} - {_address.State}/{_address.Country}";
            }
        }

        /// <summary>
        /// Cep
        /// </summary>
        [JsonProperty("cep")]
        public string Cep { get { return _address?.ZipCode; } }

        /// <summary>
        /// Cidade
        /// </summary>
        [JsonProperty("city")]
        public string City { get { return _address?.City; } }

        /// <summary>
        /// Estado
        /// </summary>
        [JsonProperty("state")]
        public string State { get { return $"{_address?.Street} - {_address?.Number}"; } }

        /// <summary>
        /// Telefone comercial
        /// </summary>
        [JsonProperty("telephone")]
        public string Phone { get; set; }

        /// <summary>
        /// Nome do Responsável, caso Pessoa Jurídica
        /// </summary>
        [JsonProperty("resp_name")]
        public string RespName { get; set; }

        /// <summary>
        /// CPF do Responsável, caso Pessoa Jurídica
        /// </summary>
        [JsonProperty("resp_cpf")]
        public string RespCPF { get; set; }

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
    }
}
