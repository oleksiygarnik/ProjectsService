using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Agile.Client
{
    public interface ITimerService
    {
        event ElapsedEventHandler Elapsed;
        double Interval { get; set; }
        void Start();
        void Stop();
        void Dispose();
    }
}
