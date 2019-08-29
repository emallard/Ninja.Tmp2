using System.Threading.Tasks;
using CocoriCore;

namespace CocoriCore.LeBonCoin
{
    public class Users_Inscription_Page_GET : IPage<Users_Inscription_Page>, IQuery
    {
    }

    public class Users_Inscription_Page
    {
        public Form<Users_Inscription_Page_FormInscription_POST, Users_Inscription_Page_FormInscription_POSTResponse> Form = new Form<Users_Inscription_Page_FormInscription_POST, Users_Inscription_Page_FormInscription_POSTResponse>();
    }

    public class Users_Inscription_PAGEHandler : MessageHandler<Users_Inscription_Page_GET, Users_Inscription_Page>
    {
        public override async Task<Users_Inscription_Page> ExecuteAsync(Users_Inscription_Page_GET query)
        {
            await Task.CompletedTask;
            return new Users_Inscription_Page()
            {
            };
        }
    }

}