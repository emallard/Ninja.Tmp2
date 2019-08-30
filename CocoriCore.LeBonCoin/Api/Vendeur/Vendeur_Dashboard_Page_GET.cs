using System;
using System.Threading.Tasks;
using CocoriCore;

namespace CocoriCore.LeBonCoin
{
    public class Vendeur_Dashboard_Page_GET : IPage<Vendeur_Dashboard_Page>, IQuery
    {
    }

    public class Vendeur_Dashboard_Page
    {
        public Vendeur_Dashboard_GETResponse Data;
        public Vendeur_NouvelleAnnonce_Page_GET NouvelleAnnonce = new Vendeur_NouvelleAnnonce_Page_GET();
        public Vendeur_Annonces_Page_GET Reunions = new Vendeur_Annonces_Page_GET();
        public MenuUtilisateur MenuUtilisateur = new MenuUtilisateur();
    }

    public class Vendeur_Dashboard_PAGEHandler : MessageHandler<Vendeur_Dashboard_Page_GET, Vendeur_Dashboard_Page>
    {
        private readonly IExecuteHandler executeHandler;

        public Vendeur_Dashboard_PAGEHandler(IExecuteHandler messageBus)
        {
            this.executeHandler = messageBus;
        }

        public override async Task<Vendeur_Dashboard_Page> ExecuteAsync(Vendeur_Dashboard_Page_GET query)
        {
            var data = (Vendeur_Dashboard_GETResponse)await executeHandler.ExecuteAsync(new Vendeur_Dashboard_GET());

            return new Vendeur_Dashboard_Page()
            {
                Data = data
            };
        }
    }
}