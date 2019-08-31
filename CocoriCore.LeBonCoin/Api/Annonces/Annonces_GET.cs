using System;
using System.Linq;
using System.Threading.Tasks;
using CocoriCore;
using CocoriCore.Linq.Async;

namespace CocoriCore.LeBonCoin
{

    public class Annonces_GET : IMessage<Annonces_Item[]>, IQuery
    {
        public string Ville;
        public string Categorie;
    }

    public class Annonces_Item
    {
        public Guid Id;
        public string Ville;
        public string Categorie;
        public string Text;
    }


    public class Annonces_GETHandler : MessageHandler<Annonces_GET, Annonces_Item[]>
    {
        private readonly IRepository repository;

        public Annonces_GETHandler(IRepository repository)
        {
            this.repository = repository;
        }

        public override async Task<Annonces_Item[]> ExecuteAsync(Annonces_GET message)
        {
            var annonces = await repository.Query<Annonce>().Where(a => a.Ville == message.Ville).ToArrayAsync();
            return annonces.Select(x => new Annonces_Item()
            {
                Id = x.Id,
                Ville = x.Ville,
                Categorie = x.Categorie,
                Text = x.Texte
            }).ToArray();
        }
    }
}