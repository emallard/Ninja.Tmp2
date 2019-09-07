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

        public Form<Vendeur_NouvelleAnnonce_POST, Vendeur_Annonces_Id_Page_GET> Creer;
    }

    public class Vendeur_NouvelleAnnonce_PageMapperModule : PageMapperModule
    {
        public Vendeur_NouvelleAnnonce_PageMapperModule()
        {
            Map<Vendeur_NouvelleAnnonce_POST, Guid, Vendeur_Annonces_Id_Page_GET>((m, r) => new Vendeur_Annonces_Id_Page_GET { Id = r });

            // Map<Vendeur_NouvelleAnnonce_Page_GET, Vendeur_NouvelleAnnonce_Page>
        }
    }



    public class Vendeur_NouvelleAnnonce_Page_GETHandler : MessageHandler<Vendeur_NouvelleAnnonce_Page_GET, Vendeur_NouvelleAnnonce_Page>
    {

        public override async Task<Vendeur_NouvelleAnnonce_Page> ExecuteAsync(Vendeur_NouvelleAnnonce_Page_GET message)
        {
            await Task.CompletedTask;
            return new Vendeur_NouvelleAnnonce_Page()
            {
                Creer = new Form<Vendeur_NouvelleAnnonce_POST, Vendeur_Annonces_Id_Page_GET>()
                {
                    Command = new Vendeur_NouvelleAnnonce_POST()
                },
                Categories = new Call<Categories_GET, string[]>(
                    new Categories_GET()
                )
            };
        }
    }
}