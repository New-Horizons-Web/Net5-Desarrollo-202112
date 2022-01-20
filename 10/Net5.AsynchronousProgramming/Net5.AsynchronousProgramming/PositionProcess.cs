using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Net5.AsynchronousProgramming
{
    public class PositionProcess
    {
        public PositionProcess(int logX,int logY,int statusX,int statusY,int timeX,int timeY)
        {
            Log = new Point(logX, logY, TypePoint.Log);
            Status = new Point(statusX,statusY, TypePoint.Status);
            Time = new Point(timeX,timeY, TypePoint.Time);
        }

        public Point Log { get; set; }
        public Point Status { get; set; }
        public Point Time { get; set; }
    }
}
