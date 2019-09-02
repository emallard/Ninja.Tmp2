using System;
using System.IO;
using System.Threading.Tasks;
using CocoriCore.Page;
using Newtonsoft.Json;
using Xunit;

namespace CocoriCore.LeBonCoin
{
    public class PageCallConverterTest
    {

        [Fact]
        public void Test()
        {
            var pageCall = new PageCall<PageMessage, Message, Response, PageCallResponse>()
            {
                PageMessage = new PageMessage() { Id = Guid.NewGuid() },
                Message = new Message() { Id = Guid.NewGuid() },
                Translate = (m, r) => new PageCallResponse()
                {
                    Hello = r.Hello,
                    ALink = "/alink"
                }
            };

            var settings = new JsonSerializerSettings()
            {
                Converters = { new PageCallConverter() }
            };
            var jsonSerializer = JsonSerializer.Create(settings);

            var jsonString = jsonSerializer.Serialize(pageCall);

            var deserialized = (IPageCall)jsonSerializer.Deserialize(
                    new JsonTextReader(new StringReader(jsonString)),
                    typeof(IPageCall));

            Console.WriteLine(deserialized.GetType()); // Must be Call<Message, Response>
        }

        class PageMessage : IMessage<PageResponse>
        {
            public Guid Id;
        }
        class PageResponse
        {
            public PageCall<PageMessage, Message, Response, PageCallResponse> Form;
        }


        class Message : IMessage<Response>
        {
            public Guid Id;
        }

        class Response
        {
            public string Hello;
        }

        class MessageHandler : MessageHandler<Message, Response>
        {
            public override async Task<Response> ExecuteAsync(Message message)
            {
                await Task.CompletedTask;
                return new Response()
                {
                    Hello = "Hello " + message.Id + " !"
                };
            }
        }

        class PageCallResponse
        {
            public string Hello;
            public string ALink;
        }

        class ExecuteHandler : IExecuteHandler
        {
            public async Task<T> ExecuteAsync<T>(IMessage<T> message)
            {
                return (T)await (this.ExecuteAsync((IMessage)message));
            }

            public async Task<object> ExecuteAsync(IMessage message)
            {
                if (message is Message m)
                    return await (new MessageHandler().ExecuteAsync(m));

                throw new NotImplementedException();
            }
        }
    }
}