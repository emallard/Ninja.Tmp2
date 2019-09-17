using System.Threading.Tasks;
using CocoriCore;

namespace CocoriCore.LeBonCoin
{
    public class Users_MotDePasseOublie_Confirmation_Page_GET : IPageQuery<Void>
    {
    }


    public class Users_MotDePasseOublie_Confirmation_PAGEHandler : MessageHandler<Users_MotDePasseOublie_Confirmation_Page_GET, Void>
    {
        public override async Task<Void> ExecuteAsync(Users_MotDePasseOublie_Confirmation_Page_GET query)
        {
            await Task.CompletedTask;
            return new Void();
        }
    }
}