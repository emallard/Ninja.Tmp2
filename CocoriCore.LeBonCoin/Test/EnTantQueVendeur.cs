using System.Threading.Tasks;
using CocoriCore;
using CocoriCore.Page;

namespace CocoriCore.LeBonCoin
{
    public class EnTantQueVendeur : IScenario<Accueil_Page, Vendeur_Dashboard_Page>
    {
        public TestBrowserFluent<Vendeur_Dashboard_Page> Play(TestBrowserFluent<Accueil_Page> browserFluent)
        {
            var dashboard = browserFluent.Display(new Users_Inscription_Page_GET())
                .Submit(p => p.Form)
                .With(
                    new Users_Inscription_Page_FormInscription_POST()
                    {
                        Post = new Users_Inscription_POST()
                        {
                            Email = "aa@aa.aa",
                            Password = "azerty",
                            PasswordConfirmation = "azerty"
                        }
                    })
                .ThenFollow(r => r.LienVendeur_Dashboard);

            return dashboard;
        }
    }
}
