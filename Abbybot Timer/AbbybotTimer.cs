using AbbybotTimer.DataObjects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace AbbybotTimer
{
    public class ABTimer
    {
        Timer timer = new Timer();
        public List<TimedObject> tos = new List<TimedObject>();
        public ABTimer()
        {
            timer.Interval = 500;
            timer.Elapsed += (e, r) => Check().GetAwaiter().GetResult();
            timer.Start();
        }

        public async Task Check()
        {
            foreach (var to in tos)
            {
                await to.Check();
                //await to.UpdateTimerString();
            }
        }
   
        void echo (TimedObject to)
        {
            Console.WriteLine($"{to.name} has passed");
        }

        public void Add (string name, DateTime time)
        {
            var to = new TimedObject(name, time);
                 to.passed += (ab, n) => echo(to);
            tos.Add(to);
        }

        public void Add(TimedObject timedobject)
        {
            tos.Add(timedobject);
        }

        public void Add(DateTime time)
        {
            Add("Unnamed Time", time);
        }

    }
}
