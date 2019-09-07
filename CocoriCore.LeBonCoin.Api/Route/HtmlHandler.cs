using System;
using System.IO;
using System.Threading.Tasks;

namespace CocoriCore.LeBonCoin.Api
{
    public class HtmlMessage : IMessage<HtmlResponse>
    {
        public string Q;
    }

    public class HtmlResponse
    {
        public string Html;
    }

    public class HtmlMessageHandler : MessageHandler<HtmlMessage, HtmlResponse>
    {
        public override async Task<HtmlResponse> ExecuteAsync(HtmlMessage message)
        {
            var filename = System.IO.Path.Combine("CocoriCore.LeBonCoin.Api", "page.html");
            filename = System.IO.Path.GetFullPath(filename);
            var html = File.ReadAllText(filename);
            await Task.CompletedTask;
            return new HtmlResponse()
            {
                Html = html
            };
        }
    }
}