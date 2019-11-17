using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadStartDelegate
{
    class Program
    {
        static void Main(string[] args)
        {
            //Thread T1 = new Thread(Number.PrintNumbers);
            //Thread T1 = new Thread(new ThreadStart(Number.PrintNumbers));
            //Thread T1 = new Thread(delegate () { Number.PrintNumbers(); });
            Thread T1 = new Thread(() => Number.PrintNumbers());
            T1.Start();

            Console.ReadKey();
        }
    }

    class Number
    {
        public static void PrintNumbers()
        {
            for(var i=1;i<=10;i++)
                Console.WriteLine(i);
        }
    }
}
