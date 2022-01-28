using System;

namespace Net5.GlobalizationAndlocalization.SearchingForAString
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //string data = "Can we find this character: ̊a";            
            string data = "Can we find this character: ̊a\u030a";

            //int index = data.IndexOf("\u00e5"); // å
            //int index = data.IndexOf("a", StringComparison.InvariantCulture); // å
            int index = data.IndexOf('å'); // å

            Console.WriteLine(index);
        }
    }
}
