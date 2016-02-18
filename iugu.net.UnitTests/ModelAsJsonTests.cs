using iugu.net.Entity;
using Newtonsoft.Json;
using NUnit.Framework;
using Ploeh.AutoFixture;
using FluentAssertions;
using System.Threading.Tasks;

namespace iugu.net.UnitTests
{
    [TestFixture]
    public class ModelAsJsonTests
    {
        [Test]
        public async Task Given_a_complete_account_model_when_serialize_should_be_created_a_json_without_nested_object_address()
        {
            // Arrange
            var accountData = new Fixture().Build<AccountModel>()
                                           .Create();

            var expectedJson = JsonConvert.SerializeObject(new
            {
                price_range = accountData.PriceRange,
                physical_products = accountData.PhysicalProducts,
                business_type = accountData.BusinessDescription,
                person_type = accountData.PersonType,
                automatic_transfer = accountData.AcceptAutomaticTransfer,
                cnpj = accountData.CNPJ,
                company_name = accountData.CompanyName,
                cpf = accountData.CPF,
                name = accountData.Name,
                address = accountData.Address,
                cep = accountData.Cep,
                city = accountData.City,
                state = accountData.State,
                telephone = accountData.Phone,
                resp_name = accountData.RespName,
                resp_cpf = accountData.RespCPF,
                bank = accountData.Bank,
                bank_ag = accountData.BankAgency,
                account_type = accountData.AccountType,
                bank_cc = accountData.BankAccountNumber
            });

            // Act 
            var serialilizeObj = JsonConvert.SerializeObject(accountData);

            // Assert
            expectedJson.Should().BeEquivalentTo(serialilizeObj);

        }
    }
}
