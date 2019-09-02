using System;
using System.Threading.Tasks;
using CocoriCore;

namespace CocoriCore.LeBonCoin
{

    public class ExecuteHandler : IExecuteHandler
    {
        private readonly HandlerFinder handlerTypes;
        private readonly IFactory factory;

        //private readonly IRepository repository;

        public ExecuteHandler(
            HandlerFinder handlerTypes,
            IFactory factory
            )
        {
            this.handlerTypes = handlerTypes;
            this.factory = factory;
        }

        public async Task<T> ExecuteAsync<T>(IMessage<T> message)
        {
            var h = factory.Create(this.handlerTypes.GetHandlerType(message));
            var response = await ((IHandler)h).HandleAsync(message);
            return (T)response;
        }

        public async Task<object> ExecuteAsync(IMessage message)
        {
            var h = factory.Create(this.handlerTypes.GetHandlerType(message));
            var response = await ((IHandler)h).HandleAsync(message);
            return response;
        }
    }
}