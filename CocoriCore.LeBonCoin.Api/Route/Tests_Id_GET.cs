using System;
using System.Threading.Tasks;

namespace CocoriCore.LeBonCoin.Api
{
    public class Tests_Id_GET : IMessage<Tests_Id_Response>
    {
        public Type Type;
        public string TestName;
    }


    public class Tests_Id_Response
    {
        public HistoryEvent[] Events;
    }

    public class Tests_Id_Handler : MessageHandler<Tests_Id_GET, Tests_Id_Response>
    {
        public override async Task<Tests_Id_Response> ExecuteAsync(Tests_Id_GET message)
        {
            await Task.CompletedTask;
            var testInstance = (TestBase)Activator.CreateInstance(message.Type);
            var methodInfo = message.Type.GetMethod(message.TestName);
            methodInfo.Invoke(testInstance, null);

            return new Tests_Id_Response()
            {
                Events = testInstance.GetHistory().Events.ToArray()
            };
        }
    }
}