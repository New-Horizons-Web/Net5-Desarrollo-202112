using System;

namespace Net5.GlobalizationAndlocalization.SearchingForAString
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string data = "Can we find this character: ̊a";

            int index = data.IndexOf("\u00e5",
                StringComparison.InvariantCulture); // å

            Console.WriteLine(index);
        }
    }
}
