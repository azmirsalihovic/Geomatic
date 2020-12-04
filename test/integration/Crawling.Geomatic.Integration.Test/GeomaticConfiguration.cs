using System.Collections.Generic;
using CluedIn.Crawling.Geomatic.Core;

namespace CluedIn.Crawling.Geomatic.Integration.Test
{
  public static class GeomaticConfiguration
  {
    public static Dictionary<string, object> Create()
    {
      return new Dictionary<string, object>
            {
                { GeomaticConstants.KeyName.ApiKey, "demo" },
                { GeomaticConstants.KeyName.FilePath, @"C:\Users\asa\Documents\CluedIn\Crawling.FileGenerator-master\Crawling.FileGenerator-master\CSVFileGenerator\CSV\SEMLER.DATA.csv" }
            };
    }
  }
}
