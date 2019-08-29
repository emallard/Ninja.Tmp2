using System;
using System.Threading.Tasks;
using CocoriCore;

namespace CocoriCore.LeBonCoin
{
    public class Vendeur_NouvelleAnnonce_POST : IMessage<Guid>
    {
        public string Ville;
        public string Categorie;
    }

    public class Vendeur_NouvelleAnnonce_POSTHandler : MessageHandler<Vendeur_NouvelleAnnonce_POST, Guid>
    {
        public async override Task<Guid> ExecuteAsync(Vendeur_NouvelleAnnonce_POST query)
        {
            await Task.CompletedTask;
            var id = Guid.NewGuid();
            return id;
        }
    }
}