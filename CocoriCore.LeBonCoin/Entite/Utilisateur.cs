using System;
using System.Threading.Tasks;
using CocoriCore;

namespace CocoriCore.LeBonCoin
{

    public class Utilisateur : IMyEntity<Utilisateur>
    {
        public Guid Id { get; set; }
        public TypedId<Utilisateur> TId { get; set; }

        public string Email { get; set; }
        public string HashMotDePasse { get; set; }


    }
}