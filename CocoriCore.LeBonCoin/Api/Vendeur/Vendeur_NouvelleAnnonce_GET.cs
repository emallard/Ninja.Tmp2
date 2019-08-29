using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CocoriCore;

namespace CocoriCore.LeBonCoin
{
    public class Vendeur_NouvelleAnnonce_GET : IPage<Vendeur_NouvelleAnnonce_GETResponse>
    {
    }

    public class Vendeur_NouvelleAnnonce_GETResponse
    {
        public string[] Categories;
    }

    public class Vendeur_NouvelleAnnonce_GETHandler : MessageHandler<Vendeur_NouvelleAnnonce_GET, Vendeur_NouvelleAnnonce_GETResponse>
    {
        public override async Task<Vendeur_NouvelleAnnonce_GETResponse> ExecuteAsync(Vendeur_NouvelleAnnonce_GET query)
        {
            await Task.CompletedTask;
            return new Vendeur_NouvelleAnnonce_GETResponse()
            {
                Categories = new string[] { "A", "B", "C" }
            };
        }
    }
}