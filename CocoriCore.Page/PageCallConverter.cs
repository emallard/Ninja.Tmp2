using System;
using System.Linq;
using CocoriCore;
using CocoriCore.Router;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CocoriCore
{
    public class PageCallConverter : JsonConverter
    {

        public override bool CanWrite => false;
        public override bool CanConvert(Type objectType)
        {
            return typeof(IPageCall).IsAssignableFrom(objectType);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JObject jObject = JObject.Load(reader);
            var pageCall = jObject.ToObject<PageCallInfo>();
            var newObj = jObject.ToObject(pageCall._Type);
            return newObj;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotSupportedException();
        }
    }

}