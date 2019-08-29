using System;
using System.Threading.Tasks;
using CocoriCore;

namespace CocoriCore.LeBonCoin
{

    public class Utilisateur : IEntity
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string HashMotDePasse { get; set; }
    }

    public class Profile : IEntity
    {
        public Guid Id { get; set; }
        public Guid IdUtilisateur { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
    }
}