using System.Threading.Tasks;
using CocoriCore;
using CocoriCore.Page;

namespace CocoriCore.LeBonCoin
{
    public class EnTantQueVendeur : IScenario<Accueil_Page, Vendeur_Dashboard_PAGEResponse>
    {
        public TestBrowserFluent<Vendeur_Dashboard_PAGEResponse> Play(TestBrowserFluent<Accueil_Page> browserFluent)
        {
            var dashboard = browserFluent.Display(new Users_Inscription_Page_GET())
                .GetForm(p => p.Form)
                .Submit(
                    new Users_Inscription_Page_FormInscription_POST()
                    {
                        Post = new Users_Inscription_POST()
                        {
                            Email = "aa@aa.aa",
                            Password = "azerty",
                            PasswordConfirmation = "azerty"
                        }
                    })
                .ThenFollow(r => r.Vendeur_Dashboard);

            return dashboard;
        }
    }
}
