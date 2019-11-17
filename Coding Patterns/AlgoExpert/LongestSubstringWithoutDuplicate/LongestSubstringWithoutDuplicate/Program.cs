using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LongestSubstringWithoutDuplicate
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = "clementisacap";
            var result = LongestSubstringWithoutDuplication(input);
            Console.WriteLine(result);
            Console.ReadKey();
        }

        public static string LongestSubstringWithoutDuplication(string str)
        {
            Dictionary<char, int> lastSeen = new Dictionary<char, int>();
            int startIdx = 0;
            int[] longest = new int[] { 0, 1 };
            for(int i=0;i<str.Length;i++)
            {
                char c = str[i];
                if(lastSeen.ContainsKey(c))
                {
                    startIdx = Math.Max(startIdx, lastSeen[c] + 1);
                }
                if(longest[1]-longest[0]<i+1-startIdx)
                {
                    longest = new int[] { startIdx, i + 1 };
                }
                if (lastSeen.ContainsKey(c))
                    lastSeen[c] = i;
                else
                    lastSeen.Add(c,i);
            }
            string result = str.Substring(longest[0], Math.Min(str.Length, longest[1]) - longest[0]);
            return result;
        }
    }
}
