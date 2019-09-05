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
        public PageCall<Annonces_Page_GET, Annonces_GET, Annonces_Item[], Annonces_Page_Item[]> Items;
        public Call<Annonces_Page_Form_GET, Annonces_Page_Form_GETResponse> Form = new Call<Annonces_Page_Form_GET, Annonces_Page_Form_GETResponse>(new Annonces_Page_Form_GET());
        public Call<Villes_GET, string[]> RechercheVille = new Call<Villes_GET, string[]>(new Villes_GET());
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
                Items = new PageCall<Annonces_Page_GET, Annonces_GET, Annonces_Item[], Annonces_Page_Item[]>
                {
                    PageMessage = query,
                    Message = new Annonces_GET()
                    {
                        Ville = query.Ville,
                        Categorie = query.Categorie
                    },
                    Translate = (m, r) => r.Select(x => new Annonces_Page_Item()
                    {
                        Data = x,
                        Lien = new Annonces_Id_Page_GET() { Id = x.Id }
                    }).ToArray(),
                    MemberName = "Items"
                }
            };
            return response;
        }

    }


}