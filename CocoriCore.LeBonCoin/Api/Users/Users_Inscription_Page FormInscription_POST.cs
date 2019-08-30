using System.Threading.Tasks;
using CocoriCore;

namespace CocoriCore.LeBonCoin
{
    public class Users_Inscription_Page_FormInscription_POST : IMessage<Users_Inscription_Page_FormInscription_POSTResponse>
    {
        public Users_Inscription_POST Post;
    }

    public class Users_Inscription_Page_FormInscription_POSTResponse
    {
        public IClaims Claims;
        public Vendeur_Dashboard_Page_GET LienVendeur_Dashboard;
    }

    public class Users_Inscription_Page_FormInscription_POSTHandler : MessageHandler<Users_Inscription_Page_FormInscription_POST, Users_Inscription_Page_FormInscription_POSTResponse>
    {
        private readonly IExecuteHandler executeHandler;

        public Users_Inscription_Page_FormInscription_POSTHandler(IExecuteHandler executeHandler)
        {
            this.executeHandler = executeHandler;
        }

        public override async Task<Users_Inscription_Page_FormInscription_POSTResponse> ExecuteAsync(Users_Inscription_Page_FormInscription_POST message)
        {
            var response = await executeHandler.ExecuteAsync(message.Post);
            return new Users_Inscription_Page_FormInscription_POSTResponse()
            {
                Claims = response.Claims,
                LienVendeur_Dashboard = new Vendeur_Dashboard_Page_GET()
            };
        }
    }
}