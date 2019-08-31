using System;

namespace CocoriCore
{
    public class PageFormMessage5<TPage, TMessage, TMessageResponse, TFormResponse> : IMessage<TFormResponse>
    {
        public IMessage<TPage> PageGet;
        public TMessage Message;
        public Func<TPage, Form5<TMessage, TMessageResponse, TFormResponse>> Form;

    }
}