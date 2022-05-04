using AngleSharp.Dom;
using ToyShopParser.Interfaces;

namespace ToyShopParser.BoyTransport
{
    class BoyTransportCountPageParser : IParser<string>
    {
        public string Parse(IDocument document)
        {
            return document.QuerySelector("main>div>div>div.col-12.col-sm-12.col-md-12.col-lg-9>noindex:nth-child(7)>nav>ul>li:nth-child(8)>a").TextContent;
        }
    }
}
