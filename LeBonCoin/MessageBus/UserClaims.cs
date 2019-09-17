using System;
using CocoriCore;

namespace LeBonCoin
{
    public class UserClaims : IClaims
    {
        public TypedId<Utilisateur> IdUtilisateur;

        public DateTime ExpireAt => new DateTime(3000, 1, 1);
    }
}