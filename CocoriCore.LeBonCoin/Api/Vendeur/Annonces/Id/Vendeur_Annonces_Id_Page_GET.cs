using System;
using System.Threading.Tasks;
using CocoriCore;

namespace CocoriCore.LeBonCoin
{

    public class Vendeur_Annonces_Id_Page_GET : IPage<Vendeur_Annonces_Id_Page>
    {
        public Guid Id;
    }

    public class Vendeur_Annonces_Id_Page
    {
        public Vendeur_Annonces_Id Data;

        public Vendeur_Annonces_Id_Edit_Page_GET Edit;

        public Vendeur_Annonces_Id_Annuler_POST Cancel;
    }

    public class Vendeur_Annonces_Id_Page_GETHandler : MessageHandler<Vendeur_Annonces_Id_Page_GET, Vendeur_Annonces_Id_Page>
    {
        private readonly IExecuteHandler messageBus;

        public Vendeur_Annonces_Id_Page_GETHandler(IExecuteHandler messageBus)
        {
            this.messageBus = messageBus;
        }

        public async override Task<Vendeur_Annonces_Id_Page> ExecuteAsync(Vendeur_Annonces_Id_Page_GET query)
        {
            var data = await messageBus.ExecuteAsync(new Vendeur_Annonces_Id_GET()
            {
                Id = query.Id
            });
            return new Vendeur_Annonces_Id_Page()
            {
                Data = data,
                Edit = new Vendeur_Annonces_Id_Edit_Page_GET { Id = query.Id },
                Cancel = new Vendeur_Annonces_Id_Annuler_POST { Id = query.Id }
            };
        }
    }
}
