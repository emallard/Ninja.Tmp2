namespace CocoriCore
{

    public interface IPage
    {

    }

    public interface IPage<T> : IMessage<T>, IPage
    {

    }
}