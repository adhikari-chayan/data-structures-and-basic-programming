using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factorial
{
    class Program
    {
        static void Main(string[] args)
        {
            int n;
            Console.Write("Enter a number greater than 0: ");
            n = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine($"Factorial of n is {Factorial(n)}");
            Console.ReadKey();
        }

        private static int Factorial(int n)
        {
            if (n == 0)
                return 1;

            return n * Factorial(n - 1);
        }
    }
}
