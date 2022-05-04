using AngleSharp.Html.Parser;
using System.Threading.Tasks;
using ToyShopParser.Interfaces;

namespace ToyShopParser
{
    /// <summary>
    /// The class allows returning the number of pages that contain the necessary information for parsing.
    /// </summary>
    /// <typeparam name="T">The type is using by method</typeparam>
    class PageChecker<T> where T : class
    {
        readonly HtmlPageLoader htmlPageLoader;
        readonly IParser<T> parser;
        public PageChecker(IParser<T> parser)
        {
            this.parser = parser;
            htmlPageLoader = new HtmlPageLoader();
        }
        /// <summary>
        /// Method return count of page with parsing data. 
        /// </summary>
        /// <param name="url">Url page</param>
        /// <returns>Return count of page with parsing data.</returns>
        public async Task<T> GetCountPage(string url)
        {
            var domParser = new HtmlParser();

            var sourse = await htmlPageLoader.GetSourseByLink(url);
            var document = await domParser.ParseDocumentAsync(sourse);
            return parser.Parse(document);
        }
    }
}
