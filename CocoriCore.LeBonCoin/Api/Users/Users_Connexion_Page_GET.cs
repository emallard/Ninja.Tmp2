using System;
using System.Linq;
using System.Threading.Tasks;
using CocoriCore;

namespace CocoriCore.LeBonCoin
{

    public class Users_Connexion_Page_GET : IPageQuery<Users_Connexion_Page>, IQuery
    {

    }

    public class Users_Connexion_Page
    {
        public Users_Inscription_Page_GET Inscription;
        public Users_MotDePasseOublie_Page_GET MotDePasseOublie;
        //public PageCall<Users_Connexion_Page_GET, Users_Connexion_POST, Users_Connexion_POSTResponse, Users_Connexion_Page_FormConnexion_POSTResponse> Form;
        public Form<Users_Connexion_POST, Users_Connexion_Page_SeConnecter_Reponse> SeConnecter;
    }

    public class Users_Connexion_Page_SeConnecter_Reponse : IClaimsResponse
    {

        private IClaims claims;
        public Vendeur_Dashboard_Page_GET PageDashboard;
        public Users_Connexion_Page_SeConnecter_Reponse(IClaims claims)
        {
            this.claims = claims;
        }

        public IClaims GetClaims()
        {
            return claims;
        }

        public object GetResponse()
        {
            return PageDashboard;
        }
    }

    public class Users_Connexion_PageModule : PageModule
    {
        public Users_Connexion_PageModule()
        {
            Map<Users_Connexion_POST, Users_Connexion_POSTResponse, Users_Connexion_Page_SeConnecter_Reponse>(
                (m, r) => new Users_Connexion_Page_SeConnecter_Reponse(r.Claims)
                {
                    PageDashboard = new Vendeur_Dashboard_Page_GET()
                }
            );
            Handle<Users_Connexion_Page_GET, Users_Connexion_Page>(x => new Users_Connexion_Page()
            {
                Inscription = new Users_Inscription_Page_GET(),
                MotDePasseOublie = new Users_MotDePasseOublie_Page_GET(),
                SeConnecter = new Form<Users_Connexion_POST, Users_Connexion_Page_SeConnecter_Reponse>()
            });
        }
    }



    /*
        public class Users_Connexion_PageHandler : PageHandler<Users_Connexion_Page_GET, Users_Connexion_Page>
        {
            public Users_Connexion_PageHandler()
            {
            }

            public override void ExecuteAsync(Users_Connexion_Page_GET query)
            {
                Create(x => x.Form,
                        new Users_Connexion_POST(),
                        reponse => new Users_Connexion_Page_FormConnexion_POSTResponse()
                        {
                            Claims = reponse.Claims,
                            PageDashboard = new Vendeur_Dashboard_Page_GET()
                        });
            }

        }
    */

}