using AngleSharp.Html.Parser;
using System.Collections.Generic;
using System.Threading.Tasks;
using ToyShopParser.Interfaces;

namespace ToyShopParser
{
    /// <summary>
    /// The class allows returnшing all links from which needed to parse data.
    /// </summary>
    /// <typeparam name="T">The type is using by method</typeparam>
    class ReferenceGetter<T> where T : class
    {
        HtmlPageLoader htmlPageLoader;
        IParser<T> parser;
        IParserSettings parserSettings;

        public IParserSettings Settings
        {
            get { return parserSettings; }
            set
            {
                parserSettings = value;
                htmlPageLoader = new HtmlPageLoader(value);
            }
        }

        public ReferenceGetter(IParser<T> parser)
        {
            this.parser = parser;
        }
        public ReferenceGetter(IParser<T> parser, IParserSettings parserSettings) : this(parser)
        {
            this.parserSettings = parserSettings;
        }

        /// <summary>
        /// Method return all references with necessary data for parsing.
        /// </summary>
        /// <param name="listCapacity">Parameter that specifies the amount of memory to allocate memory for the List type</param>
        /// <returns>Returns all references</returns>
        public async Task<List<T>> GetReferences(int listCapacity)
        {
            var listReferences = new List<T>(listCapacity);
            var domParser = new HtmlParser();
            for (int i = parserSettings.StartPoint; i <= parserSettings.EndPoint; i++)
            {               
                var sourse = await htmlPageLoader.GetSourserByPageId(i);  
                var document = await domParser.ParseDocumentAsync(sourse);
                listReferences.Add(parser.Parse(document));
            }
            return listReferences;
        }
    }
}
