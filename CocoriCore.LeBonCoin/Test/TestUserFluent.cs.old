using System;
using System.Threading.Tasks;
using CocoriCore;
using CocoriCore.Page;

namespace CocoriCore.LeBonCoin
{
    public class TestUserFluent<TPage>
    {
        private readonly TestBrowser browser;
        public readonly TPage Page;

        public TestUserFluent(TestBrowser browser, TPage current)
        {
            this.browser = browser;
            Page = current;
        }



        public async Task<TestUserFluent<T>> Click<T>(Func<TPage, IMessage<T>> a)
        {
            var nextPage = await this.browser.Display(a(Page));
            return new TestUserFluent<T>(browser, nextPage);
        }

        public async Task<TestUserFluent<T>> Display<T>(IMessage<T> message)
        {
            /*var t = this.browser.Display(message));
            Task.WaitAll(t);
            var nextPage = t.Result;*/
            var nextPage = await this.browser.Display(message);
            return new TestUserFluent<T>(browser, nextPage);
        }

        /*
        public async Task<TPage> Submit<TPost, TPostResponse, TPage>(Form<TPost, TPostResponse, TPage> submit, TPost post) where TPost : IMessage<TPostResponse> where TPage : IPage
        {
            return await this.browser.Submit(submit, post);
        }*/

        public TestUserFluentBrowerForm<TPost, TPostResponse> GetForm<TPost, TPostResponse>(
            Func<TPage, Form<TPost, TPostResponse>> form)
            where TPost : IMessage<TPostResponse>
        {
            return new TestUserFluentBrowerForm<TPost, TPostResponse>(this.browser.GetForm(form(Page)));
        }
    }

    public class TestUserFluentBrowerForm<TPost, TPostResponse> where TPost : IMessage<TPostResponse>
    {
        private readonly BrowserForm<TPost, TPostResponse> browserForm;

        public TestUserFluentBrowerForm(BrowserForm<TPost, TPostResponse> browserForm)
        {
            this.browserForm = browserForm;
        }

        public async Task<TestUserFluent<T>> Follow<T>(TPost post, Func<TPostResponse, IMessage<T>> getMessage)
        {
            var page = await this.browserForm.Follow(post, getMessage);
            return new TestUserFluent<T>(this.browserForm.testBrowser, page);
        }
    }
}
