using System;
using System.Linq;
using System.Threading.Tasks;
using CocoriCore;

namespace CocoriCore.LeBonCoin
{

    public class Annonces_Id_Page_GET : IPage<Annonces_Id_Page>, IQuery
    {
        public Guid Id;
    }

    public class Annonces_Id_Page
    {
        public Annonces_Id_GETResponse Data;
    }

    public class Annonces_Id_Page_GETHandler : MessageHandler<Annonces_Id_Page_GET, Annonces_Id_Page>
    {
        private readonly IMessageBus messageBus;

        public Annonces_Id_Page_GETHandler(IMessageBus messageBus)
        {
            this.messageBus = messageBus;
        }

        public override async Task<Annonces_Id_Page> ExecuteAsync(Annonces_Id_Page_GET message)
        {
            var data = (Annonces_Id_GETResponse)await messageBus.ExecuteAsync(new Annonces_Id_GET() { Id = message.Id });
            var response = new Annonces_Id_Page()
            {
                Data = data
            };
            return response;
        }

    }


}