using System;
using System.Linq;
using CocoriCore;
using Newtonsoft.Json;

namespace CocoriCore
{


    public class LinkConverter : JsonConverter
    {
        private readonly RouterOptions routerOptions;

        public LinkConverter(RouterOptions routerOptions)
        {
            this.routerOptions = routerOptions;
        }
        public override bool CanConvert(Type objectType)
        {
            return typeof(ILink).IsAssignableFrom(objectType);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new Exception("ILink Not supposed to be deserialized");
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var link = (ILink)value;
            var route = routerOptions.AllRoutes.First(r => r.MessageType == link.GetMessage.GetType());
            writer.WriteValue(route.ParameterizedUrl);
            // replace with values in message
        }
    }

}