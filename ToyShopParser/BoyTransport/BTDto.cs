namespace ToyShopParser.BoyTransport
{
    /// <summary>
    /// Data Transfer Object. It used specifically for category products - Boy Transport
    /// </summary>
    public class BTDto
    {
        public string Region { get; init; }
        public string ProductName { get; init; }
        public string Price { get; init; }
        public string OldPrice { get; init; }
        public string IsInStock { get; init; }
        public string PictureReference { get; init; }
        public string ProductReference { get; init; }
    }
}
