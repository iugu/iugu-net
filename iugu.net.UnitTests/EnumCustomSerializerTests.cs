using Newtonsoft.Json;
using NUnit.Framework;
using Ploeh.AutoFixture;
using System.Threading.Tasks;
using FluentAssertions;
using iugu.net.CustomSerializers;

namespace iugu.net.UnitTests
{
    [TestFixture]
    public class EnumCustomSerializerTests
    {
        public class StubModelWithEnums
        {
            [JsonProperty("method")]
            [JsonConverter(typeof(EnumToConstantSerializer))]
            public PaymentMethod PaymentMethod { get; set; }

            [JsonProperty("test")]
            [JsonConverter(typeof(EnumToConstantSerializer))]
            public InvoiceAvailableStatus InvoiceAvailableStatus { get; set; }

            [JsonProperty("test1")]
            [JsonConverter(typeof(EnumToConstantSerializer))]
            public AvailableBanks AvailableBanks { get; set; }

            [JsonProperty("test2")]
            [JsonConverter(typeof(EnumToConstantSerializer))]
            public PlanIntervalType PlanIntervalType { get; set; }

            [JsonProperty("test3")]
            [JsonConverter(typeof(EnumToConstantSerializer))]
            public CurrencyType CurrencyType { get; set; }

            [JsonProperty("test4")]
            [JsonConverter(typeof(EnumToConstantSerializer))]
            public PersonType PersonType { get; set; }

            [JsonProperty("test5")]
            [JsonConverter(typeof(EnumToConstantSerializer))]
            public BankAccountType BankAccountType { get; set; }
        }

        [Test]
        public async Task Given_a_model_with_enums_should_be_serialized_with_sucess()
        {
            // Arrange
            var enumsModel = new Fixture().Build<StubModelWithEnums>().Create();
            var teste = new EnumToConstantSerializer();
            // Act && Assert
            var test = JsonConvert.SerializeObject(enumsModel);
            Assert.DoesNotThrow(() => JsonConvert.SerializeObject(enumsModel));
        }

        [Test]
        public async Task Given_a_json_with_enums_representation_in_string_mode_should_be_deserialized_with_sucess()
        {
            // Arrange
            var enumsModel = new Fixture().Build<StubModelWithEnums>().Create();
            var serializedJson = JsonConvert.SerializeObject(enumsModel);

            // Act
            var model = JsonConvert.DeserializeObject<StubModelWithEnums>(serializedJson);

            // Assert
            model.ShouldBeEquivalentTo(enumsModel);
        }

    }
}
