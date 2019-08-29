using System;
using System.Threading.Tasks;
using CocoriCore;

namespace CocoriCore.LeBonCoin
{
    public class Vendeur_Dashboard_PAGE : IPage<Vendeur_Dashboard_PAGEResponse>, IQuery
    {
    }

    public class Vendeur_Dashboard_PAGEResponse
    {
        public Vendeur_Dashboard_GETResponse Data;
        public Vendeur_NouvelleAnnonce_Page_GET NouvelleAnnonce = new Vendeur_NouvelleAnnonce_Page_GET();
        public Vendeur_Annonces_Page_GET Reunions = new Vendeur_Annonces_Page_GET();
        public MenuUtilisateur MenuUtilisateur = new MenuUtilisateur();
    }

    public class Vendeur_Dashboard_PAGEHandler : MessageHandler<Vendeur_Dashboard_PAGE, Vendeur_Dashboard_PAGEResponse>
    {
        private readonly IMessageBus messageBus;

        public Vendeur_Dashboard_PAGEHandler(IMessageBus messageBus)
        {
            this.messageBus = messageBus;
        }

        public override async Task<Vendeur_Dashboard_PAGEResponse> ExecuteAsync(Vendeur_Dashboard_PAGE query)
        {
            var data = (Vendeur_Dashboard_GETResponse)await messageBus.ExecuteAsync(new Vendeur_Dashboard_GET());

            return new Vendeur_Dashboard_PAGEResponse()
            {
                Data = data
            };
        }
    }
}