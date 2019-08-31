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
                .Submit(p => p.FormInscription,
                        m =>
                        {
                            m.Email = "aa@aa.aa";
                            m.Password = "azerty";
                            m.PasswordConfirmation = "azerty";
                        })
                .ThenFollow(r => r.PageDashboard);

            return dashboard;
        }
    }
}
