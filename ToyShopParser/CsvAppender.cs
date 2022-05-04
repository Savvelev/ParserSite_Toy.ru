using System.IO;
using System.Text;
using System.Threading.Tasks;
using ToyShopParser.BoyTransport;

namespace ToyShopParser
{
    /// <summary>
    /// This class adds information to a CSV file using data tranfer object.
    /// </summary>
    /// <typeparam name="T">The type is using by method</typeparam>
    class CsvAppender<T>
    {
        /// <summary>
        /// This method adds the parsed data to the file using a specific pattern.
        /// </summary>
        /// <param name="value">The data tranfer object</param>
        /// <returns>Made a file write</returns>
        public async Task AppendBTDtoToCsvfile(T value)
        {
            var dto = value as BTDto;
            await File.AppendAllTextAsync("products.csv",
                $"{dto.Region},{dto.ProductName}," +
                $"{dto.Price},{dto.OldPrice}," +
                $"{dto.IsInStock}," +
                $"{dto.PictureReference}," +
                $"{dto.ProductReference}\n");
        }
        /// <summary>
        /// The first line of file description.
        /// </summary>
        public void AppendDescription()
        {
            File.AppendAllText("products.csv",
                "Название региона," +
                "Название товара," +
                "Цена,Цена старая," +
                "Раздел с наличием," +
                "Ссылки на картинки," +
                "Ссылки на товары\n",
                Encoding.UTF8);
        }
    }
}
