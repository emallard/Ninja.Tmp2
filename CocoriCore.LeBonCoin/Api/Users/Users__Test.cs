using System;
using System.Threading.Tasks;
using CocoriCore.Page;
using FluentAssertions;
using Xunit;

namespace CocoriCore.LeBonCoin
{
    public class Users__Test : TestBase
    {
        [Fact]
        public void InscriptionConnexion()
        {
            var user = CreateUser("vendeur");

            var dashboard =
            user.Follow(p => p.Inscription)
                .Submit(p => p.SInscrire,
                        m =>
                        {
                            m.Email = "aa@aa.aa";
                            m.Password = "azerty";
                            m.PasswordConfirmation = "azerty";
                            m.Nom = "DeNice";
                            m.Prenom = "Brice";
                        })
                .ThenFollow(r => r.PageDashboard);

            var modele = dashboard.Page.Modele.Result;
            modele.Nom.Should().Be("DeNice");
            modele.Prenom.Should().Be("Brice");
            /*

            var accueil = await user.Click(dashboard.MenuUtilisateur.Deconnexion);
            var connexion = await user.Click(accueil.Connexion);

            var connexionGet = user.Submit(connexion.Submit, new Users_Connexion_POST()
            {
                Email = new Email { Value = "aa@aa.aa" },
                Password = new Password { Value = "azerty" }
            });

            connexionGet.Should().NotBeNull();
            */
        }

        [Fact]
        public void ImpossibleDeSeConnecter()
        {
            var vendeur1 = CreateUser("vendeur1");

            var dashboard =
            vendeur1.Display(new Users_Inscription_Page_GET())
                .Submit(p => p.SInscrire,
                        m =>
                        {
                            m.Email = "aa@aa.aa";
                            m.Password = "azerty";
                            m.PasswordConfirmation = "azerty";
                            m.Nom = "DeNice";
                            m.Prenom = "Brice";
                        });

            var vendeur2 = CreateUser("vendeur2");
            var connexion = vendeur2.Follow(p => p.Connexion);

            Action a = () => connexion
                .Submit(p => p.SeConnecter,
                        m =>
                        {
                            m.Email = "aa@aa.aa";
                            m.Password = "mauvaiMotDePasse";
                        });

            a.Should().Throw<Exception>();

            Action b = () => connexion
                .Submit(p => p.SeConnecter,
                        m =>
                        {
                            m.Email = "bb@bb.bb";
                            m.Password = "azerty";
                        });

            b.Should().Throw<Exception>();

            Console.WriteLine(GetHistory().Summary());
        }

        [Fact]
        public async Task MotDePasseOublie()
        {

            var user = CreateUser("vendeur");
            var emailReader = GetEmailReader();

            var confirmation =
            user.Display(new Users_Inscription_Page_GET())
                .Submit(p => p.SInscrire,
                        m =>
                        {
                            m.Email = "aa@aa.aa";
                            m.Password = "azerty";
                            m.PasswordConfirmation = "azerty";
                            m.Nom = "Dupont";
                            m.Prenom = "Jean";
                        })
                .ThenFollow(r => r.PageDashboard)
                .Follow(p => p.MenuVendeur.Deconnexion)
                .Follow(p => p.Connexion)
                .Follow(p => p.MotDePasseOublie)
                .Submit(p => p.EnvoyerEmail,
                        m => m.Email = "aa@aa.aa")
                .ThenFollow(r => r)
                .Page;

            confirmation.Should().NotBeNull();

            var emails = await emailReader.Read<EmailMotDePasseOublie>("aa@aa.aa");
            emails.Should().HaveCount(1);
            var lien = emails[0].Body.Lien;

            var dashboard = user.Display(lien)
                .Submit(p => p.ConfirmerNouveauMotDePasse,
                        m =>
                        {
                            m.Token = lien.Token;
                            m.MotDePasse = "nouveauPassw0rd";
                            m.Confirmation = "nouveauPassw0rd";
                        })
                .ThenFollow(r => r)
                .Submit(p => p.SeConnecter,
                        m =>
                        {
                            m.Email = "aa@aa.aa";
                            m.Password = "nouveauPassw0rd";
                        })
                .ThenFollow(r => r.PageDashboard);

            dashboard.Page.Should().NotBeNull();

            Console.WriteLine(GetHistory().Summary());
        }
    }
}