using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ToyShopParser.Interfaces;

namespace ToyShopParser
{
    /// <summary>
    /// Class loading HTML document. 
    /// </summary>
    class HtmlPageLoader
    {
        readonly HttpClient client;
        readonly string url = "https://www.toy.ru/catalog/boy_transport/";

        public HtmlPageLoader()
        {
            HeaderConstants headerConstants = new();
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            client = new HttpClient(clientHandler);

            client.DefaultRequestHeaders.Add("Accept", headerConstants.Accept);
            client.DefaultRequestHeaders.Add("Connection", headerConstants.Connection);
            client.DefaultRequestHeaders.Add("Cache-Control", headerConstants.CacheControl);
            client.DefaultRequestHeaders.Add("Cookie", headerConstants.Cookie);
            client.DefaultRequestHeaders.Add("Host", headerConstants.Host);
            client.DefaultRequestHeaders.Add("Referer", url);
            client.DefaultRequestHeaders.Add("sec-ch-ua", headerConstants.SecChUa);
            client.DefaultRequestHeaders.Add("sec-ch-ua-platform", headerConstants.SecChUaPlatform);
            client.DefaultRequestHeaders.Add("Sec-Fetch-Dest", headerConstants.SecFetchDest);
            client.DefaultRequestHeaders.Add("Sec-Fetch-Mode", headerConstants.SecFetchMode);
            client.DefaultRequestHeaders.Add("Sec-Fetch-Site", headerConstants.SecFetchSite);
            client.DefaultRequestHeaders.Add("Sec-Fetch-User", headerConstants.SecFetchUser);
            client.DefaultRequestHeaders.Add("Upgrade-Insecure-Requests", headerConstants.UpgradeInsecureRequests);
            client.DefaultRequestHeaders.Add("User-Agent", headerConstants.UserAgent);
        }
        public HtmlPageLoader(IParserSettings settings) : this()
        {
            url = $"{settings.BaseUrl}{settings.Prefix}/";
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
        }

        /// <summary>
        /// Forming a page by page prefix.
        /// </summary>
        /// <param name="id">Page id</param>
        /// <returns>Return HTML data</returns>
        public async Task<string> GetSourserByPageId(int id)
        {
            var currentUrl = url.Replace("{CurrentId}", id.ToString());
            return await GetResponce(currentUrl);
        }

        /// <summary>
        /// The method gives a response from the accessing server by Url string.
        /// </summary>
        /// <param name="url"> Url string by page</param>
        /// <returns>Return HTML data</returns>
        public async Task<string> GetSourseByLink(string url) => await GetResponce(url);

        /// <summary>
        /// The method gives a response from the accessing server.
        /// </summary>
        /// <param name="currentUrl">Address to be contacted</param>
        /// <returns>Returns a responce.</returns>
        private async Task<string> GetResponce(string currentUrl)
        {
            var responce = await client.GetAsync(currentUrl);

            string sourse = null;
            if (responce != null && responce.StatusCode == HttpStatusCode.OK)
            {
                sourse = await responce.Content.ReadAsStringAsync();
            }
            else
                throw new HttpRequestException();

            return sourse;
        }
    }
}
