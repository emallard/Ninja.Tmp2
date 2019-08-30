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
            user.Display(new Users_Inscription_Page_GET())
                .Submit(p => p.Form)
                .With(new Users_Inscription_Page_FormInscription_POST()
                {
                    Post = new Users_Inscription_POST()
                    {
                        Email = "aa@aa.aa",
                        Password = "azerty",
                        PasswordConfirmation = "azerty",
                        Nom = "DeNice",
                        Prenom = "Brice"
                    }
                })
                .ThenFollow(r => r.LienVendeur_Dashboard);

            dashboard.Page.Data.Nom.Should().Be("DeNice");
            dashboard.Page.Data.Prenom.Should().Be("Brice");
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
                .Submit(p => p.Form)
                .With(new Users_Inscription_Page_FormInscription_POST()
                {
                    Post = new Users_Inscription_POST()
                    {
                        Email = "aa@aa.aa",
                        Password = "azerty",
                        PasswordConfirmation = "azerty",
                        Nom = "DeNice",
                        Prenom = "Brice"
                    }
                });

            var vendeur2 = CreateUser("vendeur2");
            var connexion = vendeur2.Follow(p => p.Connexion);

            Action a = () => connexion
                .Submit(p => p.Form)
                .With(new Users_Connexion_Page_FormConnexion_POST()
                {

                    Post = new Users_Connexion_POST()
                    {
                        Email = "aa@aa.aa",
                        Password = "mauvaisMotDePasse"
                    }
                });

            a.Should().Throw<Exception>();

            Action b = () => connexion
                .Submit(p => p.Form)
                .With(new Users_Connexion_Page_FormConnexion_POST()
                {
                    Post = new Users_Connexion_POST()
                    {
                        Email = "bb@bb.bb",
                        Password = "azerty"
                    }
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
                .Submit(p => p.Form)
                .With(new Users_Inscription_Page_FormInscription_POST()
                {
                    Post = new Users_Inscription_POST()
                    {
                        Email = "aa@aa.aa",
                        Password = "azerty",
                        PasswordConfirmation = "azerty",
                        Nom = "Dupont",
                        Prenom = "Jean"
                    }
                })
                .ThenFollow(r => r.LienVendeur_Dashboard)
                .Follow(p => p.MenuUtilisateur.Deconnexion)
                .Follow(p => p.Connexion)
                .Follow(p => p.MotDePasseOublie)
                .Submit(p => p.Form)
                .With(
                    new Users_MotDePasseOublie_Page_Form_POST()
                    {
                        Post = new Users_MotDePasseOublie_POST()
                        {
                            Email = "aa@aa.aa"
                        }
                    })
                .ThenFollow(r => r.MotDePasseOublie_Confirmation)
                .Page;

            confirmation.Should().NotBeNull();

            var emails = await emailReader.Read<EmailMotDePasseOublie>("aa@aa.aa");
            emails.Should().HaveCount(1);
            var lien = emails[0].Body.Lien;

            var dashboard = user.Display(lien)
                .Submit(p => p.Form)
                .With(
                    new Users_SaisieNouveauMotDePasse_Token_Page_Form_POST()
                    {
                        Post = new Users_SaisieNouveauMotDePasse_Token_POST
                        {
                            Token = lien.Token,
                            MotDePasse = "nouveauPassw0rd",
                            Confirmation = "nouveauPassw0rd",
                        }
                    })
                .ThenFollow(r => r.PageConnexion)
                .Submit(p => p.Form)
                .With(new Users_Connexion_Page_FormConnexion_POST()
                {
                    Post = new Users_Connexion_POST()
                    {
                        Email = "aa@aa.aa",
                        Password = "nouveauPassw0rd",
                    }
                })
                .ThenFollow(r => r.DashboardPage);

            dashboard.Page.Should().NotBeNull();

            Console.WriteLine(GetHistory().Summary());
        }
    }
}