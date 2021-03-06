using System;
using System.Threading.Tasks;
using CocoriCore;

namespace LeBonCoin
{
    public class Users_MotDePasseOublie_Page_GET : IPageQuery<Users_MotDePasseOublie_Page>
    {

    }

    public class Users_MotDePasseOublie_Page
    {
        public Form<Users_MotDePasseOublie_POST, Users_MotDePasseOublie_Confirmation_Page_GET> RecevoirEmail;
    }

    public class Users_MotDePasseOublie_PageModule : PageModule
    {
        public Users_MotDePasseOublie_PageModule()
        {
            Map<Users_MotDePasseOublie_POST, Void, Users_MotDePasseOublie_Confirmation_Page_GET>(
                (m, r) => new Users_MotDePasseOublie_Confirmation_Page_GET()
            );
            Handle<Users_MotDePasseOublie_Page_GET, Users_MotDePasseOublie_Page>(x => new Users_MotDePasseOublie_Page()
            {
                RecevoirEmail = new Form<Users_MotDePasseOublie_POST, Users_MotDePasseOublie_Confirmation_Page_GET>()
            });
        }
    }

    /*  
    public class Users_MotDePasseOublie_PAGEHandler : MessageHandler<Users_MotDePasseOublie_Page_GET, Users_MotDePasseOublie_Page>
    {
        public override async Task<Users_MotDePasseOublie_Page> ExecuteAsync(Users_MotDePasseOublie_Page_GET query)
        {
            await Task.CompletedTask;
            return new Users_MotDePasseOublie_Page()
            {
                Form = new PageCall<Users_MotDePasseOublie_Page_GET, Users_MotDePasseOublie_POST, Void, Users_MotDePasseOublie_Confirmation_Page_GET>()
                {
                    PageMessage = query,
                    Message = new Users_MotDePasseOublie_POST(),
                    Translate = (m, r) => new Users_MotDePasseOublie_Confirmation_Page_GET(),
                    MemberName = "Form"
                }
            };
        }
    }
    */
}