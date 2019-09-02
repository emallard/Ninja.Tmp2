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
        public PageCall<Accueil_Page_GET, Accueil_Page_Form_GET, Accueil_Page_Form_GETResponse, Accueil_Page_Form_GETResponse> Form;
        public Call<Villes_GET, string[]> RechercheVille;
        public Call<Categories_GET, string[]> Categories;
        //public Form<Categories_GET, Categories_GETResponse> ListeCategories ;
        //lien : Accueil_Page_Form_GET.Ville => RechercheVille
        //       Accueil_Page_Form_GET.Categorie => ListeCategories



    }

    public class Accueil_Page_GETHandler : MessageHandler<Accueil_Page_GET, Accueil_Page>
    {
        public async override Task<Accueil_Page> ExecuteAsync(Accueil_Page_GET query)
        {
            await Task.CompletedTask;
            return new Accueil_Page()
            {
                Form = new PageCall<Accueil_Page_GET, Accueil_Page_Form_GET, Accueil_Page_Form_GETResponse, Accueil_Page_Form_GETResponse>()
                {
                    PageMessage = query,
                    Message = new Accueil_Page_Form_GET(),
                    Translate = (m, r) => r,
                    MemberName = "Form"
                },
                Categories = new Call<Categories_GET, string[]>(new Categories_GET()),
                RechercheVille = new Call<Villes_GET, string[]>(new Villes_GET()),
            };
        }
    }
}