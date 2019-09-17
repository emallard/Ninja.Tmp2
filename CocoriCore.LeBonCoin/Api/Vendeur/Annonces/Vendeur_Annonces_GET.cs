

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CocoriCore;
using CocoriCore.Linq.Async;

namespace CocoriCore.LeBonCoin
{


    public class Vendeur_Annonces_GET : IPageQuery<Vendeur_AnnoncesItem[]>
    {
    }



    public class Vendeur_AnnoncesItem
    {
        public Guid Id;
        public string Texte { get; set; }
        public string Categorie { get; set; }
        public string Ville { get; set; }
        public string PrenomVendeur { get; set; }
    }

    public class Vendeur_Annonces_GETHandler : MessageHandler<Vendeur_Annonces_GET, Vendeur_AnnoncesItem[]>
    {
        private readonly IRepository repository;
        private readonly IClaimsProvider claimsProvider;

        public Vendeur_Annonces_GETHandler(IRepository repository, IClaimsProvider claimsProvider)
        {
            this.repository = repository;
            this.claimsProvider = claimsProvider;
        }

        public override async Task<Vendeur_AnnoncesItem[]> ExecuteAsync(Vendeur_Annonces_GET message)
        {
            var idUtilisateur = claimsProvider.GetClaims<UserClaims>().IdUtilisateur;
            var profile = await repository.LoadAsync<Profile>(x => x.IdUtilisateur, idUtilisateur);
            var annonces = await repository.Query<Annonce>().Where(x => x.IdUtilisateur == idUtilisateur).ToArrayAsync();
            return annonces.Select(x =>
                new Vendeur_AnnoncesItem()
                {
                    Id = x.Id,
                    Texte = x.Texte,
                    Categorie = x.Categorie,
                    Ville = x.Ville,
                    PrenomVendeur = profile.Prenom
                }).ToArray();
        }
    }

}