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
        public Form5<Annonces_GET, Annonces_Item[], Annonces_Page_Item[]> Items;
        public Form<Annonces_Page_Form_GET, Annonces_Page_Form_GETResponse> Form = new Form<Annonces_Page_Form_GET, Annonces_Page_Form_GETResponse>();
        public Form<Villes_GET, Villes> RechercheVille = new Form<Villes_GET, Villes>();
    }

    public class Annonces_Page_Item
    {
        public Annonces_Item Data;
        public Annonces_Id_Page_GET Lien;
    }

    public class Annonces_Page_GETHandler : MessageHandler<Annonces_Page_GET, Annonces_Page>
    {
        private readonly IExecuteHandler messageBus;

        public Annonces_Page_GETHandler(IExecuteHandler messageBus)
        {
            this.messageBus = messageBus;
        }

        public override async Task<Annonces_Page> ExecuteAsync(Annonces_Page_GET query)
        {
            var data = await messageBus.ExecuteAsync(new Annonces_GET()
            {
                Ville = query.Ville,
                Categorie = query.Categorie
            });
            var response = new Annonces_Page()
            {
                Items = new Form5<Annonces_GET, Annonces_Item[], Annonces_Page_Item[]>
                {
                    Message = new Annonces_GET()
                    {
                        Ville = query.Ville,
                        Categorie = query.Categorie
                    },
                    Translate = (m, r) => r.Select(x => new Annonces_Page_Item()
                    {
                        Data = x,
                        Lien = new Annonces_Id_Page_GET() { Id = x.Id }
                    }).ToArray()
                }
            };
            return response;
        }

    }


}