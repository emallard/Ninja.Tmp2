using System;
using Newtonsoft.Json;

namespace CocoriCore
{
    public interface IPageCall
    {
    }

    public class PageCall<TPageMessage, TMessage, TResponse, TPageResponse>
            : Call
            , IMessage<TPageResponse>
        where TPageMessage : IMessage

    {
        public TPageMessage PageMessage;
        public string MemberName;
        public TMessage Message;
        [JsonIgnore]
        public Func<TMessage, TResponse, TPageResponse> Translate;

        /*
        public object GetMessage()
        {
            return this.Message;
        }
        public Type GetMessageType()
        {
            return typeof(TMessage);
        }

        public object GetPageMessage()
        {
            return this.PageMessage;
        }
        public Type GetPageMessageType()
        {
            return this.PageMessageType;
        }

        public string GetMemberName()
        {
            return this.MemberName;
        }
        */

    }



}