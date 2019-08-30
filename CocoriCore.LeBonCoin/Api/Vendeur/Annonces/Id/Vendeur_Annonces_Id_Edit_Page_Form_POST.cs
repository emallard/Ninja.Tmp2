using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CocoriCore.LeBonCoin
{

    public class Vendeur_Annonces_Id_Edit_Page_Form_POST : IMessage<Vendeur_Annonces_Id_Edit_Page_Form_POSTResponse>
    {
        public Vendeur_Annonces_Id_Edit_POST Post;

    }

    public class Vendeur_Annonces_Id_Edit_Page_Form_POSTResponse
    {
        public Vendeur_Annonces_Id_GET LienAnnonce;
    }

    public class Vendeur_Annonces_Id_Edit_Page_Form_POSTHandler : MessageHandler<Vendeur_Annonces_Id_Edit_Page_Form_POST, Vendeur_Annonces_Id_Edit_Page_Form_POSTResponse>
    {
        private readonly IExecuteHandler executeHandler;

        public Vendeur_Annonces_Id_Edit_Page_Form_POSTHandler(IExecuteHandler executeHandler)
        {
            this.executeHandler = executeHandler;
        }

        public override async Task<Vendeur_Annonces_Id_Edit_Page_Form_POSTResponse> ExecuteAsync(Vendeur_Annonces_Id_Edit_Page_Form_POST message)
        {
            await executeHandler.ExecuteAsync(message.Post);
            return new Vendeur_Annonces_Id_Edit_Page_Form_POSTResponse
            {
                LienAnnonce = new Vendeur_Annonces_Id_GET { Id = message.Post.Id }
            };
        }
    }
}
