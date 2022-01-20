using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Net5.AsynchronousProgramming
{
    public class Chef
    {
        public PositionProcess CoffeePos { get; set; }
        public PositionProcess EggPos { get; set; }
        public PositionProcess BaconPos { get; set; }
        public PositionProcess ToastPos { get; set; }
        public PositionProcess JamPos { get; set; }
        public PositionProcess ButterPos { get; set; }
        public PositionProcess JuicePos { get; set; }

        public Stopwatch stopwatch { get; set; }

        public Chef()
        {
            InitPositions();
            stopwatch = new Stopwatch();
        }

        public void CookBreakFast()
        {
            Init();

            stopwatch.Start();

            Coffee cup = PourCoffee();
            WriteTo("Coffe is ready",CoffeePos.Status);

            Egg eggs = FryEgg(2);
            WriteTo("Eggs are ready",EggPos.Status);

            Bacon bacon = FryBacon(3);
            WriteTo("Bacon is ready",BaconPos.Status);

            Toast toast = ToastBread(2);
            WriteTo("Toast is ready",ToastPos.Status);
            ApplyJam(toast);
            WriteTo("jam on bread",JamPos.Status);
            ApplyButter(toast);
            WriteTo("butter on bread",ButterPos.Status);

            Juice oj = PourJuice();
            WriteTo("Orange juice is ready",JuicePos.Status);

            stopwatch.Stop();

            Console.WriteLine($"Breakfast is ready in {stopwatch.Elapsed.TotalSeconds} seconds!!");
        }

        private Coffee PourCoffee()
        {
            Stopwatch sw = Stopwatch.StartNew();
            WriteTo("Pouring coffe",CoffeePos.Log);
            Task.Delay(3000).Wait();
            sw.Stop();
            WriteTo($"{sw.Elapsed.TotalSeconds}",CoffeePos.Time);

            return new Coffee();
        }

        private Egg FryEgg(int howMany)
        {
            Stopwatch sw = Stopwatch.StartNew();
            WriteTo("Warming the egg pan...",EggPos.Log);
            Task.Delay(3000).Wait();
            WriteTo($"cracking {howMany} eggs, cooking the eggs...", EggPos.Log);
            Task.Delay(3000).Wait();
            WriteTo("Put eggs on plate", EggPos.Log);
            sw.Stop();
            WriteTo($"{sw.Elapsed.TotalSeconds}", EggPos.Time);

            return new Egg();
        }

        private Bacon FryBacon(int slices)
        {
            Stopwatch sw = Stopwatch.StartNew();
            WriteTo($"putting {slices} slices of bacon in the pan",BaconPos.Log);
            Task.Delay(3000).Wait();

            for (int i = 0; i < slices; i++)
            {
                WriteTo($"cooking a {i + 1 } slice of bacon", BaconPos.Log);
                Task.Delay(1000).Wait();
            }
            Task.Delay(3000).Wait();
            WriteTo("Put bacons on plate", BaconPos.Log);
            sw.Stop();
            WriteTo($"{sw.Elapsed.TotalSeconds}", BaconPos.Time);

            return new Bacon();
        }

        private Toast ToastBread(int slices)
        {
            Stopwatch sw = Stopwatch.StartNew();
            for (int i = 0; i < slices; i++)
            {
                WriteTo($"Putting a ({i + 1}) slice of bread in the toaster",ToastPos.Log);
                Task.Delay(1000).Wait();
            }
            WriteTo("Star toasting...", ToastPos.Log);
            Task.Delay(3000).Wait();
            WriteTo("Remove toast from toaster", ToastPos.Log);
            sw.Stop();
            WriteTo($"{sw.Elapsed.TotalSeconds}", ToastPos.Time);

            return new Toast();
        }

        private void ApplyJam(Toast toast)
        {
            Stopwatch sw = Stopwatch.StartNew();
            WriteTo("Putting jam on the toast",JamPos.Log);
            Task.Delay(3000).Wait();
            sw.Stop();
            WriteTo($"{sw.Elapsed.TotalSeconds}", JamPos.Time);
        }

        private void ApplyButter(Toast toast)
        {
            Stopwatch sw = Stopwatch.StartNew();
            WriteTo("Putting butter on the toast",ButterPos.Log);
            Task.Delay(3000).Wait();
            sw.Stop();
            WriteTo($"{sw.Elapsed.TotalSeconds}", ButterPos.Time);
        }

        private Juice PourJuice()
        {
            Stopwatch sw = Stopwatch.StartNew();
            WriteTo("Pouring orange juice",JuicePos.Log);
            Task.Delay(3000).Wait();
            sw.Stop();
            WriteTo($"{sw.Elapsed.TotalSeconds}", JuicePos.Time);

            return new Juice();
        }

        private void WriteTo(string msg,Point point)
        {
            Console.SetCursorPosition(point.X, point.Y);
            switch (point.Type)
            {
                case TypePoint.Log:
                    Console.Write("                                                              ");
                    break;
                case TypePoint.Status:
                    Console.Write("                     ");
                    break;
                case TypePoint.Time:
                    Console.Write("              ");
                    break;             
            }
            Console.SetCursorPosition(point.X, point.Y);
            Console.Write(msg);
            Console.SetCursorPosition(0, 18);
        }

        private void InitPositions()
        {
            CoffeePos = new PositionProcess(27, 3, 92, 3, 116, 3);
            EggPos = new PositionProcess(27, 5, 92, 5, 116, 5);
            BaconPos = new PositionProcess(27, 7, 92, 7, 116, 7);
            ToastPos = new PositionProcess(27, 9, 92, 9, 116, 9);
            JamPos = new PositionProcess(27, 11, 92, 11, 116, 11);
            ButterPos = new PositionProcess(27, 13, 92, 13, 116, 13);
            JuicePos = new PositionProcess(27, 15, 92, 15, 116, 15);
        }

        private void Init()
        {
            PrintDashboard();

            for (int i = 5; i > 0; i--)
            {
                Console.SetCursorPosition(0, 18);
                Console.WriteLine($"{i} seconds to start cooking");
                Task.Delay(1000).Wait();
            }
            Console.SetCursorPosition(0, 18);
            Console.WriteLine($"                               ");
        }

        private void PrintDashboard()
        {

            //                                 10        20        30        40        50        60        70        80        90       100       110       120       130
            //                        012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901
            Console.WriteLine(/*00*/ "┌────────────────────────┬────────────────────────────────────────────────────────────────┬───────────────────────┬────────────────┐");
            Console.WriteLine(/*01*/ "│ PROCESS                │ LOG                                                            │ STATUS                │ TIME (Seconds) │ ");
            Console.WriteLine(/*02*/ "├────────────────────────┼────────────────────────────────────────────────────────────────┼───────────────────────┼────────────────┤");
            Console.WriteLine(/*03*/ "│ 1.- Pour Coffe         │                                                                │                       │                │");
            Console.WriteLine(/*04*/ "├────────────────────────┼────────────────────────────────────────────────────────────────┼───────────────────────┼────────────────┤");
            Console.WriteLine(/*05*/ "│ 2.- Fry eggs           │                                                                │                       │                │");
            Console.WriteLine(/*06*/ "├────────────────────────┼────────────────────────────────────────────────────────────────┼───────────────────────┼────────────────┤");
            Console.WriteLine(/*07*/ "│ 3.- Fry Bacon          │                                                                │                       │                │");
            Console.WriteLine(/*08*/ "├────────────────────────┼────────────────────────────────────────────────────────────────┼───────────────────────┼────────────────┤");
            Console.WriteLine(/*09*/ "│ 4.- Toast bread        │                                                                │                       │                │");
            Console.WriteLine(/*10*/ "├────────────────────────┼────────────────────────────────────────────────────────────────┼───────────────────────┼────────────────┤");
            Console.WriteLine(/*11*/ "│ 5.- Putting jam        │                                                                │                       │                │");
            Console.WriteLine(/*12*/ "├────────────────────────┼────────────────────────────────────────────────────────────────┼───────────────────────┼────────────────┤");
            Console.WriteLine(/*13*/ "│ 6.- Putting butter     │                                                                │                       │                │");
            Console.WriteLine(/*14*/ "├────────────────────────┼────────────────────────────────────────────────────────────────┼───────────────────────┼────────────────┤");
            Console.WriteLine(/*15*/ "│ 7.- Pour juice         │                                                                │                       │                │");
            Console.WriteLine(/*16*/ "└────────────────────────┴────────────────────────────────────────────────────────────────┴───────────────────────┴────────────────┘");

        }
    }
}
