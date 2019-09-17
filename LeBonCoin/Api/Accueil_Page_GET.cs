using System.Threading.Tasks;
using CocoriCore;

namespace LeBonCoin
{
    public class Accueil_Page_GET : IPageQuery<Accueil_Page>
    {
    }

    public class Accueil_Page
    {
        public Users_Connexion_Page_GET Connexion = new Users_Connexion_Page_GET();
        public Users_Inscription_Page_GET Inscription = new Users_Inscription_Page_GET();
        //public PageCall<Accueil_Page_GET, Accueil_Page_Form_GET, Annonces_Page_GET, Annonces_Page_GET> Form;
        public Form<Accueil_Page_Form_GET, Annonces_Page_GET> Rechercher;
        public Call<Villes_GET, string[]> RechercheVille;
        public Call<Categories_GET, string[]> Categories;
        //public Form<Categories_GET, Categories_GETResponse> ListeCategories ;
        //lien : Accueil_Page_Form_GET.Ville => RechercheVille
        //       Accueil_Page_Form_GET.Categorie => ListeCategories



    }

    public class Accueil_PageModule : PageModule
    {
        public Accueil_PageModule()
        {
            Map<Accueil_Page_Form_GET, Annonces_Page_GET, Annonces_Page_GET>(
                  (m, r) => r
              );

            Handle<Accueil_Page_GET, Accueil_Page>(
                x => new Accueil_Page()
                {
                    Connexion = new Users_Connexion_Page_GET(),
                    Inscription = new Users_Inscription_Page_GET(),
                    Rechercher = new Form<Accueil_Page_Form_GET, Annonces_Page_GET>(),
                    RechercheVille = new Call<Villes_GET, string[]>(new Villes_GET()),
                    Categories = new Call<Categories_GET, string[]>(new Categories_GET())
                });
        }
    }

    /*
        public class Accueil_Page_GETHandler : PageHandler<Accueil_Page_GET, Accueil_Page>
        {
            public override void ExecuteAsync(Accueil_Page_GET query)
            {
                Create(x => x.Form,
                        new Accueil_Page_Form_GET(),
                        r => r
                );

                Page.Categories = new Call<Categories_GET, string[]>(new Categories_GET());
                Page.RechercheVille = new Call<Villes_GET, string[]>(new Villes_GET());
            }
        }
    */
}