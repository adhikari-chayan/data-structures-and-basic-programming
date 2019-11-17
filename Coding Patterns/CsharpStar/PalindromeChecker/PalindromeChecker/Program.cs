using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PalindromeChecker
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = "kayak";
            bool result = IsPalindrome(input);
            Console.WriteLine(result);
            Console.ReadKey();
        }

        private static bool IsPalindrome(string input)
        {
            var leftIdx = 0;
            var rightIdx = input.Length - 1;
            while(leftIdx<rightIdx)
            {
                if (input[leftIdx] != input[rightIdx])
                    return false;

                leftIdx++;
                rightIdx--;
            }

            return true;
        }
    }
}
