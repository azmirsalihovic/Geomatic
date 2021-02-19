using System.Collections.Generic;
using System.IO;
using System.Text;
using CluedIn.Core.Crawling;
using CluedIn.Crawling.Geomatic.Core;
using CluedIn.Crawling.Geomatic.Infrastructure.Factories;
using CluedIn.Crawling.Geometic.Core.Models;

namespace CluedIn.Crawling.Geomatic
{
    public class GeomaticCrawler : ICrawlerDataGenerator
    {
        private readonly IGeomaticClientFactory clientFactory;
        private readonly string FilePath = @"C:\Users\asa\OneDrive - Kapacity AS\Projekter\SEMLER\GeomaticData\TestCustomersOutput.csv";
        private readonly bool createCSVFile = false;
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

            //Get the list with customer id's from CSV file
            var KunloebIDList = client.GetKunloebIDList(geomaticcrawlJobData.FilePath1);
            List<Customers> customerList = new List<Customers>();

            foreach (var item in client.Get(geomaticcrawlJobData.FilePath))
            {
                if (!string.IsNullOrEmpty(item.KUNLOEB))
                {
                    if (KunloebIDList != null)
                    {
                        if (KunloebIDList.Contains(item.KUNLOEB) || KunloebIDList.Count == 0)
                        {
                            if (createCSVFile)
                            {
                                customerList.Add(new Customers
                                {
                                    KUKCustomerID = item.KUNLOEB,
                                    Match = "Y"
                                });
                            }
                            yield return item;
                        }
                    }
                    else
                        yield return item;
                }
            }

            if (createCSVFile)
            {
                //Build output to a CSV file
                var csv = new StringBuilder();
                var header = string.Format("{0};{1}", "KUKCustomerID", "Match");
                csv.AppendLine(header);

                foreach (Customers item in customerList)
                {
                    var newLine = string.Format("{0};{1}", item.KUKCustomerID, item.Match);
                    csv.AppendLine(newLine);
                }

                File.Create(FilePath);
                File.WriteAllText(FilePath, csv.ToString());
            }
        }

        public class Customers
        {
            public string KUKCustomerID { get; set; }
            public string Match { get; set; }

            public override string ToString()
            {
                return string.Format("KUKCustomerID {0}; Match {1}", KUKCustomerID, Match);
            }
        }
    }
}
