using System;
using CocoriCore;

namespace LeBonCoin
{
    public class Profile : IMyEntity<Profile>
    {
        public Guid Id { get; set; }
        public TypedId<Profile> TId { get; set; }
        public TypedId<Utilisateur> IdUtilisateur { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
    }
}