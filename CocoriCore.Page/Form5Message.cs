using System;
using System.Threading.Tasks;

namespace CocoriCore
{
    public class Form5Message<TPage, TMessage, TMessageResponse, TFormResponse> : IMessage<TFormResponse>
    {
        public IMessage<TPage> PageGet;
        public TMessage Message;
        public Func<TPage, Form5<TMessage, TMessageResponse, TFormResponse>> Form;

    }

    public class PageFormHandler5<TPage, TMessage, TMessageResponse, TFormResponse> :
            MessageHandler<
                Form5Message<TPage, TMessage, TMessageResponse, TFormResponse>,
                TFormResponse>
        where TMessage : IMessage<TMessageResponse>
    {
        private readonly IExecuteHandler executeHandler;

        public PageFormHandler5(IExecuteHandler executeHandler)
        {
            this.executeHandler = executeHandler;
        }

        public override async Task<TFormResponse> ExecuteAsync(
            Form5Message<TPage, TMessage, TMessageResponse, TFormResponse> Form5Message)
        {
            var page = await executeHandler.ExecuteAsync(Form5Message.PageGet);
            var form = Form5Message.Form(page);
            var messageResponse = await executeHandler.ExecuteAsync(Form5Message.Message);
            return form.Translate(Form5Message.Message, messageResponse);
        }
    }
}