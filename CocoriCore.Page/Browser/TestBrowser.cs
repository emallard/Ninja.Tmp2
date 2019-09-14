using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using CocoriCore;

namespace CocoriCore.Page
{

    public class TestBrowser : IBrowser
    {
        private readonly IUnitOfWorkFactory unitOfWorkFactory;
        private readonly TestBrowserClaimsProvider browserclaimsProvider;
        private IClaims claims;

        public TestBrowser(
            IUnitOfWorkFactory unitOfWorkFactory,
            TestBrowserClaimsProvider browserclaimsProvider)
        {
            this.unitOfWorkFactory = unitOfWorkFactory;
            this.browserclaimsProvider = browserclaimsProvider;
        }

        public async Task<T> Follow<TPage, T>(TPage page, Expression<Func<TPage, IMessage<T>>> expressionMessage)
        {
            var func = expressionMessage.Compile();
            var message = func(page);
            return await this.ExecuteAsync(message);
        }

        public async Task<T> Display<T>(IMessage<T> message)
        {
            return await this.ExecuteAsync(message);
        }

        public async Task<T> SubmitRedirect<T>(IMessage<T> message)
        {
            return await this.ExecuteAsync(message);
        }

        private async Task<T> ExecuteAsync<T>(IMessage<T> message)
        {
            return (T)(await this.ExecuteAsync((IMessage)message));
        }

        private async Task<object> ExecuteAsync(IMessage message)
        {
            using (var unitOfWork = unitOfWorkFactory.NewUnitOfWork())
            {
                unitOfWork.Resolve<IClaimsWriter>().SetClaims(claims); ;
                var messagebus = unitOfWork.Resolve<IMessageBus>();
                var response = await messagebus.ExecuteAsync(message);

                var newClaims = browserclaimsProvider.OnResponse(response);
                if (newClaims != null)
                    this.claims = newClaims;
                return response;
            }
        }
    }
}
