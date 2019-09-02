using System;
using Newtonsoft.Json;

namespace CocoriCore
{
    public interface IPageCall : IMessage
    {
    }

    public class PageCallInfo
    {
        public Type _Type;
    }
    /*
    // Données nécessaires à l'execution du call
    public class PageCall<TPageMessage, TMessage>
    {
        public TPageMessage PageMessage;
        public Type PageMessageType;
        public Type MessageType;
        public string MemberName;
        public TMessage Message;
    }*/

    public class PageCall<TPageMessage, TMessage, TResponse, TPageResponse>
            : IPageCall
            , IMessage<TPageResponse>
        where TMessage : new()
        where TPageMessage : IMessage

    {
        public Type _Type;
        public TPageMessage PageMessage;
        //public Type PageMessageType;
        //public Type MessageType;
        public string MemberName;
        public TMessage Message;

        [JsonIgnore]
        public Func<TMessage, TResponse, TPageResponse> Translate;

        public PageCall()
        {
            _Type = this.GetType();
        }

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