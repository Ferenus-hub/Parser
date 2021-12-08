using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Parser.Core
{
    class HtmlLoader
    {
        HttpClient client;
        string url;

        public HtmlLoader(IParserSettings settings)
        {
            client = new HttpClient();
            client.BaseAddress = new System.Uri(settings.BaseUrl);
            url = $"{settings.BaseUrl}/{settings.Prefix}/";
        }

        public async Task<string> GetSourceByPageId(int id)
        {
            var currentUrl = url.Replace("{CurrentId}", id.ToString());
            string source = null;

            var response = client.GetAsync(currentUrl).Result;
            //var response = await client.GetAsync(currentUrl);

            if (response != null && response.StatusCode == HttpStatusCode.OK)
            {
                source = await response.Content.ReadAsStringAsync();
            }

            return source;
        }
    }
}
