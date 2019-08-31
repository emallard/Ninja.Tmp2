using System;
using System.Threading.Tasks;
using CocoriCore;

namespace CocoriCore.LeBonCoin
{
    public class Vendeur_Dashboard_GET : IPage<Vendeur_Dashboard>, IQuery
    {
    }

    public class Vendeur_Dashboard
    {
        public string Nom;
        public string Prenom;
    }

    public class Vendeur_Dashboard_GETHandler : MessageHandler<Vendeur_Dashboard_GET, Vendeur_Dashboard>
    {
        private readonly IClaimsProvider claimsProvider;
        private readonly IRepository repository;

        public Vendeur_Dashboard_GETHandler(IClaimsProvider claimsProvider, IRepository repository)
        {
            this.claimsProvider = claimsProvider;
            this.repository = repository;
        }

        public override async Task<Vendeur_Dashboard> ExecuteAsync(Vendeur_Dashboard_GET query)
        {
            var idUtilisateur = claimsProvider.GetClaims<UserClaims>().IdUtilisateur;
            var profile = await repository.LoadAsync<Profile>(x => x.IdUtilisateur, idUtilisateur);

            return new Vendeur_Dashboard()
            {
                Nom = profile.Nom,
                Prenom = profile.Prenom
            };
        }
    }
}