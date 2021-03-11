using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using CluedIn.Core.Crawling;
using CluedIn.Crawling.Geomatic.Core;
using CluedIn.Crawling.Geomatic.Infrastructure.Factories;
using CluedIn.Crawling.Geometic.Core.Models;
using static CluedIn.Crawling.Geomatic.Infrastructure.GeomaticClient;

namespace CluedIn.Crawling.Geomatic
{
    public class GeomaticCrawler : ICrawlerDataGenerator
    {
        private readonly IGeomaticClientFactory clientFactory;
        private readonly string filePathOutput = @"C:\Users\asa\OneDrive - Kapacity AS\Projekter\SEMLER\GeomaticData\TestCustomersOutput.csv";
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

            if (createCSVFile)
            {
                GetCSVOutput(client, geomaticcrawlJobData.FilePath, geomaticcrawlJobData.FilePath1);
            }
            else
            {
                foreach (var item in client.Get(geomaticcrawlJobData.FilePath))
                {
                    if (!string.IsNullOrEmpty(item.KUNLOEB))
                    {
                        yield return item;
                    }
                }
            }
        }

        private void GetCSVOutput(Infrastructure.GeomaticClient client, string filePath, string filePath1)
        {
            var customerListFull = client.GetKunloebIDList(filePath1);
            var customerListCombined = new List<Customers>();

            foreach (var item in client.Get(filePath))
            {
                if (createCSVFile)
                {
                    var containsItem = customerListFull.Any(items => items.KUKCustomerID == item.KUNLOEB);

                    if (containsItem)
                    {
                        customerListCombined.Add(new Customers
                        {
                            KUKCustomerID = item.KUNLOEB,
                            Match = "Y"
                        });
                    }
                    else
                    {
                        customerListCombined.Add(new Customers
                        {
                            KUKCustomerID = item.KUNLOEB,
                            Match = "N"
                        });
                    }
                }
            }

            try
            {
                //Clear CSV file
                File.WriteAllText(filePathOutput, "");

                //Build output to a CSV file
                var csv = new StringBuilder();
                var header = string.Format("{0};{1}", "KUKCustomerID", "Match");
                csv.AppendLine(header);

                foreach (var item in customerListCombined)
                {
                    var newLine = string.Format("{0};{1}", item.KUKCustomerID, item.Match);
                    csv.AppendLine(newLine);
                }

                File.WriteAllText(filePathOutput, csv.ToString());
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
