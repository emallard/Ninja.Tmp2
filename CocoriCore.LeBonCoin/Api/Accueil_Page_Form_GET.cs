using System;
using System.Linq;
using System.Threading.Tasks;
using CocoriCore;
using CocoriCore.Linq.Async;

namespace CocoriCore.LeBonCoin
{

    public class Accueil_Page_Form_GET : ICommand, IMessage<Accueil_Page_Form_GETResponse>
    {
        public string Ville;
        public string Categorie;
    }

    public class Accueil_Page_Form_GETResponse
    {
        public Annonces_Page_GET Annonces;
    }


    public class Accueil_Page_Form_GETHandler : MessageHandler<Accueil_Page_Form_GET, Accueil_Page_Form_GETResponse>
    {

        public Accueil_Page_Form_GETHandler()
        {
        }

        public override async Task<Accueil_Page_Form_GETResponse> ExecuteAsync(Accueil_Page_Form_GET message)
        {
            await Task.CompletedTask;
            return new Accueil_Page_Form_GETResponse()
            {
                Annonces = new Annonces_Page_GET()
                {
                    Ville = message.Ville,
                    Categorie = message.Categorie
                }
            };
        }
    }
}
