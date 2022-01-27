using System;
using System.Globalization;

namespace Net5.GlobalizationAndlocalization.SortingAnArrayOfStrings
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] names = {  "Örjan", "Zoe", "filip",
                                "Olof", "chris", "Chloë", "Mila",
                                "John", "Åsa", "Anna", "Sofie", "Fèlip" };

            CultureInfo.CurrentCulture = new CultureInfo("en-US");

            Array.Sort(names, StringComparer.OrdinalIgnoreCase);

            foreach (var name in names)
            {
                Console.WriteLine(name);
            }
        }
    }
}
