using iugu.net.Entity;
using Newtonsoft.Json;
using NUnit.Framework;
using Ploeh.AutoFixture;
using FluentAssertions;
using System.Threading.Tasks;
using iugu.net.Response;

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

        [Test]
        public async Task Given_a_request_withdraw_respose_when_serialize_should_be_success()
        {
            // Arrage
            var inputJson = @"{'id': '530706A3862D4BB49C8AC9637B850CDE','status': 'pending','created_at': '2015-11-26T10:02:23-02:00','updated_at': '2015-11-26T10:02:23-02:00',
                               'reference': null,'amount': 'R$ 10,00','account_name': 'Conta','account_id': 'A682CECA59D74527B984CA529D7C2ED4','feedback': null,
                                'bank_address': {'bank': 'Bradesco','bank_cc': '11231-2','bank_ag': '1234','account_type': 'Corrente'}}";

            // Act
            var serializesResponse = JsonConvert.DeserializeObject<RequestWithdrawResponseMessage>(inputJson);

            Assert.That(serializesResponse.OperationId, Is.EqualTo("530706A3862D4BB49C8AC9637B850CDE"));
            Assert.That(serializesResponse.AccountId, Is.EqualTo("A682CECA59D74527B984CA529D7C2ED4"));
            Assert.That(serializesResponse.Amount, Is.EqualTo("R$ 10,00"));
            Assert.That(serializesResponse.BankInfo.Name, Is.EqualTo("Bradesco"));
        }
    }
}
