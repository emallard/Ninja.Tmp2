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
        public Form5<Users_MotDePasseOublie_POST, Void, Users_MotDePasseOublie_Confirmation_Page_GET> Form;


    }

    public class Users_MotDePasseOublie_PAGEHandler : MessageHandler<Users_MotDePasseOublie_Page_GET, Users_MotDePasseOublie_Page>
    {
        public override async Task<Users_MotDePasseOublie_Page> ExecuteAsync(Users_MotDePasseOublie_Page_GET query)
        {
            await Task.CompletedTask;
            return new Users_MotDePasseOublie_Page()
            {
                Form = new Form5<Users_MotDePasseOublie_POST, Void, Users_MotDePasseOublie_Confirmation_Page_GET>()
                {
                    Message = new Users_MotDePasseOublie_POST(),
                    Translate = (m, r) => new Users_MotDePasseOublie_Confirmation_Page_GET()
                }
            };
        }
    }
}