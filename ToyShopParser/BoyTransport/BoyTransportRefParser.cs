using AngleSharp.Dom;
using System.Collections.Generic;
using ToyShopParser.Interfaces;

namespace ToyShopParser.BoyTransport
{
    class BoyTransportRefParser : IParser<List<string>>
    {
        public List<string> Parse(IDocument document)
        {
            var list = new List<string>();
            var items = document.QuerySelectorAll("a.product-name");

            foreach (var item in items)
            {
                list.Add("https://toy.ru" + item.Attributes["href"].Value);
            }
            return list;
        }
    }
}
