using System;
using System.Linq;
using CocoriCore;
using CocoriCore.Router;
using Newtonsoft.Json;

namespace CocoriCore
{


    public class PageConverter : JsonConverter
    {
        private readonly RouterOptions routerOptions;

        public PageConverter(RouterOptions routerOptions)
        {
            this.routerOptions = routerOptions;
        }

        public override bool CanWrite { get { return true; } }
        public override bool CanRead { get { return false; } }

        public override bool CanConvert(Type objectType)
        {
            return typeof(IPage).IsAssignableFrom(objectType);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new Exception("IPage Not supposed to be deserialized with PageConverter");
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var message = (IPage)value;
            var route = routerOptions.AllRoutes.First(r => r.MessageType == message.GetType());
            writer.WriteValue(route.ParameterizedUrl);
            // replace with values in message
        }
    }

}