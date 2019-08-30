using System.Threading.Tasks;

namespace CocoriCore.LeBonCoin
{
    public interface IExecuteHandler
    {
        Task<T> ExecuteAsync<T>(IMessage<T> message);
    }
}