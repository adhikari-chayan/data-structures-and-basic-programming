using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SumOfDigitsRecursive
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter a number: ");
            int n = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine($"Sum of digits for {n} is {SumOfDigits(n)}");
            Console.ReadKey();
        }

        private static int SumOfDigits(int n)
        {
            if (n / 10 == 0)
                return n;

            return SumOfDigits(n / 10) + n % 10;

    
        }
    }
}
