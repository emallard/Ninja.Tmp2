using System.Threading.Tasks;
using CocoriCore;

namespace CocoriCore.LeBonCoin
{
    public class Users_Inscription_Page_GET : IPageQuery<Users_Inscription_Page>, IQuery
    {
    }

    public class Users_Inscription_Page
    {
        //public PageCall<Users_Inscription_Page_GET, Users_Inscription_POST, Users_Inscription_POSTResponse, FormInscriptionResponse> Inscription;
        public Users_Connexion_Page_GET Connexion;
        public Form<Users_Inscription_POST, FormInscriptionResponse> SInscrire;

        public class FormInscriptionResponse : IClaimsResponse
        {
            private IClaims claims;
            public Vendeur_Dashboard_Page_GET PageDashboard;

            public FormInscriptionResponse(IClaims claims)
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

    }

    public class Users_Inscription_PageModule : PageModule
    {
        public Users_Inscription_PageModule()
        {
            Map<Users_Inscription_POST, Users_Inscription_POSTResponse, Users_Inscription_Page.FormInscriptionResponse>(
                (m, r) => new Users_Inscription_Page.FormInscriptionResponse(r.Claims)
                {
                    PageDashboard = new Vendeur_Dashboard_Page_GET()
                }
            );

            Handle<Users_Inscription_Page_GET, Users_Inscription_Page>(
                x => new Users_Inscription_Page()
                {
                    Connexion = new Users_Connexion_Page_GET(),
                    SInscrire = new Form<Users_Inscription_POST, Users_Inscription_Page.FormInscriptionResponse>()
                }
            );
        }
    }
    /*
        public class Users_Inscription_PAGEHandler : PageHandler<Users_Inscription_Page_GET, Users_Inscription_Page>
        {
            public override void ExecuteAsync(Users_Inscription_Page_GET query)
            {
                Create(x => x.FormInscription,
                        new Users_Inscription_POST(),
                        reponse => new Users_Inscription_Page.FormInscriptionResponse()
                        {
                            Claims = reponse.Claims,
                            PageDashboard = new Vendeur_Dashboard_Page_GET()
                        });
            }
        }
    */
}