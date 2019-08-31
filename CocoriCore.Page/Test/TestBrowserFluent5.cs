using System;
using System.Threading.Tasks;
using CocoriCore;
using CocoriCore.Page;

namespace CocoriCore.LeBonCoin
{

    public class TestBrowserFluent5State
    {
        public string Id;
        public string AuthenticationCookie;
        public Action<object> OnResponse;/*= (o) =>
        {
            if (o is Users_Connexion_POSTResponse)
            {

            }
        }*/
    }

    public class TestBrowserFluent5<TPage>
    {
        public readonly BrowserHistory history;
        public readonly TestBrowser browser;
        public IMessage<TPage> PageGet;
        public TPage Page;
        public string Id;

        public TestBrowserFluent5(BrowserHistory history, TestBrowser browser)
        {
            this.history = history;
            this.browser = browser;
        }

        public TestBrowserFluent5<TPage> SetPageAndId(IMessage<TPage> pageGet, TPage page, string id)
        {
            PageGet = pageGet;
            Page = page;
            Id = id;
            return this;
        }

        public TestBrowserFluent5<T> Follow<T>(Func<TPage, IMessage<T>> a)
        {
            var message = a(Page);
            this.history.Event(this.Id, HistoryEventType.Follow, message);
            var nextPage = this.browser.Follow(Page, message).Result;
            return new TestBrowserFluent5<T>(history, browser).SetPageAndId(message, nextPage, Id);
        }

        public TestBrowserFluent5<T> Display<T>(IMessage<T> message)
        {
            this.history.Event(this.Id, HistoryEventType.Display, message);
            var nextPage = this.browser.Display(message).Result;
            return new TestBrowserFluent5<T>(history, browser).SetPageAndId(message, nextPage, Id);
        }


        public TestBrowserFluent5<TPageTo> Play<TPageTo>(IScenario<TPage, TPageTo> scenario)
        {
            throw new NotImplementedException();
            //return scenario.Play(this);
        }

        public TestBrowserFluent5Submitted<TPage, TFormResponse> Submit<TMessage, TMessageResponse, TFormResponse>(
            Func<TPage, Form5<TMessage, TMessageResponse, TFormResponse>> form,
            TMessage message
        )
        {
            var formMessage = new PageFormMessage5<TPage, TMessage, TMessageResponse, TFormResponse>()
            {
                PageGet = this.PageGet,
                Message = message,
                Form = form
            };

            var formResponse = browser.Display(formMessage).Result;
            return new TestBrowserFluent5Submitted<TPage, TFormResponse>(this, formResponse);
        }
    }


    public class TestBrowserFluent5Submitted<TPage, TPostResponse>
    {
        private readonly TestBrowserFluent5<TPage> browserFluent;
        private readonly TPostResponse postResponse;

        public TestBrowserFluent5Submitted(
            TestBrowserFluent5<TPage> browserFluent,
            TPostResponse postResponse)
        {
            this.browserFluent = browserFluent;
            this.postResponse = postResponse;
        }
        public TestBrowserFluent5<T> ThenFollow<T>(Func<TPostResponse, IMessage<T>> getMessage)
        {
            var message = getMessage(postResponse);
            this.browserFluent.history.Event(this.browserFluent.Id, HistoryEventType.FormRedirect, message);
            var page = browserFluent.browser.SubmitRedirect(message).Result;
            return new TestBrowserFluent5<T>(this.browserFluent.history, this.browserFluent.browser).SetPageAndId(message, page, this.browserFluent.Id);
        }
    }
}
