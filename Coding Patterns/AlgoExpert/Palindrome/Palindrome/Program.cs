using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Palindrome
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        public static bool IsPalindrome(string str)
        {
            int leftIdx = 0;
            int rightIdx = str.Length - 1;
            while(leftIdx<rightIdx)
            {
                if (str[leftIdx] != str[rightIdx])
                    return false;

                leftIdx++;
                rightIdx--;
            }
            return true;
        }
    }
}
