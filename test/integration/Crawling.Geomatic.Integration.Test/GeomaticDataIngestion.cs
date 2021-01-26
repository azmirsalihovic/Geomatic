using System.Linq;
using CrawlerIntegrationTesting.Clues;
using Xunit;
using Xunit.Abstractions;

namespace CluedIn.Crawling.Geomatic.Integration.Test
{
    public class DataIngestion : IClassFixture<GeomaticTestFixture>
    {
        private readonly GeomaticTestFixture fixture;
        private readonly ITestOutputHelper output;

        public DataIngestion(GeomaticTestFixture fixture, ITestOutputHelper output)
        {
            this.fixture = fixture;
            this.output = output;
        }

        [Theory]
        [InlineData("/Provider/Root", 1)]
        [InlineData("/Organization", 231539)] //231539
        [InlineData("/Infrastructure/User", 1781577)] //1781577
        //TODO: Add details for the count of entityTypes your test produces
        //[InlineData("SOME_ENTITY_TYPE", 1)]
        public void CorrectNumberOfEntityTypes(string entityType, int expectedCount)
        {
            //var foundCount = fixture.ClueStorage.CountOfType(entityType);
            var foundCount = fixture.Entities.Count(x => x == entityType);

            //You could use this method to output the logs inside the test case
            fixture.PrintLogs(output);

            //Assert.Equal(expectedCount, foundCount);
            Assert.True(expectedCount <= foundCount);
        }

        [Fact]
        public void EntityCodesAreUnique()
        {
            var count = fixture.ClueStorage.Clues.Count();
            var unique = fixture.ClueStorage.Clues.Distinct(new ClueComparer()).Count();

            //You could use this method to output info of all clues
            fixture.PrintClues(output);

            Assert.Equal(unique, count);
        }

       
    }
}
