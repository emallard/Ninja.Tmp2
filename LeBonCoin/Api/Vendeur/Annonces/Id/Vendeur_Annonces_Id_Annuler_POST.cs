using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CocoriCore;

namespace LeBonCoin
{

    public class Vendeur_Annonces_Id_Annuler_POST : IMessage<Void>, ICommand
    {
        public Guid Id;
    }

    public class Vendeur_Annonces_Id_Annuler_POSTHandler : MessageHandler<Vendeur_Annonces_Id_Annuler_POST, Void>
    {
        private readonly IRepository repository;

        public Vendeur_Annonces_Id_Annuler_POSTHandler(IRepository repository)
        {
            this.repository = repository;
        }

        public override Task<Void> ExecuteAsync(Vendeur_Annonces_Id_Annuler_POST command)
        {
            throw new NotImplementedException();
        }
    }

}