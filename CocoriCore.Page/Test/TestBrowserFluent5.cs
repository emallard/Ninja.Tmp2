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
        public IMessage<TPage> PageGet;
        public TPage Page;
        public string Id;

        public TestBrowserFluent(BrowserHistory history, TestBrowser browser)
        {
            this.history = history;
            this.browser = browser;
        }

        public TestBrowserFluent<TPage> SetId(string id)
        {
            Id = id;
            return this;
        }

        public TestBrowserFluent<TPage> SetPageAndId(IMessage<TPage> pageGet, TPage page, string id)
        {
            PageGet = pageGet;
            Page = page;
            Id = id;
            return this;
        }

        public TestBrowserFluent<T> Follow<T>(Func<TPage, IMessage<T>> a)
        {
            var message = a(Page);
            this.history.Event(this.Id, HistoryEventType.Follow, message);
            var nextPage = this.browser.Follow(Page, message).Result;
            return new TestBrowserFluent<T>(history, browser).SetPageAndId(message, nextPage, Id);
        }

        public TestBrowserFluent<T> Display<T>(IMessage<T> message)
        {
            this.history.Event(this.Id, HistoryEventType.Display, message);
            var nextPage = this.browser.Display(message).Result;
            return new TestBrowserFluent<T>(history, browser).SetPageAndId(message, nextPage, Id);
        }


        public TestBrowserFluent<TPageTo> Play<TPageTo>(IScenario<TPage, TPageTo> scenario)
        {
            return scenario.Play(this);
        }

        public T Submit<T>(Func<TPage, IMessage<T>> message)
        {
            var m = message(Page);
            //this.history.Event(this.Id, HistoryEventType.Display, message);
            return this.browser.Display(m).Result;
        }


        public TestBrowserFluentSubmitted<TPage, TFormResponse> Submit<TPageGet, TMessage, TMessageResponse, TFormResponse>(
            Func<TPage, PageCall<TPageGet, TMessage, TMessageResponse, TFormResponse>> getForm,
            Action<TMessage> modifyMessage
        )
            where TPageGet : IMessage
        {
            var form = getForm(Page);
            modifyMessage(form.Message);

            /*
            var formMessage = new PageCallMessage<TPageGet, TMessage, TMessageResponse, TFormResponse>()
            {
                PageGet = this.PageGet,
                Message = form.Message,
                PageMember = getForm
            };*/

            var formResponse = browser.Display(form).Result;
            return new TestBrowserFluentSubmitted<TPage, TFormResponse>(this, formResponse);
        }

        public TestBrowserFluentSubmitted<TPage, TFormResponse> Submit<TMessage, TFormResponse>(
            Func<TPage, Form<TMessage, TFormResponse>> getForm,
            Action<TMessage> modifyMessage
        )
            where TMessage : IMessage, new()
        {
            var form = getForm(Page);
            modifyMessage(form.Command);
            var formResponse = browser.Display(form).Result;
            return new TestBrowserFluentSubmitted<TPage, TFormResponse>(this, formResponse);
        }
    }


    public class TestBrowserFluentSubmitted<TPage, TPostResponse>
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
            return new TestBrowserFluent<T>(this.browserFluent.history, this.browserFluent.browser).SetPageAndId(message, page, this.browserFluent.Id);
        }
    }
}
