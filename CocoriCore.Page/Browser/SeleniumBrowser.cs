using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using CocoriCore;
using CocoriCore.Router;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace CocoriCore.Page
{

    public class SeleniumBrowser : IBrowser, IDisposable
    {
        private readonly RouteToUrl routeToUrl;
        public IWebDriver driver;
        public SeleniumBrowser(RouteToUrl routeToUrl)
        {
            driver = new FirefoxDriver();
            this.routeToUrl = routeToUrl;
        }
        public async Task<T> Display<T>(IMessage<T> message)
        {
            await Task.CompletedTask;
            var url = "http://localhost:5000" + routeToUrl.ToUrl(message);
            url = url.Replace("/api", "/");
            driver.Navigate().GoToUrl(url);

            return default(T);
        }

        public async Task<T> Follow<TPage, T>(TPage page, Expression<Func<TPage, IMessage<T>>> expressionMessage)
        {
            await Task.CompletedTask;
            var body = (MemberExpression)expressionMessage.Body;
            var memberInfo = body.Member;

            driver.FindElement(By.Id(memberInfo.Name)).Click();

            return DeserializePage<T>();
        }

        public Task<T> SubmitRedirect<T>(IMessage<T> message)
        {
            throw new System.NotImplementedException();
        }

        public T DeserializePage<T>()
        {
            return default(T);
        }

        public void Dispose()
        {
            //driver.Dispose();
        }
    }
}