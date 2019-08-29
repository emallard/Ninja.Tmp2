namespace CocoriCore
{
    public interface IRedirect<T>
    {
        IMessage<T> GetRedirect();
    }
}