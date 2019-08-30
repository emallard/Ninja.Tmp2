using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CocoriCore;

namespace CocoriCore.LeBonCoin
{
    public class Vendeur_Annonces_Id_Edit_GET : IMessage<Vendeur_Annonces_Id_Edit>
    {
        public Guid Id;
    }

    public class Vendeur_Annonces_Id_Edit
    {
        public Guid Id;
        public string Ville;
        public string Categorie;
        public string Texte;
    }

    public class Vendeur_Annonces_Id_EditHandler : MessageHandler<Vendeur_Annonces_Id_Edit_GET, Vendeur_Annonces_Id_Edit>
    {
        private readonly IRepository repository;

        public Vendeur_Annonces_Id_EditHandler(IRepository repository)
        {
            this.repository = repository;
        }

        public async override Task<Vendeur_Annonces_Id_Edit> ExecuteAsync(Vendeur_Annonces_Id_Edit_GET query)
        {
            var annonce = await repository.LoadAsync<Annonce>(query.Id);
            return new Vendeur_Annonces_Id_Edit()
            {
                Id = annonce.Id,
                Ville = annonce.Ville,
                Categorie = annonce.Categorie,
                Texte = annonce.Texte
            };
        }
    }

}