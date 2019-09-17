using System;
using System.Threading.Tasks;
using CocoriCore.Page;
using FluentAssertions;
using Xunit;

namespace CocoriCore.LeBonCoin
{
    public class Vendeur__Test : TestBase
    {
        [Fact]
        public void NouvelleAnnonceEtModification()
        {
            var dashboard = CreateBrowser("vendeur")
                .Play(new EnTantQueVendeur());

            var annonce = dashboard
                .Follow(p => p.NouvelleAnnonce)
                .Submit(p => p.Creer,
                    m =>
                    {
                        m.Ville = "Paris";
                        m.Categorie = "Bien-être";
                        m.Texte = "Je vends de la crème";
                    })
                .ThenFollow(r => r);

            var modeleAnnonce = annonce.Page.Modele.Result;
            modeleAnnonce.Ville.Should().Be("Paris");
            modeleAnnonce.Categorie.Should().Be("Bien-être");
            modeleAnnonce.Texte.Should().Be("Je vends de la crème");


            var modifier = annonce.Follow(p => p.Modifier);

            var modele = modifier.Page.Modele.Result;
            modele.Data.Ville.Should().Be("Paris");
            modele.Data.Categorie.Should().Be("Bien-être");
            modele.Data.Texte.Should().Be("Je vends de la crème");

            //modifier.SetValue(p => p.Modele.Data.Texte, "Je vends du shampoing");
            //modifier.Submit(p => p.Enregistrer);
        }
    }
}