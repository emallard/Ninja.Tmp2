using System;
using System.Threading.Tasks;
using CocoriCore;
using CocoriCore.Page;

namespace LeBonCoin
{

    public class Users_MotDePasseOublie_POST : IMessage<Void>, ICommand
    {
        public string Email;
    }


    public class Users_MotDePasseOublie_POSTHandler : MessageHandler<Users_MotDePasseOublie_POST, Void>
    {
        private readonly IEmailSender emailSender;
        private readonly IRepository repository;
        private readonly IClock clock;

        public Users_MotDePasseOublie_POSTHandler(
            IEmailSender emailSender,
            IRepository repository,
            IClock clock)
        {
            this.emailSender = emailSender;
            this.repository = repository;
            this.clock = clock;
        }
        public async override Task<Void> ExecuteAsync(Users_MotDePasseOublie_POST query)
        {
            var token = new TokenMotDePasseOublie()
            {
                Id = Guid.NewGuid(),
                Email = query.Email,
                Utilise = false,
                DateExpiration = clock.Now.AddHours(1)
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