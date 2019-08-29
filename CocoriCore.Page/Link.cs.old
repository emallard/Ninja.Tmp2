namespace CocoriCore
{

    public class Link
    {
        public static Link<U> New<U>(U u) where U : new()
        {
            return new Link<U>(u);
        }
    }

    public class Link<T> : ILink<T> where T : new()
    {
        public Link()
        {
            Message = new T();
        }

        public Link(T t)
        {
            Message = t;
        }

        public T Message { get; set; }
        public object GetMessage => Message;
    }
}