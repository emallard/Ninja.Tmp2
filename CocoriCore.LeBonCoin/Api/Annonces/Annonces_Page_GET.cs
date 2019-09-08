using System;
using System.Linq;
using System.Threading.Tasks;
using CocoriCore;

namespace CocoriCore.LeBonCoin
{

    public class Annonces_Page_GET : IPage<Annonces_Page>, IQuery
    {
        public string Ville;
        public string Categorie;

    }

    public class Annonces_Page
    {
        public AsyncCall<Annonces_Page_GET, Annonces_Page_Item[]> Items;
        //public Call<Annonces_Page_Form_GET, Annonces_Page_Form_GETResponse> Form = new Call<Annonces_Page_Form_GET, Annonces_Page_Form_GETResponse>(new Annonces_Page_Form_GET());
        public Call<Villes_GET, string[]> RechercheVille = new Call<Villes_GET, string[]>(new Villes_GET());
    }

    public class Annonces_Page_Item
    {
        public Annonces_Item Data;
        public Annonces_Id_Page_GET Lien;
    }

    public class Annonces_PageMapperModule : PageMapperModule
    {
        public Annonces_PageMapperModule()
        {
            Map<Annonces_Page_GET, Annonces_GET>(m => new Annonces_GET() { Categorie = m.Categorie, Ville = m.Ville });
            Map<Annonces_GET, Annonces_Item[], Annonces_Page_Item[]>((m, r) => r.Select(x => new Annonces_Page_Item()
            {
                Data = x,
                Lien = new Annonces_Id_Page_GET() { Id = x.Id }
            }).ToArray());

            Handle<Annonces_Page_GET, Annonces_Page>(pageQuery => new Annonces_Page()
            {
                Items = new AsyncCall<Annonces_Page_GET, Annonces_Page_Item[]> { PageQuery = pageQuery }
            });
        }
    }
}