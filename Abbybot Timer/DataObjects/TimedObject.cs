using System;
using System.Collections.Generic;
using System.Text;

namespace AbbybotTimer.DataObjects
{
    public class TimedObject
    {
        public string name;
        public DateTime time;
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
        public void Check ()
        {
            if (time < DateTime.Now && active)
            {
                DoWork();
                deactivate();
            }
        }
        public virtual void DoWork()
        {
            if (passed.Method != null)
                passed.Invoke(this, null);
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
