using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordCount
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = "Hello Word Is Not a Proper  Word";
            int count = WordCount(input);
            Console.WriteLine(count);
            Console.ReadKey();
        }

        private static int WordCount(string input)
        {
            input = input.Trim();
            input = input.Replace("  ", " ");
            string[] count = input.Split(' ');
            return count.Length;
        }
    }
}
