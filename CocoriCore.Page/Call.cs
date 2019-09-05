using System;

namespace CocoriCore
{

    public class ICall : IMessage
    {
    }


    public class CallInfo
    {
        public Type _Type;
    }


    public class Call<TMessage, TResponse>
        : CallInfo
        , IMessage<TResponse>
    {
        //object IForm.Message;
        public TMessage Message;
        public Call()
        {
        }

        public Call(TMessage message)
        {
            Message = message;
            _Type = this.GetType();
        }

        public object GetMessage()
        {
            return this.Message;
        }
        public Type GetMessageType()
        {
            return typeof(TMessage);
        }

        public Type GetResponseType()
        {
            return typeof(TResponse);
        }
    }
}