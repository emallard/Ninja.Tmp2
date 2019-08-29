using System;
using System.Threading.Tasks;
using CocoriCore;

namespace CocoriCore.LeBonCoin.Api
{
    public class MyErrorBus : IErrorBus
    {
        public async Task HandleAsync(Exception exception)
        {
            await Task.CompletedTask;
        }
    }
}