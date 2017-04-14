using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Globalization;

namespace iugu.net.JsonCustomConverters
{
    internal sealed class EscapeInvalidQuoteConverter<T> : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if (CanApplyCustomConverter(value))
            {
                writer.WriteValue(value.ToString().Replace(@"""{", "}").Replace(@"}""", "}"));
            }
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var value = JToken.Load(reader);

            if (value.Type == JTokenType.Object)
                return value.ToObject<T>(serializer);

            var badFormatValue = value.Value<string>();

            if (value.Type == JTokenType.String && CanApplyCustomConverter(badFormatValue))
                return JsonConvert.DeserializeObject<T>(badFormatValue.Replace(@"""{", "}").Replace(@"}""", "}").Trim());

            return null;
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(string);
        }

        private static bool CanApplyCustomConverter(object value)
        {
            if (value != null)
            {
                var plainValue = value.ToString();
                return plainValue.Contains(@"""{") && plainValue.Contains(@"}""");
            }

            return false;
        }
    }

    internal class BrazilianDecimalConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return (objectType == typeof(decimal) || objectType == typeof(decimal?));
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var token = JToken.Load(reader);

            if (token.Type == JTokenType.Float || token.Type == JTokenType.Integer)
                return token.ToObject<decimal>();
            if (token.Type == JTokenType.String)
                return decimal.Parse(token.ToString(), NumberStyles.Currency, CultureInfo.GetCultureInfo("pt-BR"));
            if (token.Type == JTokenType.Null && objectType == typeof(decimal?))
                return null;

            throw new JsonSerializationException("Unexpected token type: " +
                                                  token.Type.ToString());
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            writer.WriteValue(value);
        }
    }
}