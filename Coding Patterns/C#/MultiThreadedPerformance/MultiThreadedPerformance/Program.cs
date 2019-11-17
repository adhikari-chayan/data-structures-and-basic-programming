using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MultiThreadedPerformance
{
    class Program
    {
        public static void EvenNumbersSum()
        {
            double sum = 0;
            for(int i=0;i<=50000000;i++)
            {
                if(i%2==0)
                {
                    sum = sum + i;
                }
            }

            Console.WriteLine("Sum of even numbers={0}",sum);
        }

        public static void OddNumbersSum()
        {
            double sum = 0;
            for(int i=0;i<50000000;i++)
            {
                if(i%2==1)
                {
                    sum = sum + i;
                }
            }
            Console.WriteLine("Sum of odd numbers={0}",sum);
        }
        static void Main(string[] args)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            Thread T1 = new Thread(EvenNumbersSum);
            Thread T2 = new Thread(OddNumbersSum);

            T1.Start();
            T2.Start();

            T1.Join();
            T2.Join();

            stopwatch.Stop();
            Console.WriteLine("Total milliseconds with multiple threads = "+ stopwatch.ElapsedMilliseconds);
            Console.WriteLine();

            stopwatch = Stopwatch.StartNew();
            EvenNumbersSum();
            OddNumbersSum();
            stopwatch.Stop();
            Console.WriteLine("Total milliseconds without multiple threads  = "+ stopwatch.ElapsedMilliseconds);
            Console.ReadKey();
        }
    }
}
