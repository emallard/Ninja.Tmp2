using System;
using System.Threading.Tasks;
using CocoriCore;

namespace CocoriCore.LeBonCoin
{

    public class Users_Inscription_POST : ICommand, IMessage<Users_Inscription_POSTResponse>
    {
        public string Email;
        public string Password;
        public string PasswordConfirmation;
        public string Nom;
        public string Prenom;

    }

    public class Users_Inscription_POSTResponse
    {
        public IClaims Claims;
    }

    public class Users_Inscription_POSTHandler : MessageHandler<Users_Inscription_POST, Users_Inscription_POSTResponse>
    {
        private readonly IRepository repository;

        public Users_Inscription_POSTHandler(IRepository repository)
        {
            this.repository = repository;
        }

        public override async Task<Users_Inscription_POSTResponse> ExecuteAsync(Users_Inscription_POST message)
        {
            var utilisateur = new Utilisateur()
            {
                Id = Guid.NewGuid(),
                Email = message.Email
            };

            var profile = new Profile()
            {
                IdUtilisateur = utilisateur.Id,
                Nom = message.Nom,
                Prenom = message.Prenom
            };

            await repository.InsertAsync(utilisateur);
            await repository.InsertAsync(profile);

            return new Users_Inscription_POSTResponse()
            {
                Claims = new UserClaims() { IdUtilisateur = utilisateur.Id }
            };
        }
    }
}