using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CocoriCore;

namespace CocoriCore.LeBonCoin
{

    public class PageFormMessage4<TPageGet, TPage, TMessage, TMessageResponse, TFormResponse> : IMessage<TFormResponse>
    {
        public TPageGet PageGet;
        public TMessage Message;
        public Func<TPage, Form4<TMessage, TMessageResponse, TFormResponse>> Form;

    }

    public class PageGetMessage4<T>
    {

    }

    public class PageGetHandler4<TPageGet, TPage> : MessageHandler<TPageGet, TPage>
        where TPageGet : IMessage<TPage>
        where TPage : IPage4<TPageGet>, new()
    {
        public override async Task<TPage> ExecuteAsync(TPageGet pageGet)
        {
            await Task.CompletedTask;
            var response = new TPage();
            response.Set(pageGet);
            return response;
        }
    }


    public class PageFormHandler4<TPageGet, TPage, TMessage, TMessageResponse, TFormResponse> :
            MessageHandler<
                PageFormMessage4<TPageGet, TPage, TMessage, TMessageResponse, TFormResponse>,
                TFormResponse>

        where TPageGet : IMessage<TPage>
        where TPage : IPage4<TPageGet>, new()
        where TMessage : IMessage<TMessageResponse>
    {
        private readonly ExecuteHandler executeHandler;

        public PageFormHandler4(ExecuteHandler executeHandler)
        {
            this.executeHandler = executeHandler;
        }

        public override async Task<TFormResponse> ExecuteAsync(
            PageFormMessage4<TPageGet, TPage, TMessage, TMessageResponse, TFormResponse> formMessage)
        {
            var page = new TPage();
            page.Set(formMessage.PageGet);
            var form = formMessage.Form(page);
            var messageResponse = await executeHandler.ExecuteAsync(formMessage.Message);
            return form.Translate(formMessage.Message, messageResponse);
        }
    }
}