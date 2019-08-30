using System;
using System.Linq;
using System.Threading.Tasks;
using CocoriCore;
using CocoriCore.Linq.Async;

namespace CocoriCore.LeBonCoin
{

    public class Annonces_Page_Form_GET : ICommand, IMessage<Annonces_Page_Form_GETResponse>
    {
        public string Ville;
        public string Categorie;
    }

    public class Annonces_Page_Form_GETResponse
    {
        public Annonces_Page_GET LienAnnonces;
    }


    public class Annonces_Page_Form_GETHandler : MessageHandler<Annonces_Page_Form_GET, Annonces_Page_Form_GETResponse>
    {

        public Annonces_Page_Form_GETHandler()
        {
        }

        public override async Task<Annonces_Page_Form_GETResponse> ExecuteAsync(Annonces_Page_Form_GET message)
        {
            await Task.CompletedTask;
            return new Annonces_Page_Form_GETResponse()
            {
                LienAnnonces = new Annonces_Page_GET()
                {
                    Ville = message.Ville,
                    Categorie = message.Categorie
                }
            };
        }
    }
}
