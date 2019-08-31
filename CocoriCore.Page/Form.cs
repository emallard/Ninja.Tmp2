using System;

namespace CocoriCore
{

    public interface IForm
    {
        Type GetPostType();
        Type GetResponseType();
    }

    public class Form<TPost, TPostResponse> : IForm
    {
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