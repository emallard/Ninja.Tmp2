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
        public PageCall<Users_Connexion_Page_GET, Users_Connexion_POST, Users_Connexion_POSTResponse, Users_Connexion_Page_FormConnexion_POSTResponse> Form;
    }

    public class Users_Connexion_Page_FormConnexion_POSTResponse
    {
        public IClaims Claims;
        public Vendeur_Dashboard_Page_GET PageDashboard;
    }

    public class Users_Connexion_PageHandler : MessageHandler<Users_Connexion_Page_GET, Users_Connexion_Page>
    {
        public Users_Connexion_PageHandler()
        {
        }

        public override async Task<Users_Connexion_Page> ExecuteAsync(Users_Connexion_Page_GET query)
        {
            await Task.CompletedTask;
            return new Users_Connexion_Page()
            {
                Form = new PageCall<Users_Connexion_Page_GET, Users_Connexion_POST, Users_Connexion_POSTResponse, Users_Connexion_Page_FormConnexion_POSTResponse>
                {
                    PageMessage = query,
                    Message = new Users_Connexion_POST(),
                    Translate = (message, reponse) => new Users_Connexion_Page_FormConnexion_POSTResponse()
                    {
                        Claims = reponse.Claims,
                        PageDashboard = new Vendeur_Dashboard_Page_GET()
                    }
                }
            };
        }

    }



}