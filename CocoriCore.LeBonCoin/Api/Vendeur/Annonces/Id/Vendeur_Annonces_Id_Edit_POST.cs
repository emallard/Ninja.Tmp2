using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CocoriCore.LeBonCoin
{

    public class Vendeur_Annonces_Id_Edit_POST : IMessage<Void>
    {
        public Guid Id;
        public string Ville;
        public string Categorie;
        public string Texte;

    }

    public class Vendeur_Annonces_Id_Edit_POSTHandler : MessageHandler<Vendeur_Annonces_Id_Edit_POST, Void>
    {
        private readonly IRepository repository;

        public Vendeur_Annonces_Id_Edit_POSTHandler(IRepository repository)
        {
            this.repository = repository;
        }

        public override async Task<Void> ExecuteAsync(Vendeur_Annonces_Id_Edit_POST message)
        {
            var annonce = await repository.LoadAsync<Annonce>(message.Id);
            annonce.Ville = message.Ville;
            annonce.Categorie = message.Categorie;
            annonce.Texte = message.Texte;

            await repository.UpdateAsync(annonce);
            return new Void();
        }
    }
}