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
        public Vendeur_Dashboard_PAGE Vendeur_Dashboard;
    }

    public class Users_Inscription_Page_FormInscription_POSTHandler : MessageHandler<Users_Inscription_Page_FormInscription_POST, Users_Inscription_Page_FormInscription_POSTResponse>
    {
        public override async Task<Users_Inscription_Page_FormInscription_POSTResponse> ExecuteAsync(Users_Inscription_Page_FormInscription_POST message)
        {
            await Task.CompletedTask;
            return new Users_Inscription_Page_FormInscription_POSTResponse();
        }
    }

}