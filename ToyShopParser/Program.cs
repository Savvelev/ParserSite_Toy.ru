using System;
using System.Collections.Generic;
using ToyShopParser.BoyTransport;

namespace ToyShopParser
{
    class Program
    {
        View.GUI gui;

        readonly BoyTransportCountPageParser countPageParser;
        readonly PageChecker<string> pageChecker;
        readonly BoyTransportRefParser referenceParser;
        readonly ReferenceGetter<List<string>> referenceGetter;
        readonly BoyTransportDataParser transportDataParser;
        readonly DataGetter<BTDto> dataGetter;
        readonly CsvAppender<BTDto> appender;

        public Program()
        {
            gui = new View.GUI();
            appender = new CsvAppender<BTDto>();
            countPageParser = new BoyTransportCountPageParser();
            pageChecker = new PageChecker<string>(countPageParser);
            referenceParser = new BoyTransportRefParser();
            referenceGetter = new(referenceParser);
            transportDataParser = new BoyTransportDataParser();
            dataGetter = new(transportDataParser,appender);
            
        }
        static void Main(string[] args)
        {
            Program p = new();
            int result;

            var countPage = int.Parse(p.pageChecker.GetCountPage("https://www.toy.ru/catalog/boy_transport/").Result);
            p.gui.StartDisplay(countPage);
            result = InputValidation(countPage);
            p.gui.WaitDisplay();
            p.referenceGetter.Settings = new BoyTransportSettings(1, result);
            p.dataGetter.Settings = new BoyTransportSettings();
            try
            {
                var allref = p.referenceGetter.GetReferences(result).Result;

                p.appender.AppendDescription();

                p.dataGetter.GetDatasByLinksAndWriteToCsv(allref).Wait();

                p.gui.FinishDisplay();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
            }
        }

        private static int InputValidation(int countPage)
        {
            int result = 1;
            bool flag = true;
            while (flag)
            {
                string input = Console.ReadLine();
                if (int.TryParse(input, out result))
                {
                    if (result < 0)
                    {
                        continue;
                    }
                    result = result > countPage ? countPage : result;
                    flag = false;
                }
            }
            return result;
        }
    }
}
