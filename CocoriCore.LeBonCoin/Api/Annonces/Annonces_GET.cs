using System;
using System.Linq;
using System.Threading.Tasks;
using CocoriCore;
using CocoriCore.Linq.Async;

namespace CocoriCore.LeBonCoin
{

    public class Annonces_GETResponseItem
    {
        public Guid Id;
        public string Ville;
        public string Categorie;
        public string Text;
    }

    public class Annonces_GET : IPage<Annonces_GETResponse>, IQuery
    {
        public string Ville;
        public string Categorie;
    }

    public class Annonces_GETResponse
    {
        public Annonce[] Items;
    }

    public class Annonces_GETHandler : MessageHandler<Annonces_GET, Annonces_GETResponse>
    {
        private readonly IRepository repository;

        public Annonces_GETHandler(IRepository repository)
        {
            this.repository = repository;
        }

        public override async Task<Annonces_GETResponse> ExecuteAsync(Annonces_GET message)
        {
            var annonces = await repository.Query<Annonce>().Where(a => a.Ville == message.Ville).ToArrayAsync();
            var response = new Annonces_GETResponse()
            {
                Items = annonces
            };
            return response;
        }
    }
}