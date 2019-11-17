using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LongestStringMadeUpOfOnlyVowel
{
    class Program
    {
        static void Main(string[] args)
        {
            int res = LongestVowelsOnlySubstring("letsgosomewhere");
            Console.WriteLine(res);
            Console.WriteLine("---------------------");
            res = LongestVowelsOnlySubstring("earthproblem");
            Console.WriteLine(res);
            Console.WriteLine("---------------------");
            res = LongestVowelsOnlySubstring("aeioufaeioufaeiou");
            Console.WriteLine(res);

            Console.ReadKey();
        }

        public static int LongestVowelsOnlySubstring(string s)
        {
            int start = 0, end = s.Length - 1, res = 0, c = 0, i = 0;
            List<int> h=new List<int>();
            while (start <= end)
            {
                if (s[start] == 'a' || s[start] == 'o' || s[start] == 'u' || s[start] == 'e' || s[start] == 'i')
                    ++start;
                else if (s[end] == 'a' || s[end] == 'o' || s[end] == 'u' || s[end] == 'e' || s[end] == 'i')
                    --end;
                else break;
            }
            if (start > end) return s.Length;
            for (i = start; i <= end; i++)
            {
                if (s[i] == 'a' || s[i] == 'o' || s[i] == 'u' || s[i] == 'e' || s[i] == 'i') ++c;
                else
                {
                    if (c > 0)
                        h.Add(c);
                    c = 0;
                }
            }
            end = s.Length - end - 1;
            for (i = 0; i < h.Count(); i++)
            {
                res = Math.Max(res, Math.Max(start + h[i], Math.Max(end + h[i], start + h[i] + end)));
            }
            return res;


        }
    }
}
