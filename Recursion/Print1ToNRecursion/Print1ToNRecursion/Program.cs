using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Print1ToNRecursion
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter a number: ");
            int n = Convert.ToInt32(Console.ReadLine());

            Print1(n);
            Console.WriteLine();
            Print2(n);

            Console.ReadKey();
        }

        private static void Print2(int n)
        {
            if (n == 0)
                return;
            Print2(n - 1);
            Console.Write(n + " ");
        }

        private static void Print1(int n)
        {
            if (n == 0)
                return;

            Console.Write(n+" ");
            Print1(n - 1);
        }
    }
}
