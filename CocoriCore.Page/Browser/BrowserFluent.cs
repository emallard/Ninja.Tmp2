using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using CocoriCore;
using CocoriCore.Page;

namespace CocoriCore.LeBonCoin
{
    public class BrowserFluent<TPage>
    {
        public readonly BrowserHistory history;
        public readonly IBrowser browser;
        public TPage Page;
        public string Id;

        public BrowserFluent(BrowserHistory history, IBrowser browser)
        {
            this.history = history;
            this.browser = browser;
        }

        public BrowserFluent<TPage> SetId(string id)
        {
            Id = id;
            return this;
        }

        public BrowserFluent<TPage> SetPageAndId(TPage page, string id)
        {
            Page = page;
            Id = id;
            return this;
        }

        public BrowserFluent<T> Follow<T>(Expression<Func<TPage, IMessage<T>>> expressionMessage)
        {
            var body = (MemberExpression)expressionMessage.Body;
            var memberInfo = body.Member;

            if (browser is TestBrowser) // TODO dans le cas de selenium, page == null
            {
                var func = expressionMessage.Compile();
                var message = func(Page);
                this.history.Event(this.Id, HistoryEventType.Follow, message);
            }
            var nextPage = this.browser.Follow(Page, expressionMessage).Result;
            return new BrowserFluent<T>(history, browser).SetPageAndId(nextPage, Id);
        }

        public BrowserFluent<T> Display<T>(IMessage<T> message)
        {
            this.history.Event(this.Id, HistoryEventType.Display, message);
            var nextPage = this.browser.Display(message).Result;
            return new BrowserFluent<T>(history, browser).SetPageAndId(nextPage, Id);
        }

        public BrowserFluent<TPageTo> Play<TPageTo>(IScenario<TPage, TPageTo> scenario)
        {
            return scenario.Play(this);
        }

        public TestBrowserFluentSubmitted<TPage, TFormResponse> Submit<TMessage, TFormResponse>(
            Expression<Func<TPage, Form<TMessage, TFormResponse>>> getForm,
            Action<TMessage> modifyMessage
        )
            where TMessage : IMessage, new()
        {
            var command = new TMessage();
            modifyMessage(command);
            var formResponse = browser.Submit(Page, getForm, command).Result;
            return new TestBrowserFluentSubmitted<TPage, TFormResponse>(this, formResponse);
        }
    }


    public class TestBrowserFluentSubmitted<TPage, TPostResponse>
    {
        private readonly BrowserFluent<TPage> browserFluent;
        private readonly TPostResponse postResponse;

        public TestBrowserFluentSubmitted(
            BrowserFluent<TPage> browserFluent,
            TPostResponse postResponse)
        {
            this.browserFluent = browserFluent;
            this.postResponse = postResponse;
        }

        public BrowserFluent<T> ThenFollow<T>(Func<TPostResponse, IMessage<T>> getMessage)
        {
            // TODO difference TestBrowser / SeleniumBrowser
            if (browserFluent.browser is TestBrowser)
            {
                var message = getMessage(postResponse);
                this.browserFluent.history.Event(this.browserFluent.Id, HistoryEventType.FormRedirect, message);
                var page = browserFluent.browser.SubmitRedirect(message).Result;
                return new BrowserFluent<T>(this.browserFluent.history, this.browserFluent.browser).SetPageAndId(page, this.browserFluent.Id);
            }
            else
            {
                var page = browserFluent.browser.SubmitRedirect((IMessage<T>)null).Result;
                return new BrowserFluent<T>(this.browserFluent.history, this.browserFluent.browser).SetPageAndId(page, this.browserFluent.Id);
            }
        }
    }
}
