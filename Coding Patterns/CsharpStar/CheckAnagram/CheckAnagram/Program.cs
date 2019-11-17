using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckAnagram
{
    class Program
    {
        static void Main(string[] args)
        {
            var word1 = "Silent";
            var word2 = "Listen";
            var result = IsAnagram(word1, word2);
            Console.WriteLine(result);
            Console.ReadKey();
        }

        private static bool IsAnagram(string word1, string word2)
        {
            word1 = word1.ToLower();
            word2 = word2.ToLower();

            char[] array1 = word1.ToCharArray();
            char[] array2 = word2.ToCharArray();

            Array.Sort(array1);
            Array.Sort(array2);
          
            if (String.Equals(new string(array1),new string(array2)))
                return true;
            return false;
        }
    }
}
