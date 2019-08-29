using System;
using System.Threading.Tasks;
using CocoriCore;

namespace CocoriCore.LeBonCoin
{

    public class Users_SaisieNouveauMotDePasse_Token_Page_GET : IPage<Users_SaisieNouveauMotDePasse_Token_Page>
    {
        public Guid Token;
    }

    public class Users_SaisieNouveauMotDePasse_Token_Page
    {
        public Form<Users_SaisieNouveauMotDePasse_Token_Page_Form_POST, Users_SaisieNouveauMotDePasse_Token_Page_Form_POSTResponse> Form = new Form<Users_SaisieNouveauMotDePasse_Token_Page_Form_POST, Users_SaisieNouveauMotDePasse_Token_Page_Form_POSTResponse>();
    }

    public class Users_SaisieNouveauMotDePasse_Token_PAGEHandler : MessageHandler<Users_SaisieNouveauMotDePasse_Token_Page_GET, Users_SaisieNouveauMotDePasse_Token_Page>
    {
        private readonly IRepository repository;
        private readonly IHashService hashService;

        public Users_SaisieNouveauMotDePasse_Token_PAGEHandler(IRepository repository, IHashService hashService)
        {
            this.repository = repository;
            this.hashService = hashService;
        }

        public async override Task<Users_SaisieNouveauMotDePasse_Token_Page> ExecuteAsync(Users_SaisieNouveauMotDePasse_Token_Page_GET message)
        {
            var token = await repository.LoadAsync<TokenMotDePasseOublie>(message.Token);
            if (token == null)
                throw new Exception("token invalide");
            return new Users_SaisieNouveauMotDePasse_Token_Page()
            {
            };
        }
    }

}