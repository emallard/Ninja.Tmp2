using System;
using System.Linq;
using CocoriCore;
using CocoriCore.Router;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Soltys.ChangeCase;

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

            String url = route.ParameterizedUrl;
            foreach (var p in route.UrlParameters)
            {
                var i = url.IndexOf(p.Name.CamelCase() + ":");
                var j = url.IndexOf("/", i);
                url = url.Substring(0, i)
                    + p.InvokeGetter(message).ToString()
                    + (j == -1 ? "" : url.Substring(j, url.Length - j));
            }

            var query = "";
            var memberInfos = message.GetType().GetPropertiesAndFields();
            foreach (var mi in memberInfos)
            {
                if (!route.UrlParameters.Any(p => p.Name == mi.Name))
                {
                    if (query == "")
                        query += "?";
                    else
                        query += "&";
                    query += mi.Name + "=" + mi.InvokeGetter(message);
                }
            }

            JObject jObject = JObject.FromObject(value);
            jObject.Add("href", JToken.FromObject(url + query));
            jObject.WriteTo(writer);
        }
    }

}