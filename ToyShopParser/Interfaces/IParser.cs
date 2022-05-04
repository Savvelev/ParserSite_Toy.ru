using AngleSharp.Dom;

namespace ToyShopParser.Interfaces
{
    /// <summary>
    /// Parser some documents
    /// </summary>
    /// <typeparam name="T">The type is using by method</typeparam>
    interface IParser<T> where T : class
    {
        /// <summary>
        /// Parsing input document
        /// </summary>
        /// <param name="document"> This parameter is using for parsing data from it</param>
        /// <returns>The parsing result</returns>
        T Parse(IDocument document);
    }
}
