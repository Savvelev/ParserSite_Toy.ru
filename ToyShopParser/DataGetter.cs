using AngleSharp.Html.Parser;
using System.Collections.Generic;
using System.Threading.Tasks;
using ToyShopParser.BoyTransport;
using ToyShopParser.Interfaces;

namespace ToyShopParser
{
    /// <summary>
    /// The class allows to get / get and write the necessary data.
    /// </summary>
    /// <typeparam name="T">The type is using by method</typeparam>
    class DataGetter<T> where T : class
    {
        readonly HtmlParser domParser = new();
        HtmlPageLoader htmlPageLoader;
        readonly IParser<T> parser;
        IParserSettings parserSettings;
        private BoyTransportDataParser transportDataParser;
        private CsvAppender<string> appender1;
        private readonly CsvAppender<T> appender;

        public IParserSettings Settings
        {
            get { return parserSettings; }
            set
            {
                parserSettings = value;
                htmlPageLoader = new HtmlPageLoader();
            }
        }
        public DataGetter(IParser<T> parser)
        {
            this.parser = parser;
        }
        public DataGetter(IParser<T> parser, IParserSettings parserSettings) : this(parser)
        {
            this.parserSettings = parserSettings;
        }
        public DataGetter(IParser<T> parser, CsvAppender<T> appender) : this(parser)
        {
            this.appender = appender;
        }


        /// <summary>
        /// The method returns all data.
        /// </summary>
        /// <param name="listReferences">Array of all received links.</param>
        /// <returns>Returns all data.</returns>
        public async Task<List<T>> GetDatasByLinks(List<List<string>> listReferences)  // use no T
        {
            var list = new List<T>();

            foreach (var stringList in listReferences)
            {
                foreach (var item in stringList)
                {
                    var sourse = await htmlPageLoader.GetSourseByLink(item);
                    var document = await domParser.ParseDocumentAsync(sourse);

                    list.Add(parser.Parse(document));
                }
            }
            return list;
        }
        /// <summary>
        /// The method returns all data and without allocation in memory write it in CSV file.
        /// </summary>
        /// <param name="listReferences">Array of all received links.</param>
        /// <returns>Write data in CSV file.</returns>
        public async Task GetDatasByLinksAndWriteToCsv(List<List<string>> listReferences)
        {
            foreach (var stringList in listReferences)
            {
                foreach (var item in stringList)
                {
                    var sourse = await htmlPageLoader.GetSourseByLink(item);
                    var document = await domParser.ParseDocumentAsync(sourse);
                    await appender.AppendBTDtoToCsvfile(parser.Parse(document));
                }
            }
        }
    }
}
