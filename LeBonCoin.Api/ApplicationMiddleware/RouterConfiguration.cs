using System;
using System.Threading.Tasks;
using CocoriCore;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using LeBonCoin;
using CocoriCore.Router;

namespace LeBonCoin.Api
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
            builder.Get<Users_MotDePasseOublie_Confirmation_Page_GET>()
                                                        .SetPath("api/users/mot-de-passe-oublie/confirmation");
            builder.Get<Users_SaisieNouveauMotDePasse_Token_Page_GET>().UseQuery()
                                                        .SetPath("api/users/saisie-nouveau-mot-de-passe");
            builder.Get<Vendeur_Dashboard_Page_GET>()
                                                        .SetPath("api/vendeur");
            builder.Get<Vendeur_NouvelleAnnonce_Page_GET>()
                                                        .SetPath("api/vendeur/nouvelle-annonce");
            builder.Get<Vendeur_Annonces_Page_GET>()
                                                        .SetPath("api/vendeur/annonces");
            builder.Get<Vendeur_Annonces_Id_Page_GET>()
                                                        .SetPath(x => $"api/vendeur/annonces/{x.Id}");
            builder.Get<Vendeur_Annonces_Id_Edit_Page_GET>()
                                                        .SetPath(x => $"api/vendeur/annonces/{x.Id}/edit");
            builder.Get<Annonces_Page_GET>()
                                                        .SetPath("api/annonces").UseQuery();
            builder.Get<Annonces_Id_Page_GET>()
                                                        .SetPath(x => $"api/annonces/{x.Id}");



            builder.Post<Call>().SetPath("api/call").UseBody();
            builder.Get<HtmlMessage>().SetPath("api/page").UseQuery();
            builder.Get<FavIconMessage>().SetPath("favicon.ico").UseQuery();
            builder.Get<Tests_GET>().SetPath("api/tests");
            builder.Get<Tests_Id_GET>().SetPath(x => $"api/tests/{x.Type}/{x.TestName}").UseQuery();

            builder.Get<Graph_GET>().SetPath("api/graph").UseQuery();

            return builder.Options;
        }
    }
}