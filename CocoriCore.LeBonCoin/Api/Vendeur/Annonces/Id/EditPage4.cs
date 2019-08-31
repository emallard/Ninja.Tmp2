using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CocoriCore;

namespace CocoriCore.LeBonCoin
{

    public class Form4<TMessage, TResponse, TPageResponse>
    {
        public TMessage Message;
        public Func<TMessage, TResponse, TPageResponse> Translate;
    }

    public interface IPage4<T>
    {
        void Set(T pageGet);
    }


    public class EditPage4
    {
        public class PageGet : IMessage<Page>
        {
            public Guid Id;
        }

        public class Page : IPage4<PageGet>
        {
            public Form4<Vendeur_Annonces_Id_Edit_GET, Vendeur_Annonces_Id_Edit, AnnonceData> Data;
            public Form4<Vendeur_Annonces_Id_Edit_POST, Void, AnnoncePostResponse> Form;
            public Form<Categories_GET, Categories> GetCategories;
            public Form<Villes_GET, Villes> GetVilles;

            public void Set(EditPage4.PageGet pageGet)
            {
                Data = new Form4<Vendeur_Annonces_Id_Edit_GET, Vendeur_Annonces_Id_Edit, AnnonceData>()
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
                };
                Form = new Form4<Vendeur_Annonces_Id_Edit_POST, Void, AnnoncePostResponse>()
                {
                    Message = new Vendeur_Annonces_Id_Edit_POST() { Id = pageGet.Id },
                    Translate = (message, reponse) =>
                        new AnnoncePostResponse()
                        {
                            LienAnnonce = new Vendeur_Annonces_Id_GET { Id = message.Id }
                        }
                };
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