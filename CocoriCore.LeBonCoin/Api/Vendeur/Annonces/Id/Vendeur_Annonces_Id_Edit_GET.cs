using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CocoriCore;

namespace CocoriCore.LeBonCoin
{
    public class Vendeur_Annonces_Id_Edit_GET : IMessage<Vendeur_Annonces_Id_Edit_GETResponse>
    {
        public Guid Id;
    }

    public class Vendeur_Annonces_Id_Edit_GETResponse
    {
        public string Ville;
        public string Categorie;
        public string Texte;
    }

    public class Vendeur_Annonces_Id_EditHandler : MessageHandler<Vendeur_Annonces_Id_Edit_GET, Vendeur_Annonces_Id_Edit_GETResponse>
    {
        private readonly IRepository repository;

        public Vendeur_Annonces_Id_EditHandler(IRepository repository)
        {
            this.repository = repository;
        }

        public async override Task<Vendeur_Annonces_Id_Edit_GETResponse> ExecuteAsync(Vendeur_Annonces_Id_Edit_GET query)
        {
            var annonce = await repository.LoadAsync<Annonce>(query.Id);
            return new Vendeur_Annonces_Id_Edit_GETResponse()
            {
                Ville = annonce.Ville,
                Categorie = annonce.Categorie,
                Texte = annonce.Texte
            };
        }
    }

}