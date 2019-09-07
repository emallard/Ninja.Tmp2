using System;

namespace CocoriCore
{
    public class Form<TCommand, TResponse> : IMessage<TResponse>
        where TCommand : IMessage, new()
    {
        public Type _Type;
        public TCommand Command = new TCommand();

        public Form()
        {
            _Type = this.GetType();
        }
    }
}