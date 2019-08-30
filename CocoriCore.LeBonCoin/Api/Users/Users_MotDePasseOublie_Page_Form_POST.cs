using System;
using System.Threading.Tasks;
using CocoriCore;

namespace CocoriCore.LeBonCoin
{
    public class Users_MotDePasseOublie_Page_Form_POST : IMessage<Users_MotDePasseOublie_Page_Form_POSTResponse>
    {
        public Users_MotDePasseOublie_POST Post;
    }

    public class Users_MotDePasseOublie_Page_Form_POSTResponse
    {
        public Users_MotDePasseOublie_Confirmation_Page_GET MotDePasseOublie_Confirmation;
    }

    public class Users_MotDePasseOublie_Page_Form_POSTHandler : MessageHandler<Users_MotDePasseOublie_Page_Form_POST, Users_MotDePasseOublie_Page_Form_POSTResponse>
    {
        private readonly IExecuteHandler executeHandler;

        public Users_MotDePasseOublie_Page_Form_POSTHandler(IExecuteHandler executeHandler)
        {
            this.executeHandler = executeHandler;
        }

        public override async Task<Users_MotDePasseOublie_Page_Form_POSTResponse> ExecuteAsync(Users_MotDePasseOublie_Page_Form_POST message)
        {
            var reponse = await executeHandler.ExecuteAsync(message.Post);
            return new Users_MotDePasseOublie_Page_Form_POSTResponse()
            {
                MotDePasseOublie_Confirmation = new Users_MotDePasseOublie_Confirmation_Page_GET()
            };
        }
    }

}