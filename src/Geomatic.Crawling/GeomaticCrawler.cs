using System.Collections.Generic;
using CluedIn.Core.Crawling;
using CluedIn.Crawling.Geomatic.Core;
using CluedIn.Crawling.Geomatic.Infrastructure.Factories;
using CluedIn.Crawling.Geometic.Core.Models;

namespace CluedIn.Crawling.Geomatic
{
    public class GeomaticCrawler : ICrawlerDataGenerator
    {
        private readonly IGeomaticClientFactory clientFactory;
        public GeomaticCrawler(IGeomaticClientFactory clientFactory)
        {
            this.clientFactory = clientFactory;
        }

        public IEnumerable<object> GetData(CrawlJobData jobData)
        {
            if (!(jobData is GeomaticCrawlJobData geomaticcrawlJobData))
            {
                yield break;
            }

            var client = clientFactory.CreateNew(geomaticcrawlJobData);

            foreach (var item in client.Get(geomaticcrawlJobData.FilePath))
            {
                if (!string.IsNullOrEmpty(item.KUNLOEB))
                {
                    yield return item;
                }
            }
        }
    }
}
