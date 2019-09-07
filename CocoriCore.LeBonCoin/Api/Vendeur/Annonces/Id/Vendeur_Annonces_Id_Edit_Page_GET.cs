using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CocoriCore;

namespace CocoriCore.LeBonCoin
{

    public class Vendeur_Annonces_Id_Edit_Page_GET : IMessage<Vendeur_Annonces_Id_Edit_Page>
    {
        public Guid Id;
    }

    public class Vendeur_Annonces_Id_Edit_Page
    {
        public Call<Categories_GET, string[]> Categories;
        public Call<Villes_GET, string[]> RechercheVilles;
        public AsyncCall<Vendeur_Annonces_Id_Edit_Page_GET, AnnonceModele> Modele;
        public Form<Vendeur_Annonces_Id_Edit_POST, Vendeur_Annonces_Id_GET> Form2;
    }

    public class AnnonceModele
    {
        public Vendeur_Annonces_Id_Edit_GETResponse Data;
        public Vendeur_Annonces_Id_Page_GET LienAnnonce;
    }

    public class PageUI
    {
        // Description du lien entre RechercheVille et Form2.Message.Ville à chaque lettre tapée
        //                           Categories et Form2.Message.Categorie une seule fois pour un Select
    }

    public class Vendeur_Annonces_Id_Edit_PageMapperModule : PageMapperModule
    {
        public Vendeur_Annonces_Id_Edit_PageMapperModule()
        {
            Map<Vendeur_Annonces_Id_Edit_Page_GET, Vendeur_Annonces_Id_Edit_GET>(
                pageQuery => new Vendeur_Annonces_Id_Edit_GET { Id = pageQuery.Id }
            );
            Map<Vendeur_Annonces_Id_Edit_GET, Vendeur_Annonces_Id_Edit_GETResponse, AnnonceModele>(
                (m, r) => new AnnonceModele
                {
                    Data = r,
                    LienAnnonce = new Vendeur_Annonces_Id_Page_GET { Id = m.Id }
                });
            Map<Vendeur_Annonces_Id_Edit_POST, Void, Vendeur_Annonces_Id_Edit_Page_GET>(
                (m, r) => new Vendeur_Annonces_Id_Edit_Page_GET { Id = m.Id }
            );
        }
    }


    public class Vendeur_Annonces_Id_Edit_PageHandler : MessageHandler<Vendeur_Annonces_Id_Edit_Page_GET, Vendeur_Annonces_Id_Edit_Page>
    {
        private readonly IRepository repository;

        public Vendeur_Annonces_Id_Edit_PageHandler(IRepository repository)
        {
            this.repository = repository;
        }

        public override async Task<Vendeur_Annonces_Id_Edit_Page> ExecuteAsync(Vendeur_Annonces_Id_Edit_Page_GET pageQuery)
        {
            await Task.CompletedTask;
            return new Vendeur_Annonces_Id_Edit_Page
            {
                Form2 = new Form<Vendeur_Annonces_Id_Edit_POST, Vendeur_Annonces_Id_GET>()
                {
                    Command = new Vendeur_Annonces_Id_Edit_POST()
                },
                //Modele = new AsyncCall<PageGet, Vendeur_Annonces_Id_Edit_GETResponse>();
                Modele = new AsyncCall<Vendeur_Annonces_Id_Edit_Page_GET, AnnonceModele>()
                {
                    PageQuery = pageQuery
                }
            };
        }
    }
}