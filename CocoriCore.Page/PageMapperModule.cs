using System;
using System.Collections.Generic;

namespace CocoriCore
{
    public class PageMapperModule
    {
        public List<PageMapping3> Mappings3 = new List<PageMapping3>();
        public List<PageMapping2> Mappings2 = new List<PageMapping2>();
        public List<MessageHandling> Handlings = new List<MessageHandling>();

        protected void Map<TMessage, TResponse, TModel>(Func<TMessage, TResponse, TModel> mappingFunc)
        {
            Mappings3.Add(PageMapping3.Create(mappingFunc));
        }

        protected void Map<TPageQuery, TMessage>(Func<TPageQuery, TMessage> mappingFunc)
        {
            Mappings2.Add(PageMapping2.Create(mappingFunc));
        }

        protected void Handle<TMessage, TResponse>(Func<TMessage, TResponse> func) where TMessage : IMessage<TResponse>
        {
            Handlings.Add(MessageHandling.Create(func));
        }
    }

    public class MessageHandling
    {
        public Type Key;
        public Func<object, object> Func { get; set; }

        public static MessageHandling Create<T1, T2>(Func<T1, T2> func)
        {
            return new MessageHandling()
            {
                Func = (a) => func((T1)a),
                Key = typeof(T1)
            };
        }
    }
}