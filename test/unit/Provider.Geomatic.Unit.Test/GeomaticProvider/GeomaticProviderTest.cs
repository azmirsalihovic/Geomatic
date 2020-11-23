using Castle.Windsor;
using CluedIn.Core;
using CluedIn.Core.Providers;
using CluedIn.Crawling.Geomatic.Infrastructure.Factories;
using Moq;

namespace CluedIn.Provider.Geomatic.Unit.Test.GeomaticProvider
{
    public abstract class GeomaticProviderTest
    {
        protected readonly ProviderBase Sut;

        protected Mock<IGeomaticClientFactory> NameClientFactory;
        protected Mock<IWindsorContainer> Container;

        protected GeomaticProviderTest()
        {
            Container = new Mock<IWindsorContainer>();
            NameClientFactory = new Mock<IGeomaticClientFactory>();
            var applicationContext = new ApplicationContext(Container.Object);
            Sut = new Geomatic.GeomaticProvider(applicationContext, NameClientFactory.Object);
        }
    }
}
