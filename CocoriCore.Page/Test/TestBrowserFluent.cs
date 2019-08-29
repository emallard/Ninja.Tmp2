using System;
using System.Threading.Tasks;
using CocoriCore;
using CocoriCore.Page;

namespace CocoriCore.LeBonCoin
{

    public class TestBrowserFluentState
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

    public class TestBrowserFluent<TPage>
    {
        public readonly BrowserHistory history;
        public readonly TestBrowser browser;
        public TPage Page;
        public string Id;

        public TestBrowserFluent(BrowserHistory history, TestBrowser browser)
        {
            this.history = history;
            this.browser = browser;
        }

        public TestBrowserFluent<TPage> SetPageAndId(TPage page, string id)
        {
            Page = page;
            Id = id;
            return this;
        }

        public TestBrowserFluent<T> Follow<T>(Func<TPage, IMessage<T>> a)
        {
            var message = a(Page);
            this.history.Event(this.Id, HistoryEventType.Follow, message);
            var nextPage = this.browser.Follow(Page, message).Result;
            return new TestBrowserFluent<T>(history, browser).SetPageAndId(nextPage, Id);
        }

        public TestBrowserFluent<T> Display<T>(IMessage<T> message)
        {
            this.history.Event(this.Id, HistoryEventType.Display, message);
            var nextPage = this.browser.Display(message).Result;
            return new TestBrowserFluent<T>(history, browser).SetPageAndId(nextPage, Id);
        }

        public TestBrowserFluentForm<TPage, TPost, TPostResponse> GetForm<TPost, TPostResponse>(
            Func<TPage, Form<TPost, TPostResponse>> form)
            where TPost : IMessage<TPostResponse>
        {
            return new TestBrowserFluentForm<TPage, TPost, TPostResponse>(this, form(Page));
        }

        public TestBrowserFluent<TPageTo> Play<TPageTo>(IScenario<TPage, TPageTo> scenario)
        {
            return scenario.Play(this);
        }
    }

    public class TestBrowserFluentForm<TPage, TPost, TPostResponse> where TPost : IMessage<TPostResponse>
    {
        private readonly TestBrowserFluent<TPage> browserFluent;
        private readonly Form<TPost, TPostResponse> form;

        public TestBrowserFluentForm(TestBrowserFluent<TPage> browserFluent, Form<TPost, TPostResponse> form)
        {
            this.browserFluent = browserFluent;
            this.form = form;
        }

        public TestBrowserFluentSubmitted<TPage, TPost, TPostResponse> Submit(TPost post)
        {
            this.browserFluent.history.Event(this.browserFluent.Id, HistoryEventType.Submit, post);

            var postResponse = this.browserFluent.browser.Submit(this.browserFluent.Page, form, post).Result;
            return new TestBrowserFluentSubmitted<TPage, TPost, TPostResponse>(this.browserFluent, postResponse);
        }
    }

    public class TestBrowserFluentSubmitted<TPage, TPost, TPostResponse> where TPost : IMessage<TPostResponse>
    {
        private readonly TestBrowserFluent<TPage> browserFluent;
        private readonly TPostResponse postResponse;

        public TestBrowserFluentSubmitted(
            TestBrowserFluent<TPage> browserFluent,
            TPostResponse postResponse)
        {
            this.browserFluent = browserFluent;
            this.postResponse = postResponse;
        }
        public TestBrowserFluent<T> ThenFollow<T>(Func<TPostResponse, IMessage<T>> getMessage)
        {
            var message = getMessage(postResponse);
            this.browserFluent.history.Event(this.browserFluent.Id, HistoryEventType.FormRedirect, message);
            var page = browserFluent.browser.SubmitRedirect(message).Result;
            return new TestBrowserFluent<T>(this.browserFluent.history, this.browserFluent.browser).SetPageAndId(page, this.browserFluent.Id);
        }

    }
}
