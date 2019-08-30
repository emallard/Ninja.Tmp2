using System;

namespace CocoriCore.LeBonCoin
{
    public class Inscription : IEntity
    {
        public Guid Id { get; set; }
        public Guid IdAnnonce { get; set; }
        public Guid IdUtilisateur { get; set; }
        public Guid IdProfile { get; set; }
        public bool Annulee { get; set; }
        public bool Acceptee { get; set; }
        public bool Refusee { get; set; }
    }
}