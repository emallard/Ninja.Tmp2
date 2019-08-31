using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CocoriCore;

namespace CocoriCore.LeBonCoin
{

    public class Vendeur_Annonces_Id_Edit_Page
    {
        public class PageGet : IMessage<Page>
        {
            public Guid Id;
        }

        public class Page
        {
            public Form5<Vendeur_Annonces_Id_Edit_GET, Vendeur_Annonces_Id_Edit, AnnonceData> Data;
            public Form5<Vendeur_Annonces_Id_Edit_POST, Void, AnnoncePostResponse> Form;
            public Form<Categories_GET, Categories> GetCategories;
            public Form<Villes_GET, Villes> GetVilles;
        }

        public class PageHandler : MessageHandler<PageGet, Page>
        {
            public override Task<Page> ExecuteAsync(PageGet pageGet)
            {
                return new Task<Page>(() => new Page()
                {
                    Data = new Form5<Vendeur_Annonces_Id_Edit_GET, Vendeur_Annonces_Id_Edit, AnnonceData>()
                    {
                        Message = new Vendeur_Annonces_Id_Edit_GET() { Id = pageGet.Id },
                        Translate = (message, reponse) =>
                        {
                            return new AnnonceData()
                            {
                                Data = reponse,
                                LienAnnonce = new Vendeur_Annonces_Id_GET { Id = reponse.Id }
                            };
                        }
                    },
                    Form = new Form5<Vendeur_Annonces_Id_Edit_POST, Void, AnnoncePostResponse>()
                    {
                        Message = new Vendeur_Annonces_Id_Edit_POST() { Id = pageGet.Id },
                        Translate = (message, reponse) =>
                            new AnnoncePostResponse()
                            {
                                LienAnnonce = new Vendeur_Annonces_Id_GET { Id = message.Id }
                            }
                    }
                });
            }
        }

        public class AnnonceData
        {
            public Vendeur_Annonces_Id_Edit Data;
            public Vendeur_Annonces_Id_GET LienAnnonce;
        }

        public class AnnoncePostResponse
        {
            public Vendeur_Annonces_Id_GET LienAnnonce;
        }
    }
}