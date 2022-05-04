using AngleSharp.Dom;
using ToyShopParser.Interfaces;

namespace ToyShopParser.BoyTransport
{
    class BoyTransportDataParser : IParser<BTDto>
    {
        public BTDto Parse(IDocument document)
        {            
            return new BTDto()
            {
                OldPrice = document.QuerySelector("span.old-price") != null ? document.QuerySelector("span.old-price").TextContent : "Старая цена отсутствует",
                IsInStock = document.QuerySelector("span.ok").TextContent,
                PictureReference = document.QuerySelector("div.card-slider-for>div>a").Attributes["href"].Value,
                ProductName = document.QuerySelector("h1.detail-name").TextContent,
                Price = document.QuerySelector("span.price").TextContent,
                Region = document.QuerySelector("div.top-location>noindex>div.container>div>div>a").TextContent.Trim(),
                ProductReference = document.Head.QuerySelector("head>meta[property=\'og:url\']").GetAttribute("content")
            };            
        }
    }
}
