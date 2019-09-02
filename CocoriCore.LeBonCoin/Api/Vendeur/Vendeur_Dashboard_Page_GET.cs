using System;
using System.Threading.Tasks;
using CocoriCore;

namespace CocoriCore.LeBonCoin
{
    public class Vendeur_Dashboard_Page_GET : IPage<Vendeur_Dashboard_Page>
    {
    }

    public class Vendeur_Dashboard_Page
    {
        public Call<Vendeur_Dashboard_GET, Vendeur_Dashboard> Data;
        public Vendeur_NouvelleAnnonce_Page_GET NouvelleAnnonce = new Vendeur_NouvelleAnnonce_Page_GET();
        public Vendeur_Annonces_Page_GET Reunions = new Vendeur_Annonces_Page_GET();
        public MenuUtilisateur MenuUtilisateur = new MenuUtilisateur();
    }

    public class Vendeur_Dashboard_PAGEHandler : MessageHandler<Vendeur_Dashboard_Page_GET, Vendeur_Dashboard_Page>
    {
        public override async Task<Vendeur_Dashboard_Page> ExecuteAsync(Vendeur_Dashboard_Page_GET query)
        {
            await Task.CompletedTask;
            return new Vendeur_Dashboard_Page()
            {
                Data = new Call<Vendeur_Dashboard_GET, Vendeur_Dashboard>()
                {
                    Message = new Vendeur_Dashboard_GET()
                }
            };
        }
    }
}