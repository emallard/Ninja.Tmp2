namespace CocoriCore
{
    public interface ILink
    {
        object GetMessage { get; }
    }

    public interface ILink<out T> : ILink
    {
        T Message { get; }
    }
}