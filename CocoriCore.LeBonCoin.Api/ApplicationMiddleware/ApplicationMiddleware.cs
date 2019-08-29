using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using CocoriCore;
using CocoriCore.Router;

namespace CocoriCore.LeBonCoin.Api
{

    public class ApplicationMiddleware
    {
        private readonly IRouter router;
        private readonly MessageDeserializer messageDeserializer;
        private readonly IMessageBus messageBus;
        private readonly IErrorBus errorBus;
        private readonly IHttpResponseWriter responseWriter;
        private readonly IHttpErrorWriter errorWriter;
        private readonly ITracer tracer;

        public ApplicationMiddleware(
            IRouter router,
            MessageDeserializer messageDeserializer,
            IMessageBus messageBus,
            IErrorBus errorBus,
            IHttpResponseWriter responseWriter,
            IHttpErrorWriter errorWriter,
            ITracer tracer
        )
        {
            this.router = router;
            this.messageDeserializer = messageDeserializer;
            this.messageBus = messageBus;
            this.errorBus = errorBus;
            this.responseWriter = responseWriter;
            this.errorWriter = errorWriter;
            this.tracer = tracer;
        }


        public async Task InvokeAsync(HttpContext httpContext, Func<Task> next)
        {
            var start = DateTime.Now;
            Route route = null;
            try
            {
                route = (Route)router.TryFindRoute(httpContext.Request);
                if (route != null)
                {
                    var message = await this.messageDeserializer.DeserializeMessageAsync<IMessage>(httpContext.Request, route);
                    var response = await messageBus.ExecuteAsync(message);
                    await responseWriter.WriteResponseAsync(response, httpContext.Response);
                }
                else
                    throw new RouteNotFoundException(httpContext);
            }
            catch (Exception exception)
            {
                await errorBus.HandleAsync(exception);
                await errorWriter.WriteErrorAsync(exception, httpContext.Response);
            }

            var trace = new HttpTrace(httpContext, start, DateTime.Now);
            await tracer.Trace(trace);

            // next if route not found  ?
            //if (route == null)
            //    await next();
        }
    }
}