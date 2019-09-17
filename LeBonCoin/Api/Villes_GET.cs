using System;
using System.Linq;
using System.Threading.Tasks;
using CocoriCore;
using CocoriCore.Linq.Async;

namespace LeBonCoin
{

    public class Villes_GET : IMessage<string[]>
    {
        public string Texte;
    }


    public class Villes_GETHandler : MessageHandler<Villes_GET, string[]>
    {
        private readonly IRepository repository;

        public Villes_GETHandler(IRepository repository)
        {
            this.repository = repository;
        }

        public override async Task<string[]> ExecuteAsync(Villes_GET command)
        {
            await Task.CompletedTask;
            return new string[] {
                "Paris",
                "Bordeaux"
            };
        }
    }
}
