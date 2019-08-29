using System;
using System.Linq;
using CocoriCore;
using CocoriCore.Router;
using Newtonsoft.Json;

namespace CocoriCore
{
    public class FormConverter : JsonConverter
    {
        private readonly RouterOptions routerOptions;

        public FormConverter(RouterOptions routerOptions)
        {
            this.routerOptions = routerOptions;
        }

        public override bool CanConvert(Type objectType)
        {
            return typeof(IForm).IsAssignableFrom(objectType);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new Exception("ISubmit Not supposed to be deserialized");
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var form = (IForm)value;
            var postRoute = routerOptions.AllRoutes.First(r => r.MessageType == form.GetPostType());
            writer.WriteStartObject();
            writer.WritePropertyName("method");
            writer.WriteValue(postRoute.Method.Method);
            writer.WritePropertyName("parameterizedUrl");
            writer.WriteValue(postRoute.ParameterizedUrl);
            writer.WriteEndObject();
        }
    }

}