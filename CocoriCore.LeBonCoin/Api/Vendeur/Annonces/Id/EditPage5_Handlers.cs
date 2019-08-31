using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CocoriCore;

namespace CocoriCore.LeBonCoin
{



    public class PageFormHandler5<TPage, TMessage, TMessageResponse, TFormResponse> :
            MessageHandler<
                PageFormMessage5<TPage, TMessage, TMessageResponse, TFormResponse>,
                TFormResponse>

        //where TPageGet : IMessage<TPage>
        where TMessage : IMessage<TMessageResponse>
    {
        private readonly ExecuteHandler executeHandler;

        public PageFormHandler5(ExecuteHandler executeHandler)
        {
            this.executeHandler = executeHandler;
        }

        public override async Task<TFormResponse> ExecuteAsync(
            PageFormMessage5<TPage, TMessage, TMessageResponse, TFormResponse> formMessage)
        {
            var page = await executeHandler.ExecuteAsync(formMessage.PageGet);
            var form = formMessage.Form(page);
            var messageResponse = await executeHandler.ExecuteAsync(formMessage.Message);
            return form.Translate(formMessage.Message, messageResponse);
        }
    }
}