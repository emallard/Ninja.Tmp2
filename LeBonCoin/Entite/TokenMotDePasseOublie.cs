using System;
using CocoriCore;

namespace LeBonCoin
{
    public class TokenMotDePasseOublie : IEntity
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
    }
}