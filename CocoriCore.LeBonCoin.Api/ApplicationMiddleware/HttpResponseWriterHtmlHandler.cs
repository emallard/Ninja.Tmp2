using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace CocoriCore.LeBonCoin.Api
{
    public class HttpResponseWriterHtmlHandler : IHttpReponseWriterHandler
    {

        public async Task WriteResponseAsync(HttpResponseWriterContext context)
        {
            var response = (HtmlResponse)context.Response;
            context.HttpResponse.ContentType = "text/html";
            await context.HttpResponse.WriteAsync(response.Html);

        }
    }
}