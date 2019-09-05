using System.Threading.Tasks;
using CocoriCore;

namespace CocoriCore.LeBonCoin
{
    public class Users_Inscription_Page_GET : IPage<Users_Inscription_Page>, IQuery
    {
    }

    public class Users_Inscription_Page
    {
        public PageCall<Users_Inscription_Page_GET, Users_Inscription_POST, Users_Inscription_POSTResponse, FormInscriptionResponse> FormInscription;

        public class FormInscriptionResponse
        {
            public IClaims Claims;
            public Vendeur_Dashboard_Page_GET PageDashboard;
        }

    }


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

}