using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CocoriCore;

namespace CocoriCore.LeBonCoin
{
    /*
    public class Get3<TPageMessage, TMessage, TMessageResponse, TPageResponse> where TMessage : new()
    {
        public TMessage Message;
        public Func<TPageMessage, TMessage> MessageFunc;
        public Func<TMessage, TMessageResponse, TPageResponse> Execute;
    }*/

    public class Form3<TPageMessage, TMessage, TResponse, TPageResponse>
    {
        public TMessage Message;
        public Func<TPageMessage, TMessage> MessageFunc;
        public Func<TMessage, TResponse, TPageResponse> Execute;
    }


    public interface IPage3<TGet, TResponse>
    {

    }

    public class EditPage3 : IPage3<EditPage3.PageGet, EditPage3.PageResponse>
    {
        public class PageGet : IMessage<PageResponse>
        {
            public Guid Id;
        }

        public class PageResponse
        {
            public Form3<PageGet, Vendeur_Annonces_Id_Edit_GET, Vendeur_Annonces_Id_Edit, AnnonceData> Data;
            public Form3<PageGet, Vendeur_Annonces_Id_Edit_POST, Void, AnnoncePostResponse> Form;
            public Form<Categories_GET, Categories> GetCategories;
            public Form<Villes_GET, Villes> GetVilles;

            public PageResponse()
            {
                Data = new Form3<PageGet, Vendeur_Annonces_Id_Edit_GET, Vendeur_Annonces_Id_Edit, AnnonceData>()
                {
                    MessageFunc = (pageGet) => new Vendeur_Annonces_Id_Edit_GET() { Id = pageGet.Id },
                    Execute = (message, reponse) =>
                    {
                        return new AnnonceData()
                        {
                            Data = reponse,
                            LienAnnonce = new Vendeur_Annonces_Id_GET { Id = reponse.Id }
                        };
                    }
                };
                Form = new Form3<PageGet, Vendeur_Annonces_Id_Edit_POST, Void, AnnoncePostResponse>()
                {
                    MessageFunc = (pageGet) => new Vendeur_Annonces_Id_Edit_POST() { Id = pageGet.Id },
                    Execute = (message, reponse) =>
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

        //public Form<Vendeur_Annonces_Id_Edit_Page_Data_GET, Vendeur_Annonces_Id_Edit_Page_Data> GetData;

        public PageResponse Execute(PageGet message)
        {
            return new PageResponse()
            {

            };
        }
    }

}