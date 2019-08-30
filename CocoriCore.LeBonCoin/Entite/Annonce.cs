using System;
using System.Threading.Tasks;
using CocoriCore;

namespace CocoriCore.LeBonCoin
{


    public class Annonce : IEntity
    {
        public Guid Id { get; set; }
        public Guid IdUtilisateur { get; set; }
        public string Texte { get; set; }
        public string Categorie { get; set; }
        public string Ville { get; set; }
    }
}