using System;
using System.Windows.Forms;

namespace LibraryApplication.LibraryHelpers
{
    class Timer
    {
        public static System.Timers.Timer In(int Milliseconds, Action action)
        {
            System.Timers.Timer timer = new System.Timers.Timer(Milliseconds);
            timer.AutoReset = false;
            timer.Elapsed += new System.Timers.ElapsedEventHandler((o, e) => {
                action();
            });
            timer.Start();
            return timer;
        }

        public static System.Timers.Timer Repeat(int intervalMilliseconds, Action action)
        {
            System.Timers.Timer timer = new System.Timers.Timer(intervalMilliseconds);
            timer.AutoReset = true;
            timer.Elapsed += new System.Timers.ElapsedEventHandler((o, e) => {
                action();
            });
            timer.Start();
            return timer;
        }

        public static System.Timers.Timer Repeat(int intervalMilliseconds, int repeatTimes, Action action)
        {
            var newRepeat = repeatTimes;

            System.Timers.Timer timer = new System.Timers.Timer(intervalMilliseconds);
            timer.AutoReset = true;
            timer.Elapsed += new System.Timers.ElapsedEventHandler((o, e) => {
                
                newRepeat -= 1;
                if (newRepeat == 0)
                {
                    timer.Stop();
                    timer.Dispose();
                    timer = null;
                }

                action();

            });
            timer.Start();
            return timer;
        }
    }
}
