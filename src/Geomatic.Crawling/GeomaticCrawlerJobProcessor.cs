using CluedIn.Crawling.Geomatic.Core;

namespace CluedIn.Crawling.Geomatic
{
    public class GeomaticCrawlerJobProcessor : GenericCrawlerTemplateJobProcessor<GeomaticCrawlJobData>
    {
        public GeomaticCrawlerJobProcessor(GeomaticCrawlerComponent component) : base(component)
        {
        }
    }
}
