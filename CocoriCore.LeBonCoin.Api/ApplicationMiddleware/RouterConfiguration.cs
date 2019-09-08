using System;
using System.Threading.Tasks;
using CocoriCore;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using CocoriCore.LeBonCoin;
using CocoriCore.Router;

namespace CocoriCore.LeBonCoin.Api
{

    public class RouterConfiguration
    {

        public static RouterOptions Options()
        {
            var builder = new RouterOptionsBuilder();


            builder.Get<Accueil_Page_GET>()
                                                        .SetPath("api");
            builder.Get<ApiFootprintQuery>()
                                                        .SetPath("api/footprint");
            builder.Get<Users_Connexion_Page_GET>()
                                                        .SetPath("api/users/connexion");
            builder.Get<Users_Inscription_Page_GET>()
                                                        .SetPath("api/users/inscription");
            builder.Post<Users_Inscription_POST>()
                                                        .SetPath("api/users/inscription");
            builder.Get<Users_MotDePasseOublie_Page_GET>()
                                                        .SetPath("api/users/mot-de-passe-oublie");
            builder.Get<Vendeur_Dashboard_Page_GET>()
                                                        .SetPath("api/vendeur");
            builder.Get<Vendeur_NouvelleAnnonce_Page_GET>()
                                                        .SetPath("api/vendeur/nouvelle-annonce");
            builder.Get<Vendeur_Annonces_Page_GET>()
                                                        .SetPath("api/vendeur/annonces");
            builder.Get<Vendeur_Annonces_Id_Page_GET>()
                                                        .SetPath(x => $"api/vendeur/annonces/{x.Id}");
            builder.Get<Annonces_Page_GET>()
                                                        .SetPath("api/annonces").UseQuery();
            builder.Get<Annonces_Id_Page_GET>()
                                                        .SetPath(x => $"api/annonces/{x.Id}");

            builder.Post<Call>().SetPath("api/call").UseBody();
            builder.Get<HtmlMessage>().SetPath("api/page").UseQuery();
            builder.Get<FavIconMessage>().SetPath("favicon.ico").UseQuery();

            return builder.Options;
        }
    }
}