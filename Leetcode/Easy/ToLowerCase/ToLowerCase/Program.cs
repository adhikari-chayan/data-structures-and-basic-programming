using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToLowerCase
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        public static string ToLowerCase(string str)
        {
            if (String.IsNullOrEmpty(str) || str.Length == 0)
                return string.Empty;

            var lower = "";
            foreach (char c in str)
            {
                if (c >= 65 && c <= 90)
                    lower = lower +(char)(c + 32);
                else
                    lower += c;
            }
            return lower;
        }

        //Better Soln
        //public string ToLowerCase(string str)
        //{
        //    if (str == null || str.Length == 0)
        //    {
        //        return str;
        //    }

        //    var diff = 0;
        //    var res = new StringBuilder();

        //    for (var i = 0; i < str.Length; i++)
        //    {
        //        diff = str[i] - 'A';

        //        if (diff >= 0 && diff < 26)
        //        {
        //            res.Append((char)(diff + 'a'));
        //        }
        //        else
        //        {
        //            res.Append(str[i]);
        //        }
        //    }

        //    return res.ToString();
        //}

    }
}
