using System;
using System.Threading.Tasks;
using CocoriCore;
using CocoriCore.Ninject;
using CocoriCore.Page;
using Ninject;
using Ninject.Extensions.ContextPreservation;
using Ninject.Extensions.NamedScope;

namespace CocoriCore.LeBonCoin
{
    public class TestBase
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
            kernel.Bind<HandlerFinder>().ToConstant(new HandlerFinder(CocoriCore.Page.AssemblyInfo.Assembly, CocoriCore.LeBonCoin.AssemblyInfo.Assembly)).InSingletonScope();
            kernel.Bind<IMessageBus>().To<CocoriCore.LeBonCoin.MessageBus>().InNamedScope("unitofwork");
            kernel.Bind<IExecuteHandler>().To<ExecuteHandler>().InNamedScope("unitofwork");

            kernel.Bind<IEmailReader, IEmailSender>().To<EmailSenderAndReader>().InSingletonScope();

            // claims
            kernel.Bind<TestBrowserClaimsProvider>().ToConstant(new TestBrowserClaimsProvider(response =>
            {
                if (response is Users_Connexion_POSTResponse r)
                    return r.Claims;
                if (response is Users_Connexion_Page_FormConnexion_POSTResponse r2)
                    return r2.Claims;
                if (response is Users_Inscription_POSTResponse i)
                    return i.Claims;
                if (response is Users_Inscription_Page.FormInscriptionResponse i2)
                    return i2.Claims;
                return null;
            }));
            kernel.Bind<IClaimsProvider, IClaimsWriter>().To<ClaimsProviderAndWriter>().InNamedScope("unitofwork");


            kernel.Bind<BrowserHistory>().ToSelf().InSingletonScope();

        }

        public TestBrowserFluent<Accueil_Page> CreateUser(string id)
        {
            return kernel.Get<TestBrowserFluent<int>>().SetId(id).Display(new Accueil_Page_GET());
        }

        public IEmailReader GetEmailReader()
        {
            return kernel.Get<IEmailReader>();
        }

        public BrowserHistory GetHistory()
        {
            return kernel.Get<BrowserHistory>();
        }
    }
}
