using System;
using System.Net;
using System.Threading.Tasks;
using CluedIn.Core.Providers;
using CluedIn.Crawling.Geomatic.Core;
using Newtonsoft.Json;
using RestSharp;
using Microsoft.Extensions.Logging;
using System.Collections;
using CluedIn.Crawling.Geometic.Core.Models;
using System.Collections.Generic;
using Microsoft.VisualBasic.FileIO;

namespace CluedIn.Crawling.Geomatic.Infrastructure
{
    // TODO - This class should act as a client to retrieve the data to be crawled.
    // It should provide the appropriate methods to get the data
    // according to the type of data source (e.g. for AD, GetUsers, GetRoles, etc.)
    // It can receive a IRestClient as a dependency to talk to a RestAPI endpoint.
    // This class should not contain crawling logic (i.e. in which order things are retrieved)
    public class GeomaticClient
    {
        private const string BaseUri = "http://sample.com";
        private readonly ILogger<GeomaticClient> log;
        private readonly IRestClient client;

        public GeomaticClient(ILogger<GeomaticClient> log, GeomaticCrawlJobData geomaticCrawlJobData, IRestClient client) // TODO: pass on any extra dependencies
        {
            if (geomaticCrawlJobData == null)
            {
                throw new ArgumentNullException(nameof(geomaticCrawlJobData));
            }

            if (client == null)
            {
                throw new ArgumentNullException(nameof(client));
            }

            this.log = log ?? throw new ArgumentNullException(nameof(log));
            this.client = client ?? throw new ArgumentNullException(nameof(client));

            // TODO use info from geomaticCrawlJobData to instantiate the connection
            client.BaseUrl = new Uri(BaseUri);
            client.AddDefaultParameter("api_key", geomaticCrawlJobData.ApiKey, ParameterType.QueryString);
        }

        private async Task<T> GetAsync<T>(string url)
        {
            var request = new RestRequest(url, Method.GET);

            var response = await client.ExecuteAsync(request, request.Method);

            if (response.StatusCode != HttpStatusCode.OK)
            {
                var diagnosticMessage = $"Request to {client.BaseUrl}{url} failed, response {response.ErrorMessage} ({response.StatusCode})";
                log.LogError(diagnosticMessage);
                throw new InvalidOperationException($"Communication to jsonplaceholder unavailable. {diagnosticMessage}");
            }

            var data = JsonConvert.DeserializeObject<T>(response.Content);

            return data;
        }

        public AccountInformation GetAccountInformation()
        {
            //TODO - return some unique information about the remote data source
            // that uniquely identifies the account
            return new AccountInformation("", "");
        }

        public IEnumerable<Metadata> Get(string filepath)
        {
            using (var parser = new TextFieldParser(filepath))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.HasFieldsEnclosedInQuotes = true;
                parser.SetDelimiters(";");
                parser.ReadFields();
                while (!parser.EndOfData)
                {
                    var fields = parser.ReadFields();
                    var rowObj = new Metadata
                    {
                        FHANUM = fields[0],
                        KUNLOEB = fields[1],
                        NAVN = fields[2],
                        ADRESSE = fields[3],
                        ADRESSE2 = fields[4],
                        POSTBY = fields[5],
                        KUNTLF = fields[6],
                        CPRNUM = fields[7],
                        CPRNUM2 = fields[8],
                        CVRNUM = fields[9]
                    };

                    yield return rowObj;
                }
            }
        }
    }
}
