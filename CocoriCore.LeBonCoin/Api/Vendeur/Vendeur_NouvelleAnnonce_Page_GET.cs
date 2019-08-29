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
        public Vendeur_NouvelleAnnonce_GETResponse Data;

        public Form<Vendeur_NouvelleAnnonce_Page_Form_POST, Vendeur_NouvelleAnnonce_Page_Form_POSTResponse> Form = new Form<Vendeur_NouvelleAnnonce_Page_Form_POST, Vendeur_NouvelleAnnonce_Page_Form_POSTResponse>();
    }

    public class Vendeur_NouvelleAnnonce_Page_GETHandler : MessageHandler<Vendeur_NouvelleAnnonce_Page_GET, Vendeur_NouvelleAnnonce_Page>
    {
        private readonly IMessageBus messageBus;

        public Vendeur_NouvelleAnnonce_Page_GETHandler(IMessageBus messageBus)
        {
            this.messageBus = messageBus;
        }

        public override async Task<Vendeur_NouvelleAnnonce_Page> ExecuteAsync(Vendeur_NouvelleAnnonce_Page_GET query)
        {
            await Task.CompletedTask;
            return new Vendeur_NouvelleAnnonce_Page()
            {
                Data = (Vendeur_NouvelleAnnonce_GETResponse)await messageBus.ExecuteAsync(new Vendeur_NouvelleAnnonce_GET())
            };
        }
    }
}