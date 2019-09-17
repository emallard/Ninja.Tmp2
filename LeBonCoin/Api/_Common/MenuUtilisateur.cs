using CocoriCore;

namespace LeBonCoin
{
    public class MenuVendeur
    {
        //public Accueil_Page_GET Deconnexion = new Accueil_Page_GET();
        public Form<Users_Deconnexion_POST, MenuVendeur_SeDeconnecter_Reponse> SeDeconnecter =
            new Form<Users_Deconnexion_POST, MenuVendeur_SeDeconnecter_Reponse> { Command = new Users_Deconnexion_POST() };
    }

    public class MenuVendeur_SeDeconnecter_Reponse : IClaimsResponse
    {
        public Accueil_Page_GET Accueil;

        public IClaims GetClaims()
        {
            return null;
        }

        public object GetResponse()
        {
            return Accueil;
        }
    }

    public class MenuVendeur_PageModule : PageModule
    {
        public MenuVendeur_PageModule()
        {
            Map<Users_Deconnexion_POST, Users_Deconnexion_POSTResponse, MenuVendeur_SeDeconnecter_Reponse>(
                (m, r) => new MenuVendeur_SeDeconnecter_Reponse()
                {
                    Accueil = new Accueil_Page_GET()
                }
            );
        }
    }
}