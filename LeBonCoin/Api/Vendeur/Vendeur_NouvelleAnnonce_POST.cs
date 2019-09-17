using System;
using System.Threading.Tasks;
using CocoriCore;

namespace LeBonCoin
{
    public class Vendeur_NouvelleAnnonce_POST : IMessage<Guid>
    {
        public string Ville;
        public string Categorie;
        public string Texte;
    }

    public class Vendeur_NouvelleAnnonce_POSTHandler : MessageHandler<Vendeur_NouvelleAnnonce_POST, Guid>
    {
        private readonly IRepository repository;

        public Vendeur_NouvelleAnnonce_POSTHandler(IRepository repository)
        {
            this.repository = repository;
        }

        public async override Task<Guid> ExecuteAsync(Vendeur_NouvelleAnnonce_POST query)
        {
            var id = Guid.NewGuid();
            var annonce = new Annonce();
            annonce.Id = id;
            annonce.Ville = query.Ville;
            annonce.Categorie = query.Categorie;
            annonce.Texte = query.Texte;
            await repository.InsertAsync(annonce);
            return id;
        }
    }
}