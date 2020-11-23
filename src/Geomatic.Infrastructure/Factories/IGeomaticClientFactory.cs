using CluedIn.Crawling.Geomatic.Core;

namespace CluedIn.Crawling.Geomatic.Infrastructure.Factories
{
    public interface IGeomaticClientFactory
    {
        GeomaticClient CreateNew(GeomaticCrawlJobData geomaticCrawlJobData);
    }
}
