using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iugu.net.CustomSerializers
{
    public sealed class EnumToConstantSerializer : JsonConverter
    {
        private static Dictionary<Enum, string> AvailableEnums = new Dictionary<Enum, string>
        {
            [CurrencyType.BRL] = Constants.CurrencyTypes.BRL,

            [PersonType.CorporateEntity] = Constants.PersonType.CORPORATE_ENTITY,
            [PersonType.IndividualPerson] = Constants.PersonType.INDIVIDUAL_PERSON,

            [PaymentMethod.BankSlip] = Constants.PaymentMethod.BANK_SLIP,
            [PaymentMethod.CreditCard] = Constants.PaymentMethod.CREDIT_CARD,

            [PlanIntervalType.Monthly] = Constants.GenerateCycleType.MONTHLY,
            [PlanIntervalType.Weekly] = Constants.GenerateCycleType.WEEKLY,

            [BankAccountType.CheckingAccount] = Constants.BankAccountType.CHECKING_ACCOUNT,
            [BankAccountType.SavingAccount] = Constants.BankAccountType.SAVING_ACCOUNT,

            [AvailableBanks.CaixaEconomicaFederal] = Constants.SupportedBanks.CAIXA_ECONOMICA,
            [AvailableBanks.BancoDoBrasil] = Constants.SupportedBanks.BANCO_DO_BRASIL,
            [AvailableBanks.Bradesco] = Constants.SupportedBanks.BRADESCO,
            [AvailableBanks.Itau] = Constants.SupportedBanks.ITAU,
            [AvailableBanks.Santander] = Constants.SupportedBanks.SANTANDER,

            [InvoiceAvailableStatus.Canceled] = Constants.InvoiceStatus.CANCELED,
            [InvoiceAvailableStatus.Draft] = Constants.InvoiceStatus.DRAFT,
            [InvoiceAvailableStatus.Expired] = Constants.InvoiceStatus.EXPIRED,
            [InvoiceAvailableStatus.Paid] = Constants.InvoiceStatus.PAID,
            [InvoiceAvailableStatus.PartiallyPaid] = Constants.InvoiceStatus.PARTIALLY_PAID,
            [InvoiceAvailableStatus.Pending] = Constants.InvoiceStatus.PENDING,
            [InvoiceAvailableStatus.Refunded] = Constants.InvoiceStatus.REFUNDED,
        };

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var customEnum = value as Enum;
            writer.WriteStartObject();
            serializer.Serialize(writer, AvailableEnums[customEnum], typeof(string));
            writer.WriteEndObject();
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var value = existingValue as string;

            if (!string.IsNullOrEmpty(value) && AvailableEnums.ContainsValue(value))
            {
                return AvailableEnums.Single(x => x.Value == value).Key;
            }

            return null;
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType.IsEnum;
        }
    }
}