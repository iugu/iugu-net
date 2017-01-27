using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

namespace iugu.net.JsonCustomConverters
{
    internal sealed class EscapeInvalidQuoteConverter<T> : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            writer.WriteValue(value.ToString().Replace(@"""{", "}").Replace(@"}""", "}"));
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var value = JToken.Load(reader).Value<string>();
            var newValue = value.Replace(@"""{", "}").Replace(@"}""", "}").Trim();
            return JsonConvert.DeserializeObject<T>(newValue);
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(string);
        }
    }
}
