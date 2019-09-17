

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CocoriCore;

namespace CocoriCore.LeBonCoin
{


    public class Vendeur_Annonces_Page_GET : IPageQuery<Vendeur_Annonces_Page>
    {
    }


    public class Vendeur_Annonces_Page
    {
        public Vendeur_Annonces_PageItem[] Annonces;
        /*
        public PageCall<Vendeur_Annonces_Page_GET, Vendeur_Annonces_GET, Vendeur_AnnoncesItem[], Vendeur_Annonces_PageItem[]> Annonces;
        public PageCall2<Vendeur_Annonces_GET, Vendeur_Annonces_PageItem[]> Annonces2;
        public AsyncCall<Vendeur_Annonces_GET, Vendeur_Annonces_PageItem[]> Annonces3;
        */
        public Vendeur_NouvelleAnnonce_Page_GET NouvelleReunion = new Vendeur_NouvelleAnnonce_Page_GET();
    }

    public class Vendeur_Annonces_PageItem
    {
        public Vendeur_AnnoncesItem Data;
        public Vendeur_Annonces_Id_Page_GET Lien;
    }

    public class Vendeur_Annonces_Page_GETHandler : MessageHandler<Vendeur_Annonces_Page_GET, Vendeur_Annonces_Page>
    {
        private readonly IExecuteHandler executeHandler;

        public Vendeur_Annonces_Page_GETHandler(IExecuteHandler executeHandler)
        {
            this.executeHandler = executeHandler;
        }

        public override async Task<Vendeur_Annonces_Page> ExecuteAsync(Vendeur_Annonces_Page_GET message)
        {
            var annonces = await executeHandler.ExecuteAsync(new Vendeur_Annonces_GET());

            var page = new Vendeur_Annonces_Page();

            page.Annonces = annonces.Select(x => new Vendeur_Annonces_PageItem()
            {
                Data = x,
                Lien = new Vendeur_Annonces_Id_Page_GET() { Id = x.Id }
            }).ToArray();

            return page;
        }
    }

}