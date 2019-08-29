using System;
using System.Linq;
using System.Threading.Tasks;
using CocoriCore;
using CocoriCore.Linq.Async;

namespace CocoriCore.LeBonCoin
{

    public class Categories_GET : IMessage<Categories_GETResponse>
    {
        public string Texte;
    }

    public class Categories_GETResponse
    {
        public string[] Resultats;
    }


    public class Categories_GETHandler : MessageHandler<Categories_GET, Categories_GETResponse>
    {
        private readonly IRepository repository;

        public Categories_GETHandler(IRepository repository)
        {
            this.repository = repository;
        }

        public override async Task<Categories_GETResponse> ExecuteAsync(Categories_GET command)
        {
            await Task.CompletedTask;
            return new Categories_GETResponse()
            {
                Resultats = new string[] {
                    "Chaussures",
                    "Bijoux"
                }
            };
        }
    }
}
