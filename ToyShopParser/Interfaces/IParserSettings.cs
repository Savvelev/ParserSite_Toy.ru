namespace ToyShopParser.Interfaces
{
    /// <summary>
    /// Base settings to parser
    /// </summary>
    interface IParserSettings
    {        
        string BaseUrl { get; set; }
        string Prefix { get; set; }
        int StartPoint { get; set; }
        int EndPoint { get; set; }
    }
}
