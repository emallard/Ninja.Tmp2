using System;

namespace CocoriCore
{

    public class Form<TPost, TPostResponse, TRedirectGet> : IForm where TRedirectGet : IPage
    {
        public Form(TRedirectGet redirectMessage)
        {
            RedirectMessage = redirectMessage;
            FillRedirect = (r, m) => { };
        }

        public Form(TRedirectGet redirectMessage, Action<TPostResponse, TRedirectGet> fillRedirect)
        {
            RedirectMessage = redirectMessage;
            FillRedirect = fillRedirect;
        }

        public Action<TPostResponse, TRedirectGet> FillRedirect { get; }
        public TRedirectGet RedirectMessage { get; }

        public Type GetPostType()
        {
            return typeof(TPost);
        }

        public object GetRedirectMessage()
        {
            return RedirectMessage;
        }
    }
}