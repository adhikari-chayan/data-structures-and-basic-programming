using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetterCombinationsOfPhoneNumber
{
    class Program
    {
        //https://leetcode.com/problems/letter-combinations-of-a-phone-number/description/
        static void Main(string[] args)
        {
            var input = "23";
            var result = LetterCombinations(input);

            foreach(var item in result)
                Console.Write(item+" ");
            Console.ReadKey();
        }

        public static List<string> LetterCombinations(string digits)
        {
            List<string> result = new List<string>();
            if (digits == null || digits.Length == 0)
                return result;

            //the index refers to the digits
            string[] mapping = new string[]
            {
                "0",//dummy
                "1",//dummy
                "abc",
                "def",
                "ghi",
                "jkl",
                "mno",
                "pqrs",
                "tuv",
                "wxyz"
            };

            LetterCombinationsRecursive(result,digits,"",0,mapping);
            return result;

        }
    
        //index represnt the digit we are at
        private static void LetterCombinationsRecursive(List<string> result, string digits, string current, int index, string[] mapping)
        {
            //Base Case
            if (index == digits.Length)
            {
                result.Add(current);
                return;
            }
            string letters = mapping[digits[index] - '0'];//converting string to int

            for(int i=0;i<letters.Length;i++)
            {
                LetterCombinationsRecursive(result, digits, current + letters[i], index + 1, mapping);

            }
        }

        
    }
}
