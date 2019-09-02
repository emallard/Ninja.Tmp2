using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CocoriCore;

namespace CocoriCore.LeBonCoin
{
    public class Vendeur_NouvelleAnnonce_Page_GET : IPage<Vendeur_NouvelleAnnonce_Page>
    {
    }

    public class Vendeur_NouvelleAnnonce_Page
    {
        public Call<Categories_GET, string[]> Categories;

        public PageCall<Vendeur_NouvelleAnnonce_Page_GET, Vendeur_NouvelleAnnonce_POST, Guid, Vendeur_NouvelleAnnonce_Page_Form_POSTResponse> Form;
    }

    public class Vendeur_NouvelleAnnonce_Page_Form_POSTResponse
    {
        public Vendeur_Annonces_Id_Page_GET PageAnnonce;
    }

    public class Vendeur_NouvelleAnnonce_Page_GETHandler : MessageHandler<Vendeur_NouvelleAnnonce_Page_GET, Vendeur_NouvelleAnnonce_Page>
    {

        public override async Task<Vendeur_NouvelleAnnonce_Page> ExecuteAsync(Vendeur_NouvelleAnnonce_Page_GET message)
        {
            await Task.CompletedTask;
            return new Vendeur_NouvelleAnnonce_Page()
            {
                Categories = new Call<Categories_GET, string[]>(new Categories_GET()),
                Form = new PageCall<Vendeur_NouvelleAnnonce_Page_GET, Vendeur_NouvelleAnnonce_POST, Guid, Vendeur_NouvelleAnnonce_Page_Form_POSTResponse>
                {
                    PageMessage = message,
                    Message = new Vendeur_NouvelleAnnonce_POST(),
                    Translate = (m, id) => new Vendeur_NouvelleAnnonce_Page_Form_POSTResponse()
                    {
                        PageAnnonce = new Vendeur_Annonces_Id_Page_GET() { Id = id }
                    }
                }
            };
        }
    }
}