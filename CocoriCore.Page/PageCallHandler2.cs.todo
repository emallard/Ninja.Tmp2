using System.Threading.Tasks;

namespace CocoriCore
{
    public class PageCallHandler2 : IHandler
    {
        private readonly IExecuteHandler executeHandler;

        public PageCallHandler2(IExecuteHandler executeHandler)
        {
            this.executeHandler = executeHandler;
        }

        public async Task<object> HandleAsync(IMessage message)
        {
            return await executeHandler.ExecuteAsync(message);
        }
    }
}