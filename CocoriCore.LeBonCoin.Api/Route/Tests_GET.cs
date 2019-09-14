using System;
using System.Linq;
using System.Threading.Tasks;

namespace CocoriCore.LeBonCoin.Api
{
    public class Tests_GET : IMessage<Tests_Response[]>
    {

    }

    public class Tests_Response
    {
        public Type Type;
        public string ClassName;
        public string TestName;
    }

    public class Tests_GETHandler : MessageHandler<Tests_GET, Tests_Response[]>
    {
        public override async Task<Tests_Response[]> ExecuteAsync(Tests_GET message)
        {
            await Task.CompletedTask;
            var assembly = CocoriCore.LeBonCoin.AssemblyInfo.Assembly;
            return assembly.GetTypes().SelectMany(t =>
            {
                var methods = t.GetMethods().Where(m => m.GetCustomAttributes(typeof(Xunit.FactAttribute), false).Length > 0).ToArray();
                return methods.Select(m => new Tests_Response
                {
                    Type = t,
                    ClassName = t.Name,
                    TestName = m.Name
                }).ToArray();
            }).ToArray();
        }
    }
}