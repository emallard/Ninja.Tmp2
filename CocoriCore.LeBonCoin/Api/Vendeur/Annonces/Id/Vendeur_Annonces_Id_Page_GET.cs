using System;
using System.Threading.Tasks;
using CocoriCore;

namespace CocoriCore.LeBonCoin
{

    public class Vendeur_Annonces_Id_Page_GET : IPage<Vendeur_Annonces_Id_Page>
    {
        public Guid Id;
    }

    public class Vendeur_Annonces_Id_Page
    {
        public Vendeur_Dashboard_Page_GET RetourDashboard;
        public AsyncCall<Vendeur_Annonces_Id_Page_GET, Vendeur_Annonces_Id> Modele;
        public Vendeur_Annonces_Id_Edit_Page_GET Modifier;
    }

    public class Vendeur_Annonces_Id_PageModule : PageModule
    {
        public Vendeur_Annonces_Id_PageModule()
        {
            Map<Vendeur_Annonces_Id_Page_GET, Vendeur_Annonces_Id_GET>(pageQuery => new Vendeur_Annonces_Id_GET { Id = pageQuery.Id });
            Map<Vendeur_Annonces_Id_GET, Vendeur_Annonces_Id, Vendeur_Annonces_Id>((m, r) => r);

            Handle<Vendeur_Annonces_Id_Page_GET, Vendeur_Annonces_Id_Page>(pageQuery =>
            {
                return new Vendeur_Annonces_Id_Page()
                {
                    RetourDashboard = new Vendeur_Dashboard_Page_GET(),
                    Modifier = new Vendeur_Annonces_Id_Edit_Page_GET() { Id = pageQuery.Id },
                    Modele = new AsyncCall<Vendeur_Annonces_Id_Page_GET, Vendeur_Annonces_Id>() { PageQuery = pageQuery }
                };
            });
        }
    }
}
