using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CocoriCore;

namespace CocoriCore.LeBonCoin
{
    public class Vendeur_Annonces_Id_Edit_PAGE : IPage<Vendeur_Annonces_Id_Edit_PAGEResponse>
    {
        public Guid Id;
    }

    public class Vendeur_Annonces_Id_Edit_PAGEResponse
    {
        public string Ville;
        public string Categorie;

        public IEnumerable<string> ListCategories;

    }

    public class Vendeur_Annonces_Id_Edit_PAGEHandler : MessageHandler<Vendeur_Annonces_Id_Edit_PAGE, Vendeur_Annonces_Id_Edit_PAGEResponse>
    {
        public Vendeur_Annonces_Id_Edit_PAGEHandler()
        {

        }

        public override Task<Vendeur_Annonces_Id_Edit_PAGEResponse> ExecuteAsync(Vendeur_Annonces_Id_Edit_PAGE query)
        {
            throw new NotImplementedException();
        }
    }

}