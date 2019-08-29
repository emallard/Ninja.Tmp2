namespace CocoriCore
{
    public interface IGet
    {
        object GetMessage { get; }
    }

    public class Get
    {
        public static Get<TGetResponse> New<TGetResponse>(IMessage<TGetResponse> message)
        {
            return new Get<TGetResponse>(message);
        }
    }

    public interface IGet<TGetResponse> : IGet
    {
        IMessage<TGetResponse> Message { get; }
    }

    public class Get<TGetResponse> : IGet<TGetResponse>
    {
        public Get(IMessage<TGetResponse> message)
        {
            Message = message;
        }

        public object GetMessage => Message;

        public IMessage<TGetResponse> Message { get; }
    }
}