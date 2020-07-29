using System;
using System.Collections.Generic;
using System.Text;
using System.Timers;

namespace Agile.Client
{
    public class TimerService : ITimerService
    {
        public Timer Timer { get; }
        public double Interval { get; set; }

        public event ElapsedEventHandler Elapsed;

        public TimerService(double interval)
        {
            Interval = interval;
            Timer = new Timer(interval);
            Timer.Elapsed += OnElapsedHandler;
        }

        private void OnElapsedHandler(object sender, ElapsedEventArgs e)
        {
            Elapsed?.Invoke(this, e);
        }

        public void Dispose()
        {
            Timer?.Dispose();
        }

        public void Start()
        {
            Timer.Start();
        }

        public void Stop()
        {
            Timer.Stop();
        }
    }
}
