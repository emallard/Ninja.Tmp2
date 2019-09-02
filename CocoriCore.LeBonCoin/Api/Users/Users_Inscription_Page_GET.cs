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


    public class Users_Inscription_PAGEHandler : MessageHandler<Users_Inscription_Page_GET, Users_Inscription_Page>
    {
        public override async Task<Users_Inscription_Page> ExecuteAsync(Users_Inscription_Page_GET query)
        {
            await Task.CompletedTask;
            return new Users_Inscription_Page()
            {
                FormInscription = new PageCall<Users_Inscription_Page_GET, Users_Inscription_POST, Users_Inscription_POSTResponse, Users_Inscription_Page.FormInscriptionResponse>()
                {
                    PageMessage = query,
                    Message = new Users_Inscription_POST(),
                    Translate = (message, response) => new Users_Inscription_Page.FormInscriptionResponse()
                    {
                        Claims = response.Claims,
                        PageDashboard = new Vendeur_Dashboard_Page_GET()
                    },
                    MemberName = "FormInscription"
                }

            };
        }
    }

}