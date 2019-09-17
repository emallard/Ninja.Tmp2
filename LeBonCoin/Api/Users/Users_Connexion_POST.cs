using System;
using System.Linq;
using System.Threading.Tasks;
using CocoriCore;
using CocoriCore.Linq.Async;

namespace LeBonCoin
{

    public class Users_Connexion_POST : ICommand, IMessage<Users_Connexion_POSTResponse>
    {
        public string Email;
        public string Password;
    }

    public class Users_Connexion_POSTResponse
    {
        public IClaims Claims;
    }


    public class Users_Connexion_POSTHandler : MessageHandler<Users_Connexion_POST, Users_Connexion_POSTResponse>
    {
        private readonly IRepository repository;
        private readonly IHashService hashService;

        public Users_Connexion_POSTHandler(IRepository repository, IHashService hashService)
        {
            this.repository = repository;
            this.hashService = hashService;
        }

        public override async Task<Users_Connexion_POSTResponse> ExecuteAsync(Users_Connexion_POST message)
        {
            var utilisateur = await repository
                .Query<Utilisateur>()
                .Where(x => x.Email == message.Email)
                .FirstOrDefaultAsync();

            if (utilisateur == null)
                throw new Exception("Validation Exception no corresponding user");

            if (!await hashService.PasswordMatchHashAsync(message.Password, utilisateur.HashMotDePasse))
                throw new Exception("Validation Exception no corresponding user");

            return new Users_Connexion_POSTResponse()
            {
                Claims = new UserClaims() { IdUtilisateur = utilisateur.TId }
            };
        }
    }
}
