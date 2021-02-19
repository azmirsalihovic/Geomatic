using System;
using System.Net;
using System.Threading.Tasks;
using CluedIn.Core.Providers;
using CluedIn.Crawling.Geomatic.Core;
using Newtonsoft.Json;
using RestSharp;
using Microsoft.Extensions.Logging;
using CluedIn.Crawling.Geometic.Core.Models;
using System.Collections.Generic;
using Microsoft.VisualBasic.FileIO;
using System.Text;
using System.IO;

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

        public string ErrorString { get; private set; }

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

        public IEnumerable<Account> Get(string filepath)
        {
            //var defaultEncoding = Encoding.UTF8;
            var defaultEncoding = Encoding.GetEncoding("ISO-8859-1");

            using (var parser = new TextFieldParser(filepath, defaultEncoding))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.HasFieldsEnclosedInQuotes = true;
                parser.SetDelimiters(";");
                parser.ReadFields();
                while (!parser.EndOfData)
                {
                    Account returnValue = null;
                    try
                    {
                        var fields = parser.ReadFields();
                        var rowObj = new Account
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
                            CVRNUM = fields[9],
                            OutputName = fields[10],
                            OutputNameFirst = fields[11],
                            OutputNameLast = fields[12],
                            OutputKvhx = fields[13],
                            OutputCareof = fields[14],
                            OutputLokalitet = fields[15],
                            OutputStreetline = fields[16],
                            OutputStednavn = fields[17],
                            OutputPcode = fields[18],
                            OutputPdistname = fields[19],
                            OutputStrname = fields[20],
                            OutputHounoNum = fields[21],
                            OutputHounoAlpha = fields[22],
                            OutputFloor = fields[23],
                            OutputSuite = fields[24],
                            Mobile = fields[25],
                            Landline = fields[26],
                            InputKvhx = fields[27],
                            InputUnadrMatchlvlDetail = fields[28],
                            PartnerRemoved = fields[29],
                            OutputAddressOrigin = fields[30],
                            OutputNameOrigin = fields[31],
                            AddressChange = fields[32],
                            Duplicate = fields[33],
                            DuplicateId = fields[34],
                            Per1PnrValidation = fields[35],
                            Per2PnrValidation = fields[36],
                            Per1InputName = fields[37],
                            Per1CprMatch = fields[38],
                            Per1CprStatus = fields[39],
                            Per1Protect = fields[40],
                            Per1AdvptectRobinson = fields[41],
                            Per1AdvptectRobinsonDate = fields[42],
                            Per1Movdat = fields[43],
                            Per1NameFirsts = fields[44],
                            Per1NameLast = fields[45],
                            Per1NameAdr = fields[46],
                            Per1Careof = fields[47],
                            Per1Lokalitet = fields[48],
                            Per1Streetline = fields[49],
                            Per1Stednavn = fields[50],
                            Per1Pcode = fields[51],
                            Per1Pdistname = fields[52],
                            Per1Kvhx = fields[53],
                            Per1AdrContact1 = fields[54],
                            Per1AdrContact2 = fields[55],
                            Per1AdrContact3 = fields[56],
                            Per1AdrContact4 = fields[57],
                            Per1AdrContact5 = fields[58],
                            Per1AdrContactDate = fields[59],
                            Per1AdrForeign1 = fields[60],
                            Per1AdrForeign2 = fields[61],
                            Per1AdrForeign3 = fields[62],
                            Per1AdrForeign4 = fields[63],
                            Per1AdrForeign5 = fields[64],
                            Per1AdrForeignDate = fields[65],
                            Per2InputName = fields[66],
                            Per2CprMatch = fields[67],
                            Per2CprStatus = fields[68],
                            Per2Protect = fields[69],
                            Per2AdvptectRobinson = fields[70],
                            Per2AdvptectRobinsonDate = fields[71],
                            Per2Movdat = fields[72],
                            Per2NameFirsts = fields[73],
                            Per2NameLast = fields[74],
                            Per2NameAdr = fields[75],
                            Per2Careof = fields[76],
                            Per2Lokalitet = fields[77],
                            Per2Streetline = fields[78],
                            Per2Stednavn = fields[79],
                            Per2Pcode = fields[80],
                            Per2Pdistname = fields[81],
                            Per2Kvhx = fields[82],
                            Per2AdrContact1 = fields[83],
                            Per2AdrContact2 = fields[84],
                            Per2AdrContact3 = fields[85],
                            Per2AdrContact4 = fields[86],
                            Per2AdrContact5 = fields[87],
                            Per2AdrContactDate = fields[88],
                            Per2AdrForeign1 = fields[89],
                            Per2AdrForeign2 = fields[90],
                            Per2AdrForeign3 = fields[91],
                            Per2AdrForeign4 = fields[92],
                            Per2AdrForeign5 = fields[93],
                            Per2AdrForeignDate = fields[94]
                        };
                        returnValue = rowObj;
                    }
                    catch (Exception e)
                    {
                        ErrorString = e.Message;
                        continue;
                    }
                    yield return returnValue;
                }
            }
        }

        public List<string> GetKunloebIDList(string filepath)
        {
            List<string> KunloebIDList = new List<string>();
            try
            {
                using (var parser = new TextFieldParser(filepath))
                {
                    parser.TextFieldType = FieldType.Delimited;
                    parser.HasFieldsEnclosedInQuotes = true;
                    parser.SetDelimiters(new string[] { ";" });
                    parser.ReadFields();
                    while (!parser.EndOfData)
                    {
                        try
                        {
                            var filterByKunloebIds = parser.ReadFields();
                            KunloebIDList.Add(filterByKunloebIds[1]);
                        }
                        catch (Exception)
                        {
                            break;
                        }
                    }
                }
            }
            catch (Exception)
            {
                return null;
            }
            return KunloebIDList;
        }
    }
}
