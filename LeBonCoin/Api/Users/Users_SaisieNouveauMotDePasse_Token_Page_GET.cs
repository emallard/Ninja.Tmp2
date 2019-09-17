using System;
using System.Threading.Tasks;
using CocoriCore;

namespace LeBonCoin
{

    public class Users_SaisieNouveauMotDePasse_Token_Page_GET : IPageQuery<Users_SaisieNouveauMotDePasse_Token_Page>
    {
        public Guid Token;
    }

    public class Users_SaisieNouveauMotDePasse_Token_Page
    {
        public bool TokenExpire;
        public bool TokenDejaUtilise;
        public Form<Users_SaisieNouveauMotDePasse_Token_POST, Users_Connexion_Page_GET> ChangerMotDePasse;
    }

    public class Users_SaisieNouveauMotDePasse_Token_PageModule : PageModule
    {
        public Users_SaisieNouveauMotDePasse_Token_PageModule()
        {
            Map<Users_SaisieNouveauMotDePasse_Token_POST, Void, Users_Connexion_Page_GET>(
                (m, r) => new Users_Connexion_Page_GET()
            );
        }
    }

    public class Users_SaisieNouveauMotDePasse_Token_PAGEHandler : MessageHandler<Users_SaisieNouveauMotDePasse_Token_Page_GET, Users_SaisieNouveauMotDePasse_Token_Page>
    {
        private readonly IRepository repository;
        private readonly IClock clock;

        public Users_SaisieNouveauMotDePasse_Token_PAGEHandler(
            IRepository repository,
            IClock clock)
        {
            this.repository = repository;
            this.clock = clock;
        }

        public async override Task<Users_SaisieNouveauMotDePasse_Token_Page> ExecuteAsync(Users_SaisieNouveauMotDePasse_Token_Page_GET message)
        {
            var token = await repository.LoadAsync<TokenMotDePasseOublie>(message.Token);
            if (token == null)
                throw new Exception("token invalide");

            return new Users_SaisieNouveauMotDePasse_Token_Page()
            {
                TokenDejaUtilise = token.Utilise,
                TokenExpire = token.DateExpiration < clock.Now,
                ChangerMotDePasse = new Form<Users_SaisieNouveauMotDePasse_Token_POST, Users_Connexion_Page_GET>()
            };
        }
    }
}