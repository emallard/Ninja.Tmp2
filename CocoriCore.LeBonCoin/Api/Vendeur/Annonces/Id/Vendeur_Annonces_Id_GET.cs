using System;
using System.Threading.Tasks;
using CocoriCore;

namespace CocoriCore.LeBonCoin
{

    public class Vendeur_Annonces_Id_GET : IPage<Vendeur_Annonces_Id_GETResponse>
    {
        public Guid Id;
    }

    public class Vendeur_Annonces_Id_GETResponse
    {
        public Guid Id;
        public string Ville;
        public string Categorie;
    }

    public class Vendeur_Annonces_Id_GETHandler : MessageHandler<Vendeur_Annonces_Id_GET, Vendeur_Annonces_Id_GETResponse>
    {
        public async override Task<Vendeur_Annonces_Id_GETResponse> ExecuteAsync(Vendeur_Annonces_Id_GET query)
        {
            await Task.CompletedTask;
            return new Vendeur_Annonces_Id_GETResponse()
            {
                Id = query.Id,
                Ville = "TODO",
                Categorie = "TODO"
            };
        }
    }
}
