using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace PowerPlatformCommandConsole
{
    public class PowerPlatformVersions
    {
        public IList<ProductVersion> PowerPlatform { get; set; }
    }

    public class ProductVersion
    {
        public string Ver { get; set; }
    }

    public class BDFUtilities
    {
        public static HttpClient HttpClient = new HttpClient();

        public BDFUtilities()
        {
        }

        public  static async Task<IList<string>> GetPowerPlatformVersions(IList<string> releases, IList<string> majorVersions)
        {
            PowerPlatformVersions ppVersionsFromBDF = await GetPowerPlatformVersionsFromBDFServer();
            if(ppVersionsFromBDF == null)
                return null;
            
            IList<string> ppVersions = new List<string>();
            foreach (ProductVersion ver in ppVersionsFromBDF.PowerPlatform)
            {
                string[] parts = ver.Ver.Split('.');
                if((parts != null) && (parts.Length == 4))
                {
                    bool valid = true;
                    if((releases != null) && !releases.Contains(parts[0]))
                        valid = false;

                    if((majorVersions != null) && !majorVersions.Contains(parts[1]))
                        valid = false;

                    if(valid)
                        ppVersions.Add(ver.Ver);
                }
            }

            return ppVersions;
        }

        private static async Task<PowerPlatformVersions> GetPowerPlatformVersionsFromBDFServer()
        {
            PowerPlatformVersions ppVersions = null;
            string url = "http://builddescriptions.bentley.com/api/products?Product=PowerPlatform&Flags=VersionsOnly";

            HttpResponseMessage response = await HttpClient.GetAsync(url);
            if(response.IsSuccessStatusCode)
            {
                string jsonString = await response.Content.ReadAsStringAsync();
                JObject jsonData = JObject.Parse(jsonString);

                ppVersions = jsonData.ToObject<PowerPlatformVersions>();

            }

            return ppVersions;
        }

    }
}
