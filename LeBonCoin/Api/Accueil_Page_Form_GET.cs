using System;
using System.Linq;
using System.Threading.Tasks;
using CocoriCore;
using CocoriCore.Linq.Async;

namespace LeBonCoin
{

    public class Accueil_Page_Form_GET : ICommand, IMessage<Annonces_Page_GET>
    {
        public string Ville;
        public string Categorie;
    }


    public class Accueil_Page_Form_GETHandler : MessageHandler<Accueil_Page_Form_GET, Annonces_Page_GET>
    {

        public Accueil_Page_Form_GETHandler()
        {
        }

        public override async Task<Annonces_Page_GET> ExecuteAsync(Accueil_Page_Form_GET message)
        {
            await Task.CompletedTask;
            return new Annonces_Page_GET()
            {
                Ville = message.Ville,
                Categorie = message.Categorie
            };
        }
    }
}
