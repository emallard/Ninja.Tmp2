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
            public PageCall<PageGet, Vendeur_Annonces_Id_Edit_GET, Vendeur_Annonces_Id_Edit, AnnonceData> Data;
            public PageCall<PageGet, Vendeur_Annonces_Id_Edit_POST, Void, AnnoncePostResponse> Form;
            public Call<Categories_GET, string[]> Categories;
            public Call<Villes_GET, string[]> RechercheVilles;
        }

        public class Handler : MessageHandler<PageGet, Page>
        {
            public override Task<Page> ExecuteAsync(PageGet pageGet)
            {
                return new Task<Page>(() => new Page()
                {
                    Data = new PageCall<PageGet, Vendeur_Annonces_Id_Edit_GET, Vendeur_Annonces_Id_Edit, AnnonceData>()
                    {
                        PageMessage = pageGet,
                        Message = new Vendeur_Annonces_Id_Edit_GET() { Id = pageGet.Id },
                        Translate = (message, reponse) =>
                        {
                            return new AnnonceData()
                            {
                                Data = reponse,
                                LienAnnonce = new Vendeur_Annonces_Id_GET { Id = reponse.Id }
                            };
                        },
                        MemberName = "Data"
                    },
                    Form = new PageCall<PageGet, Vendeur_Annonces_Id_Edit_POST, Void, AnnoncePostResponse>()
                    {
                        PageMessage = pageGet,
                        Message = new Vendeur_Annonces_Id_Edit_POST() { Id = pageGet.Id },
                        Translate = (message, reponse) =>
                            new AnnoncePostResponse()
                            {
                                LienAnnonce = new Vendeur_Annonces_Id_GET { Id = message.Id }
                            },
                        MemberName = "Form"
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