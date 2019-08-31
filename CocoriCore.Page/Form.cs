using System;

namespace CocoriCore
{

    public interface IForm
    {
        Type GetPostType();
        Type GetResponseType();
    }

    public interface IForm<TPost, TPostResponse> : IForm
    {
    }

    public class Form<TPost, TPostResponse> : IForm<TPost, TPostResponse> where TPost : new()
    {
        //object IForm.Message;
        public TPost Message;
        public Form()
        {
            Message = new TPost();
        }

        public Form(TPost message)
        {
            Message = message;
        }

        public Type GetPostType()
        {
            return typeof(TPost);
        }

        public Type GetResponseType()
        {
            return typeof(TPostResponse);
        }
    }

}