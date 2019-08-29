using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CocoriCore;

namespace CocoriCore.LeBonCoin
{

    public class Vendeur_Annonces_Id_Cancel_POST : IMessage<Void>, ICommand
    {
        public Guid Id;
    }

    public class Vendeur_Annonces_Id_Cancel_POSTHandler : MessageHandler<Vendeur_Annonces_Id_Cancel_POST, Void>
    {
        private readonly IRepository repository;

        public Vendeur_Annonces_Id_Cancel_POSTHandler(IRepository repository)
        {
            this.repository = repository;
        }

        public override Task<Void> ExecuteAsync(Vendeur_Annonces_Id_Cancel_POST command)
        {
            throw new NotImplementedException();
        }
    }

}