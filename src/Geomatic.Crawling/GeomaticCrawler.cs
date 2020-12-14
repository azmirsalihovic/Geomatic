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
                    //yield return item;
                    if (string.IsNullOrEmpty(item.CVRNUM))
                    {
                        var user = new PrivateCustomer();
                        foreach (var property in user.GetType().GetProperties())
                        {
                            property.SetValue(user, item.GetType().GetProperty(property.Name).GetValue(item));
                        }
                        yield return user;
                        //yield return item;
                    }
                    else
                    {
                        var organization = new BusinessCustomer();
                        foreach (var property in organization.GetType().GetProperties())
                        {
                            property.SetValue(organization, item.GetType().GetProperty(property.Name).GetValue(item));
                        }
                        yield return organization;
                    }
                }
            }
        }
    }
}
