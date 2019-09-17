using System.Threading.Tasks;
using CocoriCore;
using CocoriCore.Page;

namespace LeBonCoin
{
    public class EnTantQueVendeur : IScenario<Accueil_Page, Vendeur_Dashboard_Page>
    {
        public string Email = "aa@aa.aa";
        public BrowserFluent<Vendeur_Dashboard_Page> Play(BrowserFluent<Accueil_Page> browserFluent)
        {
            var dashboard = browserFluent.Follow(p => p.Inscription)
                .Submit(p => p.SInscrire,
                        m =>
                        {
                            m.Nom = "Dupont";
                            m.Prenom = "Jean";
                            m.Email = this.Email;
                            m.Password = "azerty";
                            m.PasswordConfirmation = "azerty";
                        })
                .ThenFollow(r => r.PageDashboard);

            return dashboard;
        }
    }
}
