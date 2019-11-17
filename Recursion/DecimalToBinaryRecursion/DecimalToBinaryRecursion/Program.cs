using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecimalToBinaryRecursion
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Please Enter a number: ");
            int n = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"Binary Representation of {n}");
            ToBinary(n);
            Console.WriteLine();
            Console.WriteLine($"Base Representation of {n}");
            Console.Write("Please enter any base: ");
            int b = Convert.ToInt32(Console.ReadLine());
            ConvertToBase(n, b);
            Console.ReadKey();
        }

        private static void ConvertToBase(int n, int b)
        {
            if (n == 0)
                return;

            ConvertToBase(n / b, b);
            int reminder = n % b;
            if(reminder<10)
                Console.Write(reminder);
            else
                Console.Write((char)(reminder-10+'A'));
        }

        private static void ToBinary(int n)
        {
            if (n == 0)
                return;
            ToBinary(n / 2);
            Console.Write(n%2);
        }
    }
}
