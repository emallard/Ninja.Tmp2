using System;
using System.Threading.Tasks;
using CocoriCore;

namespace LeBonCoin
{

    public class Vendeur_Annonces_Id_GET : IPageQuery<Vendeur_Annonces_Id>
    {
        public Guid Id;
    }

    public class Vendeur_Annonces_Id
    {
        public Guid Id;
        public string Ville;
        public string Categorie;
        public string Texte;
    }

    public class Vendeur_Annonces_Id_GETHandler : MessageHandler<Vendeur_Annonces_Id_GET, Vendeur_Annonces_Id>
    {
        private readonly IRepository repository;

        public Vendeur_Annonces_Id_GETHandler(IRepository repository)
        {
            this.repository = repository;
        }

        public async override Task<Vendeur_Annonces_Id> ExecuteAsync(Vendeur_Annonces_Id_GET query)
        {
            var annonce = await repository.LoadAsync<Annonce>(query.Id);
            return new Vendeur_Annonces_Id()
            {
                Id = annonce.Id,
                Ville = annonce.Ville,
                Categorie = annonce.Categorie,
                Texte = annonce.Texte
            };
        }
    }
}
