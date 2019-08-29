using System;
using System.Threading.Tasks;
using CocoriCore;

namespace CocoriCore.LeBonCoin
{
    public class Users_MotDePasseOublie_Page_GET : IPage<Users_MotDePasseOublie_Page>
    {

    }

    public class Users_MotDePasseOublie_Page
    {
        public Form<Users_MotDePasseOublie_Page_Form_POST, Users_MotDePasseOublie_Page_Form_POSTResponse> Form = new Form<Users_MotDePasseOublie_Page_Form_POST, Users_MotDePasseOublie_Page_Form_POSTResponse>();
    }

    public class Users_MotDePasseOublie_PAGEHandler : MessageHandler<Users_MotDePasseOublie_Page_GET, Users_MotDePasseOublie_Page>
    {
        public override async Task<Users_MotDePasseOublie_Page> ExecuteAsync(Users_MotDePasseOublie_Page_GET query)
        {
            await Task.CompletedTask;
            return new Users_MotDePasseOublie_Page();
        }
    }

}