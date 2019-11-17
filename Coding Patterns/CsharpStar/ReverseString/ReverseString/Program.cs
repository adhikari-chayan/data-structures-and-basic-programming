using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReverseString
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = "Palindrome";
            var result = ReverseString(input);
            Console.WriteLine(result);
            Console.ReadKey();
        }

        private static string ReverseString(string input)
        {
            StringBuilder sb = new StringBuilder();
            var endIdx = input.Length - 1;
            for(var i=endIdx;i>=0;i--)
            {
                sb.Append(input[i]);
            }

            return sb.ToString();
        }
    }
}
