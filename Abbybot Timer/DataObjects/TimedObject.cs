using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AbbybotTimer.DataObjects
{
    public class TimedObject
    {
        public string name;
        public DateTime time;
        public StringBuilder message = new StringBuilder();
        public bool active = true;
        public event EventHandler passed;
        public TimedObject(string name, DateTime time)
        {
            this.name = name;
            this.time = time;

        }
        public TimedObject()
        {

        }

        public virtual async Task UpdateTimerString()
        {
           
                var tim = time - DateTime.Now;
                message.Clear();
                if (tim.Hours != 0) { message.Append(tim.Hours); message.Append("h "); }
                if (tim.Minutes != 0) { message.Append(tim.Minutes); message.Append("m "); }
                message.Append(tim.Seconds);
            
        }
        public async Task Check ()
        {
            if (time < DateTime.Now && active)
            {
                Console.WriteLine("win");
                await DoWork();
                active = false;
            }
        }
        public virtual async Task DoWork()
        {
            Console.WriteLine($"'{name}' told to do work");
            passed?.Invoke(this, null);
        }
        public void activate ()
        {
            active = true;
        }
        public void deactivate ()
        {
            active = false;
        }
    }
}
