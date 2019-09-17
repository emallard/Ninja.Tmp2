using System;
using System.Linq;
using System.Threading.Tasks;
using CocoriCore;
using CocoriCore.Linq.Async;

namespace LeBonCoin
{

    public class Users_Deconnexion_POST : ICommand, IMessage<Users_Deconnexion_POSTResponse>
    {
    }

    public class Users_Deconnexion_POSTResponse
    {
        public IClaims Claims;
    }


    public class Users_Deconnexion_POSTHandler : MessageHandler<Users_Deconnexion_POST, Users_Deconnexion_POSTResponse>
    {
        public override async Task<Users_Deconnexion_POSTResponse> ExecuteAsync(Users_Deconnexion_POST message)
        {
            await Task.CompletedTask;
            return new Users_Deconnexion_POSTResponse()
            {
                Claims = null
            };
        }
    }
}
