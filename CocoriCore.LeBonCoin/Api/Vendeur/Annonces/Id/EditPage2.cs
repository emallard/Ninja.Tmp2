using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CocoriCore;

namespace CocoriCore.LeBonCoin
{
    public class Form2<TMessage, TResponse>
    {
        public Func<TMessage, Task<TResponse>> Execute;
    }

    public class Get2<TMessage, TResponse> where TMessage : new()
    {
        public TMessage Message;
        public Get2()
        {
            Message = new TMessage();
        }
        public Get2(TMessage message)
        {
            Message = message;
        }

        public Action<TMessage> MessageAction;
        public Func<TMessage, Task<TResponse>> Execute;
    }


    public class EditPage2
    {
        public class PageGet
        {
            public Guid Id;
        }

        public class PageData
        {
            public Vendeur_Annonces_Id_Edit Data;
            public Vendeur_Annonces_Id_GET LienAnnonce;
        }

        public class PagePostResponse
        {
            public Vendeur_Annonces_Id_GET LienAnnonce;
        }

        //public Form<Vendeur_Annonces_Id_Edit_Page_Data_GET, Vendeur_Annonces_Id_Edit_Page_Data> GetData;
        public Get2<Vendeur_Annonces_Id_Edit_GET, PageData> Data;
        public Form2<Vendeur_Annonces_Id_Edit_POST, PagePostResponse> Form;
        public Form<Categories_GET, Categories> GetCategories;
        public Form<Villes_GET, Villes> GetVilles;

        public async Task ExecuteAsync(PageGet message)
        {
            // Donner les url pour les appels visant à obtenir les data
            await Task.CompletedTask;
            Data.Message.Id = message.Id;
        }


        public EditPage2(IExecuteHandler execute)
        {
            Data = new Get2<Vendeur_Annonces_Id_Edit_GET, PageData>()
            {
                Execute = async (message) =>
                {
                    var reponse = await execute.ExecuteAsync(message);
                    return new PageData() { Data = reponse, LienAnnonce = new Vendeur_Annonces_Id_GET { Id = reponse.Id } };
                }
            };



            Form.Execute = async (message) =>
                    {
                        var reponse = await execute.ExecuteAsync(message);
                        return new PagePostResponse() { LienAnnonce = new Vendeur_Annonces_Id_GET { Id = message.Id } };
                    };

        }

    }
}