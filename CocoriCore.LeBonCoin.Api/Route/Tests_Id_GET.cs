using System;
using System.Threading.Tasks;
using CocoriCore.Router;

namespace CocoriCore.LeBonCoin.Api
{
    public class Tests_Id_GET : IMessage<Tests_Id_Response>
    {
        public string Type;
        public string TestName;
    }


    public class Tests_Id_Response
    {
        public HistoryEvent[] Events;
    }

    public class Tests_Id_Handler : MessageHandler<Tests_Id_GET, Tests_Id_Response>
    {
        private readonly RouterOptions routerOptions;

        public Tests_Id_Handler(RouterOptions routerOptions)
        {
            this.routerOptions = routerOptions;
        }

        public override async Task<Tests_Id_Response> ExecuteAsync(Tests_Id_GET message)
        {
            await Task.CompletedTask;

            var testType = Type.GetType(System.Web.HttpUtility.UrlDecode(message.Type));
            var testInstance = (TestBase)Activator.CreateInstance(testType);

            await Task.Run(() =>
            {
                //testInstance.WithSeleniumBrowser(routerOptions);
                var methodInfo = testType.GetMethod(message.TestName);
                var result = methodInfo.Invoke(testInstance, null);
                if (result is Task task)
                {
                    task.Wait(); ;
                }
            });

            var events = testInstance.GetHistory().Events.ToArray();
            return new Tests_Id_Response() { Events = events };
        }
    }
}