using System;
using System.Threading.Tasks;

namespace CocoriCore
{

    public class PageCallHandler<TPageGet, TMessage, TMessageResponse, TPageResponse> :
            MessageHandler<
                PageCall<TPageGet, TMessage, TMessageResponse, TPageResponse>,
                TPageResponse>
        where TMessage : IMessage<TMessageResponse>, new()
        where TPageGet : IMessage
    {
        private readonly IExecuteHandler executeHandler;

        public PageCallHandler(IExecuteHandler executeHandler)
        {
            this.executeHandler = executeHandler;
        }

        public override async Task<TPageResponse> ExecuteAsync(
            PageCall<TPageGet, TMessage, TMessageResponse, TPageResponse> message)
        {

            var page = await executeHandler.ExecuteAsync(message.PageMessage);
            var pageCall = (PageCall<TPageGet, TMessage, TMessageResponse, TPageResponse>)message.GetType().GetField(message.MemberName).InvokeGetter(page);
            var messageResponse = await executeHandler.ExecuteAsync(message.Message);
            return pageCall.Translate(message.Message, messageResponse);
        }
    }
}