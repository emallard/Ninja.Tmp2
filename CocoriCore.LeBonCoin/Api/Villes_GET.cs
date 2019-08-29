using System;
using System.Linq;
using System.Threading.Tasks;
using CocoriCore;
using CocoriCore.Linq.Async;

namespace CocoriCore.LeBonCoin
{

    public class Villes_GET : IMessage<Villes_GETResponse>
    {
        public string Texte;
    }

    public class Villes_GETResponse
    {
        public string[] Resultats;
    }


    public class Villes_GETHandler : MessageHandler<Villes_GET, Villes_GETResponse>
    {
        private readonly IRepository repository;

        public Villes_GETHandler(IRepository repository)
        {
            this.repository = repository;
        }

        public override async Task<Villes_GETResponse> ExecuteAsync(Villes_GET command)
        {
            await Task.CompletedTask;
            return new Villes_GETResponse()
            {
                Resultats = new string[] {
                    "Paris",
                    "Bordeaux"
                }
            };
        }
    }
}
