using System;
using System.Linq;
using System.Threading.Tasks;
using CocoriCore;

namespace CocoriCore.LeBonCoin
{

    public class Users_Connexion_Page_FormConnexion_POST : IMessage<Users_Connexion_Page_FormConnexion_POSTResponse>
    {
        public Users_Connexion_POST Post;
    }

    public class Users_Connexion_Page_FormConnexion_POSTResponse
    {
        public IClaims Claims;
        public Vendeur_Dashboard_Page_GET DashboardPage;
    }

    public class Users_Connexion_Page_FormConnexionHandler : MessageHandler<Users_Connexion_Page_FormConnexion_POST, Users_Connexion_Page_FormConnexion_POSTResponse>
    {
        private readonly IExecuteHandler executeHandler;

        public Users_Connexion_Page_FormConnexionHandler(IExecuteHandler executeHandler)
        {
            this.executeHandler = executeHandler;
        }

        public override async Task<Users_Connexion_Page_FormConnexion_POSTResponse> ExecuteAsync(Users_Connexion_Page_FormConnexion_POST message)
        {
            var response = await executeHandler.ExecuteAsync(message.Post);
            return new Users_Connexion_Page_FormConnexion_POSTResponse()
            {
                Claims = response.Claims,
                DashboardPage = new Vendeur_Dashboard_Page_GET()
            };
        }
    }

}