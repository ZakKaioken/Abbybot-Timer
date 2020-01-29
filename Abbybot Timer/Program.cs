using AbbybotTimer.DataObjects;
using System;
using System.Collections.Generic;

namespace AbbybotTimer
{
    class Program
    {
        static AbbybotTimer abt = new AbbybotTimer();
        static void Main(string[] args)
        {
            abt.Add("5 second from now", DateTime.Now.AddSeconds(5));
            var now = DateTime.Now;
            for (int o = 1;  o <= 10; o++)
            {
                abt.Add($"{o} seconds from now", now.AddSeconds(o));
            }


            Console.ReadLine();
        }
    }
}
