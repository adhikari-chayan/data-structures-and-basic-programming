using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LongestPalindromicSubstring
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = "abaxyzzyxf";
            var result = LongestPalindromicSubstringAlternate(input);
            Console.WriteLine(result);
            Console.ReadKey();
        }

        public static string LongestPalindromicSubstring(string str)
        {
            string longest = "";
            for (int i = 0; i < str.Length; i++)
            {
                for (int j = 1; j <= str.Length-i; j++)
                {
                    string substring = str.Substring(i, j);
                    Console.WriteLine(substring);
                    if (substring.Length > longest.Length && IsPalindrome(substring))
                        longest = substring;
                }
            }



            return longest;
        }

        private static bool IsPalindrome(string str)
        {
            int leftIdx = 0;
            int rightIdx = str.Length - 1;

            while(leftIdx<rightIdx)
            {
                if(str[leftIdx]!=str[rightIdx])
                {
                    return false;
                }
                leftIdx++;
                rightIdx--;
            }
            return true;
        }

        public static string LongestPalindromicSubstringAlternate(string str)
        {
            int[] currentLongest = new int[] { 0, 1 };//All single letters are palindromes
            for(int i=1;i<str.Length;i++)//We start from 1 as we know that on starting from 0 we cant expand to left
            {
                int[] odd = GetLongestPalindromeFrom(str, i - 1, i + 1);
                int[] even = GetLongestPalindromeFrom(str, i - 1, i);

                int[] longest = odd[1] - odd[0] > even[1] - even[0] ? odd : even;
                currentLongest = currentLongest[1] - currentLongest[0] > longest[1] - longest[0] ? currentLongest : longest;
            }
            return str.Substring(currentLongest[0], Math.Min(str.Length, currentLongest[1]) - currentLongest[0]);
        }

        private static int[] GetLongestPalindromeFrom(string str, int leftIdx, int rightIdx)
        {
            while(leftIdx>=0 && rightIdx<str.Length)
            {
                if(str[leftIdx]!=str[rightIdx])
                {
                    break;
                }
                leftIdx--;
                rightIdx++;
            }
            return new int[]{
                leftIdx+1,
                rightIdx

            };
        }
    }
}
