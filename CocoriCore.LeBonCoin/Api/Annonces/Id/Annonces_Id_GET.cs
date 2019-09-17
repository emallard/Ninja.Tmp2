using System;
using System.Linq;
using System.Threading.Tasks;
using CocoriCore;

namespace CocoriCore.LeBonCoin
{

    public class Annonces_Id_GET : IPageQuery<Annonces_Id_GETResponse>, IQuery
    {
        public Guid Id;
    }

    public class Annonces_Id_GETResponse
    {
        public Guid Id;
        public string Ville;
        public string Categorie;
        public string Texte;
    }

    public class Annonces_Id_GETHandler : MessageHandler<Annonces_Id_GET, Annonces_Id_GETResponse>
    {
        private readonly IRepository repository;

        public Annonces_Id_GETHandler(IRepository repository)
        {
            this.repository = repository;
        }

        public override async Task<Annonces_Id_GETResponse> ExecuteAsync(Annonces_Id_GET message)
        {
            var annonce = await repository.LoadAsync<Annonce>(message.Id);
            await Task.CompletedTask;
            var response = new Annonces_Id_GETResponse()
            {
                Id = annonce.Id,
                Ville = annonce.Ville,
                Categorie = annonce.Categorie,
                Texte = annonce.Texte
            };
            return response;
        }

    }


}