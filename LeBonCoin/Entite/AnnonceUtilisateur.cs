using System;
using System.Threading.Tasks;
using CocoriCore;

namespace LeBonCoin
{
    // Idée pour qu'on ne mette plus IdUtilisateur dans Annonce et qu'ainsi on puisse balancer
    // l'entite telle quelle en message et en réponse
    public class AnnonceUtilisateur : IEntity
    {
        public Guid Id { get; set; }
        public Guid IdAnnonce { get; set; }
        public Guid IdUtilisateur { get; set; }
    }
}