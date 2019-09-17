using System.Threading.Tasks;
using CocoriCore;
using CocoriCore.Ninject;
using CocoriCore.Page;
using CocoriCore.Router;
using Ninject;
using Ninject.Extensions.ContextPreservation;
using Ninject.Extensions.NamedScope;

namespace LeBonCoin
{
    public class TestBase// : IDisposable
    {
        private StandardKernel kernel;

        public TestBase()
        {
            kernel = new StandardKernel();
            kernel.Load(new NamedScopeModule());
            kernel.Load(new ContextPreservationModule());
            kernel.Load(new CocoricoreNinjectModule());
            kernel.Bind<IHashService>().To<HashService>().InSingletonScope();

            // Repository
            kernel.Bind<IUIDProvider>().To<UIDProvider>().InSingletonScope();
            kernel.Bind<IInMemoryEntityStore>().To<InMemoryEntityStore>().InSingletonScope();
            kernel.Bind<IRepository>().To<MemoryRepository>().InNamedScope("unitofwork");

            // messagebus
            kernel.Bind<HandlerFinder>().ToConstant(new HandlerFinder(CocoriCore.Page.AssemblyInfo.Assembly, LeBonCoin.AssemblyInfo.Assembly)).InSingletonScope();
            kernel.Bind<IMessageBus>().To<LeBonCoin.MessageBus>().InNamedScope("unitofwork");
            kernel.Bind<IExecuteHandler>().To<ExecuteHandler>().InNamedScope("unitofwork");

            kernel.Bind<IEmailReader, IEmailSender>().To<TestEmailSenderAndReader>().InSingletonScope();

            // claims
            kernel.Bind<TestBrowserClaimsProvider>().ToConstant(new TestBrowserClaimsProvider(response =>
            {
                if (response is IClaimsResponse claimsResponse)
                    return claimsResponse.GetClaims();
                return null;
            }));
            kernel.Bind<IClaimsProvider, IClaimsWriter>().To<ClaimsProviderAndWriter>().InNamedScope("unitofwork");
            kernel.Bind<IUserLogger, TestLogger>().To<TestLogger>().InSingletonScope();

            kernel.Bind<IPageMapper>().ToConstant(new PageMapper(LeBonCoin.AssemblyInfo.Assembly));

            kernel.Bind<IBrowser>().To<TestBrowser>();
        }

        public void WithSeleniumBrowser(RouterOptions routerOptions)
        {
            kernel.Bind<RouterOptions>().ToConstant(routerOptions);
            kernel.Rebind<IBrowser>().To<SeleniumBrowser>();
        }

        public BrowserFluent<Accueil_Page> CreateBrowser(string id)
        {
            return kernel.Get<BrowserFluent<int>>().SetId(id).Display(new Accueil_Page_GET());
        }

        public UserFluent CreateUser(string id)
        {
            return kernel.Get<UserFluent>().SetId(id);
        }

        public object[] GetLogs()
        {
            return kernel.Get<TestLogger>().Logs.ToArray();
        }
        /*
        public void Dispose()
        {
            kernel.Dispose();
            //driver.Dispose();
        }
        */
    }
}
