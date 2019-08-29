using System;

namespace CocoriCore.LeBonCoin
{
    public class UserClaims : IClaims
    {
        public Guid IdUtilisateur;

        public DateTime ExpireAt => new DateTime(3000, 1, 1);
    }
}