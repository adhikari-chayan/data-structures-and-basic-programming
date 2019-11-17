using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoveDuplicateInString
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = "Csharpstar";
            var result = RemoveDuplicateInString(input);
            Console.WriteLine(result);

            Console.ReadKey();


        }

        public static string RemoveDuplicateInString(string str)
        {
            StringBuilder result = new StringBuilder();
            HashSet<char> set = new HashSet<char>();

            foreach (char c in str)
            {
                if(!set.Contains(c))
                {
                    set.Add(c);
                    result.Append(c);
                }
            }
            return result.ToString();
        }
    }
}
