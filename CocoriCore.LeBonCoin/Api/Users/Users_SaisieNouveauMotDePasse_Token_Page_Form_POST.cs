using System;
using System.Threading.Tasks;

namespace CocoriCore.LeBonCoin
{

    public class Users_SaisieNouveauMotDePasse_Token_Page_Form_POST : IMessage<Users_SaisieNouveauMotDePasse_Token_Page_Form_POSTResponse>
    {
        public Users_SaisieNouveauMotDePasse_Token_POST Post;
    }

    public class Users_SaisieNouveauMotDePasse_Token_Page_Form_POSTResponse
    {
        public Users_Connexion_Page_GET PageConnexion = new Users_Connexion_Page_GET();
    }

    public class Users_SaisieNouveauMotDePasse_Token_Page_Form_POSTHandler : MessageHandler<Users_SaisieNouveauMotDePasse_Token_Page_Form_POST, Users_SaisieNouveauMotDePasse_Token_Page_Form_POSTResponse>
    {
        private readonly IExecuteHandler executeHandler;

        public Users_SaisieNouveauMotDePasse_Token_Page_Form_POSTHandler(IExecuteHandler executeHandler)
        {
            this.executeHandler = executeHandler;
        }

        public override async Task<Users_SaisieNouveauMotDePasse_Token_Page_Form_POSTResponse> ExecuteAsync(Users_SaisieNouveauMotDePasse_Token_Page_Form_POST message)
        {
            var reponse = await executeHandler.ExecuteAsync(message.Post);
            return new Users_SaisieNouveauMotDePasse_Token_Page_Form_POSTResponse();
        }
    }
}