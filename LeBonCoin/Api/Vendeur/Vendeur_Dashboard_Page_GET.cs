﻿using System;
using System.Threading.Tasks;
using CocoriCore;

namespace LeBonCoin
{
    public class Vendeur_Dashboard_Page_GET : IPageQuery<Vendeur_Dashboard_Page>
    {
    }

    public class Vendeur_Dashboard_Page
    {
        public Vendeur_NouvelleAnnonce_Page_GET NouvelleAnnonce;
        public Vendeur_Annonces_Page_GET MesAnnonces;
        public MenuVendeur MenuVendeur;
        public AsyncCall<Vendeur_Dashboard_Page_GET, Vendeur_Dashboard> Modele;
    }

    public class Vendeur_Annonces_PageModule : PageModule
    {
        public Vendeur_Annonces_PageModule()
        {
            Handle<Vendeur_Dashboard_Page_GET, Vendeur_Dashboard_Page>(x => new Vendeur_Dashboard_Page()
            {
                Modele = new AsyncCall<Vendeur_Dashboard_Page_GET, Vendeur_Dashboard>() { PageQuery = x },
                NouvelleAnnonce = new Vendeur_NouvelleAnnonce_Page_GET(),
                MesAnnonces = new Vendeur_Annonces_Page_GET(),
                MenuVendeur = new MenuVendeur()
            });

            Map<Vendeur_Dashboard_Page_GET, Vendeur_Dashboard_GET>(x => new Vendeur_Dashboard_GET());
            Map<Vendeur_Dashboard_GET, Vendeur_Dashboard, Vendeur_Dashboard>(
                (m, r) => r
            );
        }
    }
}