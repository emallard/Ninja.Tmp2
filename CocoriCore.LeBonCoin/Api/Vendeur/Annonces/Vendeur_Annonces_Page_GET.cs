

using System;
using System.Collections.Generic;
using CocoriCore;

namespace CocoriCore.LeBonCoin
{


    public class Vendeur_Annonces_Page_GET : IPage<Vendeur_Annonces_Page>
    {
    }


    public class Vendeur_Annonces_PageItem
    {
        public Guid Id;

        public Vendeur_Annonces_Id_Page_GET Lien = new Vendeur_Annonces_Id_Page_GET();
    }

    public class Vendeur_Annonces_Page
    {
        public Vendeur_Annonces_PageItem[] Annonces;
        public Vendeur_NouvelleAnnonce_Page_GET NouvelleReunion = new Vendeur_NouvelleAnnonce_Page_GET();
    }

}