using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace CocoriCore.LeBonCoin.Api
{
    public class HttpResponseWriterSvgHandler : IHttpReponseWriterHandler
    {

        public async Task WriteResponseAsync(HttpResponseWriterContext context)
        {
            var response = (SvgResponse)context.Response;
            context.HttpResponse.ContentType = "image/svg+xml";
            await context.HttpResponse.WriteAsync(response.Svg);

        }
    }
}