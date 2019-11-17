using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProtectingSharedResourceFromConcurrentAccess
{
    class Program
    {
        static int Total = 0;
        static void Main(string[] args)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            Thread thread1 = new Thread(Program.AddOneMillon);
            Thread thread2 = new Thread(Program.AddOneMillon);
            Thread thread3 = new Thread(Program.AddOneMillon);

            thread1.Start();
            thread2.Start();
            thread3.Start();

            thread1.Join();
            thread2.Join();
            thread3.Join();

            Console.WriteLine("Total= "+Total);
            stopwatch.Stop();
            Console.WriteLine("Time taken in ticks: "+stopwatch.ElapsedTicks.ToString());
            Console.ReadKey();
        }

        static object _lock = new object();
        private static void AddOneMillon()
        {
            for (int i = 1; i <= 1000000; i++)
            {
                //Total++;
                //Interlocked.Increment(ref Total);
                lock (_lock)
                {
                    Total++;
                }
            }
        }
    }
}
