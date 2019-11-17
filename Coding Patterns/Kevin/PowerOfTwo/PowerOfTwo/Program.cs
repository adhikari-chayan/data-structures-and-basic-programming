using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerOfTwo
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = 64;
            var result = IsPowerOfTwo(input);
            Console.WriteLine(result);
            Console.ReadKey();
        }

        public static bool IsPowerOfTwo(int n)
        {
            long i = 1;
            while(i<n)
            {
                i = i * 2;
            }

            return i == n;
        }
    }
}
