using System;

namespace ToyShopParser.View
{   /// <summary>
    /// Console output. Interaction with users.
    /// </summary>
    class GUI
    {
        public void StartDisplay(int page)
        {
            Console.WriteLine($"Page range: {page}. How many pages of information do you want to parse?");
        }
        public void WaitDisplay()
        {
            Console.WriteLine("Wait, please.Parsing can take time");
        }
        public void FinishDisplay()
        {
            Console.WriteLine("All done");
        }
    }
}
