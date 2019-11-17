using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadJoinIsAlive
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Main Started");
            Thread T1 = new Thread(new ThreadStart(Program.Thread1Function));
            T1.Start();

            Thread T2 = new Thread(new ThreadStart(Program.Thread2Function));
            T2.Start();

           if(T1.Join(1000))
                Console.WriteLine("Thread1Function completed");
           else
                Console.WriteLine("Thread1Function has not completed in 1 second");
            
            T2.Join();
            Console.WriteLine("Thread2Function completed");
            
            for (int i = 1; i <= 10; i++)
            {
                if (T1.IsAlive)
                {
                    Console.WriteLine("Thread1Function is still doing its job");
                    Thread.Sleep(500);
                }
                else
                {
                    Console.WriteLine("Thread1Function completed");
                    break;

                }
            }
            
            Console.WriteLine("Main Completed");                
            Console.ReadKey();
        }

        public static void Thread1Function()
        {
            Console.WriteLine("Thread1Function started");
            Thread.Sleep(5000);
            Console.WriteLine("Thread1Function is about to return");
        }

        public static void Thread2Function()
        {
            Console.WriteLine("Thread2Function started");
        }
    }
}
