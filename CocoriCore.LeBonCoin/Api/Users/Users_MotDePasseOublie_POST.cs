using System;
using System.Threading.Tasks;
using CocoriCore;

namespace CocoriCore.LeBonCoin
{

    public class Users_MotDePasseOublie_POST : IMessage<Void>, ICommand
    {
        public string Email;
    }


    public class Users_MotDePasseOublie_POSTHandler : MessageHandler<Users_MotDePasseOublie_POST, Void>
    {
        private readonly IEmailSender emailSender;
        private readonly IRepository repository;

        public Users_MotDePasseOublie_POSTHandler(IEmailSender emailSender, IRepository repository)
        {
            this.emailSender = emailSender;
            this.repository = repository;
        }
        public async override Task<Void> ExecuteAsync(Users_MotDePasseOublie_POST query)
        {
            var token = new TokenMotDePasseOublie()
            {
                Id = Guid.NewGuid(),
                Email = query.Email
            };
            await repository.InsertAsync(token);


            await this.emailSender.Send(new MyMailMessage<EmailMotDePasseOublie>()
            {
                From = "from@example.com",
                To = "aa@aa.aa",
                Body = new EmailMotDePasseOublie()
                {
                    Lien = new Users_SaisieNouveauMotDePasse_Token_Page_GET()
                    {
                        Token = token.Id
                    }
                }
            });
            return new Void();
        }
    }
}