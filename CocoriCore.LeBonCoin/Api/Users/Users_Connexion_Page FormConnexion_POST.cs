using System;
using System.Linq;
using System.Threading.Tasks;
using CocoriCore;

namespace CocoriCore.LeBonCoin
{

    public class Users_Connexion_PAGE_FormConnexion_POST : IMessage<Users_Connexion_PAGE_FormConnexion_POSTResponse>
    {
        public Users_Connexion_POST Post;
    }

    public class Users_Connexion_PAGE_FormConnexion_POSTResponse
    {
        public Vendeur_Dashboard_PAGE DashboardPage;
    }

    public class Users_Connexion_PAGE_FormConnexionHandler : MessageHandler<Users_Connexion_PAGE_FormConnexion_POST, Users_Connexion_PAGE_FormConnexion_POSTResponse>
    {
        private readonly IMessageBus messageBus;

        public Users_Connexion_PAGE_FormConnexionHandler(IMessageBus messageBus)
        {
            this.messageBus = messageBus;
        }

        public override async Task<Users_Connexion_PAGE_FormConnexion_POSTResponse> ExecuteAsync(Users_Connexion_PAGE_FormConnexion_POST message)
        {
            var response = (Users_Connexion_POST)await messageBus.ExecuteAsync(message.Post);
            return new Users_Connexion_PAGE_FormConnexion_POSTResponse()
            {
                DashboardPage = new Vendeur_Dashboard_PAGE()
            };
        }
    }

}