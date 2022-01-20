using System;
using System.Threading.Tasks;

namespace Net5.AsynchronousProgramming
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Chef chef = new Chef();
            //chef.CookBreakFast();

            ChefTAP chefTAP = new ChefTAP();
            await chefTAP.CookBreakFastAsync();
        }
    }
}
