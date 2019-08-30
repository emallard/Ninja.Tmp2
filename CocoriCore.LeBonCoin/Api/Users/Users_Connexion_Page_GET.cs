using System;
using System.Linq;
using System.Threading.Tasks;
using CocoriCore;

namespace CocoriCore.LeBonCoin
{

    public class Users_Connexion_Page_GET : IPage<Users_Connexion_Page>, IQuery
    {

    }

    public class Users_Connexion_Page
    {
        public Users_MotDePasseOublie_Page_GET MotDePasseOublie = new Users_MotDePasseOublie_Page_GET();
        public Form<Users_Connexion_Page_FormConnexion_POST, Users_Connexion_Page_FormConnexion_POSTResponse> Form;
    }

    public class Users_Connexion_PageHandler : MessageHandler<Users_Connexion_Page_GET, Users_Connexion_Page>
    {
        public Users_Connexion_PageHandler()
        {
        }

        public override async Task<Users_Connexion_Page> ExecuteAsync(Users_Connexion_Page_GET query)
        {
            await Task.CompletedTask;
            var response = new Users_Connexion_Page();
            return response;
        }

    }



}