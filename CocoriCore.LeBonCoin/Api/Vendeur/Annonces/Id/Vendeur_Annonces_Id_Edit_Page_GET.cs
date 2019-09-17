using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CocoriCore;

namespace CocoriCore.LeBonCoin
{

    public class Vendeur_Annonces_Id_Edit_Page_GET : IPageQuery<Vendeur_Annonces_Id_Edit_Page>
    {
        public Guid Id;
    }

    public class Vendeur_Annonces_Id_Edit_Page
    {
        public Call<Categories_GET, string[]> Categories;
        public Call<Villes_GET, string[]> RechercheVilles;
        public AsyncCall<Vendeur_Annonces_Id_Edit_Page_GET, AnnonceModele> Modele;
        public Form<Vendeur_Annonces_Id_Edit_POST, Vendeur_Annonces_Id_Page_GET> Enregistrer;
        public Vendeur_Annonces_Id_Page_GET Annuler;
    }

    public class AnnonceModele
    {
        public Vendeur_Annonces_Id_Edit_GETResponse Data;

    }

    public class PageUI
    {
        // Description du lien entre RechercheVille et Form2.Message.Ville à chaque lettre tapée
        //                           Categories et Form2.Message.Categorie une seule fois pour un Select
    }

    public class Vendeur_Annonces_Id_Edit_PageModule : PageModule
    {
        public Vendeur_Annonces_Id_Edit_PageModule()
        {
            Map<Vendeur_Annonces_Id_Edit_Page_GET, Vendeur_Annonces_Id_Edit_GET>(
                pageQuery => new Vendeur_Annonces_Id_Edit_GET { Id = pageQuery.Id }
            );
            Map<Vendeur_Annonces_Id_Edit_GET, Vendeur_Annonces_Id_Edit_GETResponse, AnnonceModele>(
                (m, r) => new AnnonceModele
                {
                    Data = r
                });
            Map<Vendeur_Annonces_Id_Edit_POST, Void, Vendeur_Annonces_Id_Edit_Page_GET>(
                (m, r) => new Vendeur_Annonces_Id_Edit_Page_GET { Id = m.Id }
            );

            Handle<Vendeur_Annonces_Id_Edit_Page_GET, Vendeur_Annonces_Id_Edit_Page>(
                pageQuery => new Vendeur_Annonces_Id_Edit_Page
                {
                    Enregistrer = new Form<Vendeur_Annonces_Id_Edit_POST, Vendeur_Annonces_Id_Page_GET>()
                    {
                        Command = new Vendeur_Annonces_Id_Edit_POST()
                    },
                    Annuler = new Vendeur_Annonces_Id_Page_GET { Id = pageQuery.Id },
                    Modele = new AsyncCall<Vendeur_Annonces_Id_Edit_Page_GET, AnnonceModele>()
                    {
                        PageQuery = pageQuery
                    }
                }
            );
        }
    }
}