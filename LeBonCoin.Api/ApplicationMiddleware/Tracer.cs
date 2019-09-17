using System.Threading.Tasks;
using CocoriCore;

namespace LeBonCoin.Api
{
    public class Tracer : ITracer
    {
        public async Task Trace(object obj)
        {
            await Task.CompletedTask;
        }
    }
}