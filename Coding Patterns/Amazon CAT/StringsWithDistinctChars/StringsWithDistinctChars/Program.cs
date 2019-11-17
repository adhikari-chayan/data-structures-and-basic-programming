using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringsWithDistinctChars
{
    class Program
    {
        static void Main(string[] args)
        {
            var result = SubstringsOfSizeKWithKDistinctChars("awaglknagawunagwkwagl", 4);
            foreach(var item in result)
            {
                Console.WriteLine(item);
            }

            Console.ReadKey();
        }

        public static HashSet<string> SubstringsOfSizeKWithKDistinctChars(string str,int k)
        {
            var ans = new HashSet<string>();
            var cur = new HashSet<char>();
            int curIdx = 0;
            for (int i = 0; i < str.Length; i++)
            {
                while (cur.Contains(str[i]))
                {
                    cur.Remove(str[curIdx++]);
                }

                cur.Add(str[i]);
                if (cur.Count == k)
                {
                    ans.Add(str.Substring(curIdx, k));
                    cur.Remove(str[curIdx]);
                    curIdx++;
                }

            }
            return ans;
        }


    }
}
