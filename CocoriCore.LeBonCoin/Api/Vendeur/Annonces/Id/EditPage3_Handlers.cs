using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CocoriCore;

namespace CocoriCore.LeBonCoin
{

    public class PageGetMessage3<T>
    {

    }

    public class PageGetHandler3<TPageGet, TPageResponse> : MessageHandler<TPageGet, TPageResponse>
        where TPageGet : IMessage<TPageResponse>
        where TPageResponse : new()
    {
        public override async Task<TPageResponse> ExecuteAsync(TPageGet _message)
        {
            //var response = new TPageResponse();
            var message = new EditPage3.PageGet();
            var response = new EditPage3.PageResponse();
            response.Data.Message = response.Data.MessageFunc(message);
            response.Form.Message = response.Form.MessageFunc(message);

            await Task.CompletedTask;
            throw new NotImplementedException();
        }
    }

    public class PageFormMessage3<TPageGet, TPageResponse, TMessage, TMessageResponse, TFormResponse> : IMessage<TFormResponse>
    {
        public TPageGet PageGet;
        public TMessage Message;
        public Func<TPageResponse, Form3<TPageGet, TMessage, TMessageResponse, TFormResponse>> Form;

    }

    public class PageFormHandler3<TPageGet, TPageResponse, TMessage, TMessageResponse, TFormResponse> :
            MessageHandler<
                PageFormMessage3<TPageGet, TPageResponse, TMessage, TMessageResponse, TFormResponse>,
                TFormResponse>

        where TPageGet : IMessage<TPageResponse>
        where TPageResponse : new()
    {
        private readonly ExecuteHandler executeHandler;

        public PageFormHandler3(ExecuteHandler executeHandler)
        {
            this.executeHandler = executeHandler;
        }

        public override async Task<TFormResponse> ExecuteAsync(
            PageFormMessage3<TPageGet, TPageResponse, TMessage, TMessageResponse, TFormResponse> formMessage)
        {
            var pageGet = new EditPage3.PageGet(); // formMessage.PageGet
            var pageResponse = new EditPage3.PageResponse(); // new TPageResponse()
            var message = new Vendeur_Annonces_Id_Edit_GET(); // formMessage.Message
            var form = pageResponse.Data; // formMessage.Form(pageResponse)

            var messageResponse = await executeHandler.ExecuteAsync(message);
            var formResponse = form.Execute(message, messageResponse);

            await Task.CompletedTask;
            throw new NotImplementedException();
        }
    }
}