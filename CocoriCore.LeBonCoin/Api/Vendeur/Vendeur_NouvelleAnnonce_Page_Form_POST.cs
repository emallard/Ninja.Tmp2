using System;
using System.Threading.Tasks;
using CocoriCore;

namespace CocoriCore.LeBonCoin
{
    public class Vendeur_NouvelleAnnonce_Page_Form_POST : IMessage<Vendeur_NouvelleAnnonce_Page_Form_POSTResponse>
    {
        public Vendeur_NouvelleAnnonce_POST Post;
    }

    public class Vendeur_NouvelleAnnonce_Page_Form_POSTResponse
    {
        public Vendeur_Annonces_Id_Page_GET PageAnnonce;
    }

    public class Vendeur_NouvelleAnnonce_Page_Form_POSTHandler : MessageHandler<Vendeur_NouvelleAnnonce_Page_Form_POST, Vendeur_NouvelleAnnonce_Page_Form_POSTResponse>
    {
        private readonly IMessageBus messageBus;

        public Vendeur_NouvelleAnnonce_Page_Form_POSTHandler(IMessageBus messageBus)
        {
            this.messageBus = messageBus;
        }
        public async override Task<Vendeur_NouvelleAnnonce_Page_Form_POSTResponse> ExecuteAsync(Vendeur_NouvelleAnnonce_Page_Form_POST message)
        {
            await Task.CompletedTask;
            var id = (Guid)await messageBus.ExecuteAsync(message.Post);
            return new Vendeur_NouvelleAnnonce_Page_Form_POSTResponse()
            {
                PageAnnonce = new Vendeur_Annonces_Id_Page_GET { Id = id }
            };
        }
    }
}