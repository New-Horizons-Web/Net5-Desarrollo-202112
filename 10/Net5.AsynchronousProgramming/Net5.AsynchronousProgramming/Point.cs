using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Net5.AsynchronousProgramming
{
    public class Point
    {
        public Point(int x, int y, TypePoint type)
        {
            X = x;
            Y = y;
            Type = type;
        }
        public int X { get; set; }
        public int Y { get; set; }
        public TypePoint Type { get; set; }
    }
}
