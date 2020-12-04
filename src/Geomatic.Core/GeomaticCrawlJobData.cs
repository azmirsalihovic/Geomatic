using CluedIn.Core.Crawling;

namespace CluedIn.Crawling.Geomatic.Core
{
    public class GeomaticCrawlJobData : CrawlJobData
    {
        public string ApiKey { get; set; }
        public string FilePath { get; set; }
    }
}
