using System;
using System.Globalization;
using System.Text;

namespace Net5.GlobalizationAndlocalization.ParsingAndPersistingNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;

            // 1_000_000.5.ToString("#,#.#", new CultureInfo("sv-SE"));
            // 1_000_000.5.ToString("C", new CultureInfo("sv-SE"));

            var numberAsString = "1 000 000,5 kr";
            //decimal num = decimal.Parse(numberAsString,NumberStyles.Currency,new CultureInfo("sv-SE"));

            if (decimal.TryParse(numberAsString,NumberStyles.Currency,new CultureInfo("sv-SE"),out decimal number))
            {
                Console.WriteLine(number);
            }
        }
    }
}
