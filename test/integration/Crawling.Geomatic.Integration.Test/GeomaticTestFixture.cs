using System.IO;
using System.Reflection;
using Castle.MicroKernel.Registration;
using CluedIn.Crawling.Geomatic.Core;
using CrawlerIntegrationTesting.Clues;
using Xunit.Abstractions;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using DebugCrawlerHost = CrawlerIntegrationTesting.CrawlerHost.DebugCrawlerHost<CluedIn.Crawling.Geomatic.Core.GeomaticCrawlJobData>;
using System.Collections.Generic;
using CluedIn.Core.Data;

namespace CluedIn.Crawling.Geomatic.Integration.Test
{
    public class GeomaticTestFixture
    {
        public List<string> Entities = new List<string>();
        public ClueStorage ClueStorage { get; }
        private readonly DebugCrawlerHost debugCrawlerHost;

        public ILogger<GeomaticTestFixture> Log { get; }

        public GeomaticTestFixture()
        {
            var executingFolder = new FileInfo(Assembly.GetExecutingAssembly().CodeBase.Substring(8)).DirectoryName;
            debugCrawlerHost = new DebugCrawlerHost(executingFolder, GeomaticConstants.ProviderName, c => {
                c.Register(Component.For<ILogger>().UsingFactoryMethod(_ => NullLogger.Instance).LifestyleSingleton());
                c.Register(Component.For<ILoggerFactory>().UsingFactoryMethod(_ => NullLoggerFactory.Instance).LifestyleSingleton());
            });

            ClueStorage = new ClueStorage();

            Log = debugCrawlerHost.AppContext.Container.Resolve<ILogger<GeomaticTestFixture>>();

            //debugCrawlerHost.ProcessClue += ClueStorage.AddClue;

            debugCrawlerHost.ProcessClue += AddClueCount;

            debugCrawlerHost.Execute(GeomaticConfiguration.Create(), GeomaticConstants.ProviderId);
        }

        private void AddClueCount(Clue clue)
        {
            Entities.Add(clue.OriginEntityCode.Type.Code);
        }

        public void PrintClues(ITestOutputHelper output)
        {
            foreach(var clue in ClueStorage.Clues)
            {
                output.WriteLine(clue.OriginEntityCode.ToString());
            }
        }

        public void PrintLogs(ITestOutputHelper output)
        {
            //TODO:
            //output.WriteLine(Log.PrintLogs());
        }

        public void Dispose()
        {
        }

    }
}


