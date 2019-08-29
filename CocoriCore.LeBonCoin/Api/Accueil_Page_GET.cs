using System.Threading.Tasks;
using CocoriCore;

namespace CocoriCore.LeBonCoin
{
    public class Accueil_Page_GET : IPage<Accueil_Page>
    {
    }

    public class Accueil_Page
    {
        public Users_Connexion_Page_GET Connexion = new Users_Connexion_Page_GET();
        public Users_Inscription_Page_GET Inscription = new Users_Inscription_Page_GET();
        public Form<Accueil_Page_Form_GET, Accueil_Page_Form_GETResponse> Form = new Form<Accueil_Page_Form_GET, Accueil_Page_Form_GETResponse>();
        public Form<Villes_GET, Villes_GETResponse> RechercheVille = new Form<Villes_GET, Villes_GETResponse>();
        public string[] Categories;
    }

    public class Accueil_Page_GETHandler : MessageHandler<Accueil_Page_GET, Accueil_Page>
    {
        public async override Task<Accueil_Page> ExecuteAsync(Accueil_Page_GET query)
        {
            await Task.CompletedTask;
            return new Accueil_Page();
        }
    }
}