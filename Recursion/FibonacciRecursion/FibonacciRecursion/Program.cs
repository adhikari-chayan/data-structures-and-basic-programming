using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FibonacciRecursion
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter a number: ");
            int n = Convert.ToInt32(Console.ReadLine());

            for(var i=0;i<=n;i++)

                Console.Write(Fibo(i)+" ");
           
            Console.ReadKey();
        }

        //private static void FiboSeries(int n)
        //{
        //    if (n == 0)
        //        Console.Write(0+" "); 
        //    if (n == 1)
        //        Console.Write(1+" ");

          
        //}

        private static int Fibo(int n)
        {
            if (n == 0)
            {
              
                return 0;
            }
            if (n == 1)
            {
                
                return 1;
            }
            //Console.WriteLine(n);
            return Fibo(n - 1) + Fibo(n - 2);
        }
    }
}
