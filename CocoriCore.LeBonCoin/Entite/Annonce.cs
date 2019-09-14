using System;
using System.Threading.Tasks;
using CocoriCore;

namespace CocoriCore.LeBonCoin
{


    public class Annonce : IMyEntity<Annonce>
    {
        public Guid Id { get; set; }
        public TypedId<Annonce> TId { get; set; }
        public TypedId<Utilisateur> IdUtilisateur { get; set; }
        public string Texte { get; set; }
        public string Categorie { get; set; }
        public string Ville { get; set; }
    }
}