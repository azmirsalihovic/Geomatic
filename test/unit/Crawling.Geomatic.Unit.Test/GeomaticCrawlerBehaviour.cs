using CluedIn.Core.Crawling;
using CluedIn.Crawling;
using CluedIn.Crawling.Geomatic;
using CluedIn.Crawling.Geomatic.Infrastructure.Factories;
using Moq;
using Shouldly;
using Xunit;

namespace Crawling.Geomatic.Unit.Test
{
    public class GeomaticCrawlerBehaviour
    {
        private readonly ICrawlerDataGenerator _sut;

        public GeomaticCrawlerBehaviour()
        {
            var nameClientFactory = new Mock<IGeomaticClientFactory>();

            _sut = new GeomaticCrawler(nameClientFactory.Object);
        }

        [Fact]
        public void GetDataReturnsData()
        {
            var jobData = new CrawlJobData();

            _sut.GetData(jobData)
                .ShouldNotBeNull();
        }
    }
}
