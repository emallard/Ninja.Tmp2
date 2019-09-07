using System;

namespace CocoriCore
{
    public class AsyncCall<TPageGet, T> : IMessage<T>
    {
        public bool IsAsyncCall = true;
        public Type _Type;
        public TPageGet PageQuery;
        public T Result;

        public AsyncCall()
        {
            _Type = this.GetType();
        }
    }
}