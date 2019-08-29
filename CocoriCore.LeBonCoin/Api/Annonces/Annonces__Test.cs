using System;
using System.Threading.Tasks;
using CocoriCore.Page;
using FluentAssertions;
using Xunit;

namespace CocoriCore.LeBonCoin
{
    public class Annonces__Test : TestBase
    {

        [Fact]
        public void RechercheParCategorie()
        {
            var vendeurDashboard = CreateUser("vendeur")
                .Play(new EnTantQueVendeur());

            var vendeurAnnonce = vendeurDashboard
                .Follow(p => p.NouvelleAnnonce)
                .GetForm(p => p.Form)
                .Submit(
                    new Vendeur_NouvelleAnnonce_Page_Form_POST()
                    {
                        Post = new Vendeur_NouvelleAnnonce_POST()
                        {
                            Ville = "Paris",
                            Categorie = "Voitures"
                        }
                    })
                .ThenFollow(r => r.PageAnnonce)
                .Page;

            var visiteur = CreateUser("visiteur");
            var annonces = visiteur
                .GetForm(p => p.Form)
                .Submit(new Accueil_Page_Form_GET()
                {
                    Ville = "Paris",
                    Categorie = ""
                })
                .ThenFollow(r => r.Annonces)
                .Page;
            /*
            annonces.Items.Should().HaveCount(1);
            annonces.Items[0].Ville.Should().Be("Paris");
            annonces.Items[0].Categorie.Should().Be("Voiture");
            */
            Console.WriteLine(this.GetHistory().Summary());
        }
    }
}