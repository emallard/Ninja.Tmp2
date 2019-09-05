using System;
using System.Threading.Tasks;

namespace CocoriCore.LeBonCoin.Api
{
    public class FavIconMessage : IMessage<string>
    {
    }

    public class FavIconMessageHandler : MessageHandler<FavIconMessage, string>
    {
        public override async Task<string> ExecuteAsync(FavIconMessage message)
        {
            await Task.CompletedTask;
            return "";
        }
    }
}