using System;
using System.Threading.Tasks;

namespace CocoriCore.Page
{
    public class UserFluent
    {
        public string Id;
        private readonly BrowserFluent browserFluent;
        private readonly MailFluent mailFluent;

        public UserFluent(
            IUserLogger userLogger,
            IBrowser browser,
            IEmailReader emailReader)
        {
            this.browserFluent = new BrowserFluent(userLogger, browser);
            this.mailFluent = new MailFluent(this, userLogger, emailReader);
        }

        public UserFluent SetId(string id)
        {
            this.browserFluent.SetId(id);
            this.mailFluent.SetId(id);
            return this;
        }

        public BrowserFluent<T> Display<T>(IMessage<T> message)
        {
            return browserFluent.Display(message);
        }

        public async Task<MailFluentMessage<T>> ReadEmail<T>(string emailAddress)
        {
            return await mailFluent.Read<T>(emailAddress);
        }
    }
}
