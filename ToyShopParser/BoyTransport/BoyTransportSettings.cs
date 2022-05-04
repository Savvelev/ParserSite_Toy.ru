using ToyShopParser.Interfaces;

namespace ToyShopParser.BoyTransport
{
    class BoyTransportSettings : IParserSettings
    {
        public BoyTransportSettings()
        {
        }
        public BoyTransportSettings(int start, int end)
        {
            StartPoint = start;
            EndPoint = end;
        }
        public BoyTransportSettings(int start, int end, string baseUrl, string prefix) : this(start, end)
        {
            BaseUrl = baseUrl;
            Prefix = prefix;
        }

        public string BaseUrl { get; set; } = @"https://www.toy.ru/catalog/boy_transport/";
        public string Prefix { get; set; } = "?filterseccode%5B0%5D=transport&PAGEN_5={CurrentId}";
        public int StartPoint { get; set; }
        public int EndPoint { get; set; }
    }
}
