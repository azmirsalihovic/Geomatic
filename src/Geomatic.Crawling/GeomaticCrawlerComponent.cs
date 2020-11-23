using CluedIn.Core;
using CluedIn.Crawling.Geomatic.Core;

using ComponentHost;

namespace CluedIn.Crawling.Geomatic
{
    [Component(GeomaticConstants.CrawlerComponentName, "Crawlers", ComponentType.Service, Components.Server, Components.ContentExtractors, Isolation = ComponentIsolation.NotIsolated)]
    public class GeomaticCrawlerComponent : CrawlerComponentBase
    {
        public GeomaticCrawlerComponent([NotNull] ComponentInfo componentInfo)
            : base(componentInfo)
        {
        }
    }
}

