using System;
using System.Globalization;
using System.Text;

namespace Net5.GlobalizationAndlocalization.UsingCustomNumericFormatStrings
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;

            var culture = CultureInfo.CreateSpecificCulture("en-US");
            culture.NumberFormat.NumberGroupSeparator = " ";

            decimal number = 1.5m;

            string numberAsString =
                number.ToString("#,#.#", culture);

            string numberAsStringSwedish =
                number.ToString("#,#.#", new CultureInfo("sv-SE"));

            Console.WriteLine(numberAsString);
            Console.WriteLine(numberAsStringSwedish);
            Console.WriteLine(number.ToString("00.00",culture));
            Console.WriteLine(number.ToString("00.00", new CultureInfo("sv-SE")));
        }
    }
}
