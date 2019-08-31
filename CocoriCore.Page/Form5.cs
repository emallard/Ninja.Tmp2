using System;

namespace CocoriCore
{
    public class Form5<TMessage, TResponse, TPageResponse>
    {
        public TMessage Message;
        public Func<TMessage, TResponse, TPageResponse> Translate;
    }
}