using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace ArbitrageCalculator.Core
{
    class HtmlLoader
    {
        readonly HttpClient client;
        public readonly string url;

        public HtmlLoader(IParserSettings settings)
        {
            client = new HttpClient();
            url = $"{settings.BaseUrl}";
        }

        public async Task<string> GetSource()
        {
            var response = await client.GetAsync(url);
            string source = null;

            if (response != null && response.StatusCode == HttpStatusCode.OK)
            {
                source = await response.Content.ReadAsStringAsync();
            }

            return source;
        }
    }
}
