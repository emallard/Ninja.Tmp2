using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CocoriCore.LeBonCoin
{

    public class Vendeur_Annonces_Id_Edit_Page_Data_GET : IMessage<Vendeur_Annonces_Id_Edit_Page_Data>
    {
        public Vendeur_Annonces_Id_Edit_GET Get;

    }

    public class Vendeur_Annonces_Id_Edit_Page_Data
    {
        public Vendeur_Annonces_Id_Edit Data;
    }

    public class Vendeur_Annonces_Id_Edit_Page_Data_GETHandler : MessageHandler<Vendeur_Annonces_Id_Edit_Page_Data_GET, Vendeur_Annonces_Id_Edit_Page_Data>
    {
        private readonly IExecuteHandler executeHandler;

        public Vendeur_Annonces_Id_Edit_Page_Data_GETHandler(IExecuteHandler executeHandler)
        {
            this.executeHandler = executeHandler;
        }

        public override async Task<Vendeur_Annonces_Id_Edit_Page_Data> ExecuteAsync(Vendeur_Annonces_Id_Edit_Page_Data_GET message)
        {
            var data = await executeHandler.ExecuteAsync(message.Get);
            return new Vendeur_Annonces_Id_Edit_Page_Data
            {
                Data = data
            };
        }
    }
}
