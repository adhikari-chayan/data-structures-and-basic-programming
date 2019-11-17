using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadDemoBackgroundThread
{
    //https://www.c-sharpcorner.com/UploadFile/ff0d0f/working-of-thread-and-foreground-background-thread-in-C-Sharp730/x`       
    class Program
    {
        public static void ThreadMethod()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("ThreadCount: {0}", i);
                Thread.Sleep(1000);
            }
        }
        static void Main(string[] args)
        {
            Thread t = new Thread(new ThreadStart(ThreadMethod));
            t.IsBackground = true;
            t.Start();
           
        }
    }
}
