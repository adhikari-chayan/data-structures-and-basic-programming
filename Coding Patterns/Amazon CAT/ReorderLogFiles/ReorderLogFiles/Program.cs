using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReorderLogFiles
{
    class Program
    {
        static void Main(string[] args)
        {
            //var input = new string[] { "a1 9 2 3 1", "g1 act car", "zo4 4 7", "ab1 off key dog", "a8 act zoo" };
            var input = new string[] { "l5sh 6 3869 08 1295", "16o 94884717383724 9", "43 490972281212 3 51", "9 ehyjki ngcoobi mi", "2epy 85881033085988", "7z fqkbxxqfks f y dg", "9h4p 5 791738 954209", "p i hz uubk id s m l", "wd lfqgmu pvklkdp u", "m4jl 225084707500464", "6np2 bqrrqt q vtap h", "e mpgfn bfkylg zewmg", "ttzoz 035658365825 9", "k5pkn 88312912782538", "ry9 8231674347096 00", "w 831 74626 07 353 9", "bxao armngjllmvqwn q", "0uoj 9 8896814034171", "0 81650258784962331", "t3df gjjn nxbrryos b" };
            var result = ReorderLogFiles1(input);
            foreach(var item in result)
                Console.WriteLine(item);
            Console.ReadKey();
        }

        public static string[] ReorderLogFiles(string[] logs)
        {
            List<string> letterLogs = new List<string>();
            List<string> digitLogs = new List<string>();

            foreach(var log in logs)
            {
                string[] logEntry = log.Split(' ');
                long temp;
                var isNumeric = long.TryParse(logEntry[1], out temp) ;
                if (isNumeric)
                {
                    digitLogs.Add(log);
                }
                else
                {
                    letterLogs.Add(log);
                }
            }

            letterLogs.Sort(new CustomComparer());
            return letterLogs.Concat(digitLogs).ToList().ToArray();
        }

        #region Better Solution
        public static string[] ReorderLogFiles1(string[] logs)
        {
            var list = new List<string>();
            var listn = new List<string>();
            foreach (string s in logs)
            {
                var split1 = s.Split(new[] { ' ' }, 2);
                if (char.IsDigit(split1[1][0]))
                    listn.Add(s);
                else
                    list.Add(s);
            }
            list.Sort((x, y) =>
            {
                var s1 = x.Substring(x.IndexOf(' ') + 1);
                var s2 = y.Substring(y.IndexOf(' ') + 1);
                var result = string.Compare(s1, s2, StringComparison.Ordinal);
                if (result == 0)
                {
                    result = string.Compare(x, y, StringComparison.Ordinal);
                }
                return result;
            });
            return list.Concat(listn).ToArray();
        }

        #endregion


    }

    public class CustomComparer : IComparer<string>
    {
        

        public int Compare(string x, string y)
        {
            int result;
            string[] split1 = x.Split(' ');
            string[] split2 = y.Split(' ');

            var length = Math.Min(split1.Length, split2.Length);
            for(int i=1;i<length-1;i++)
            {
                result = split1[i].CompareTo(split2[i]);
                if (result == 0)
                    continue;
                else
                    return result;
            }
            return 0;
        }
    }
}
