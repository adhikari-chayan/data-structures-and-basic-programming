using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DefangingAnIPAddress
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = "1.1.1.1";
            var result = DefangIpaddr(input);
            Console.WriteLine(result);
            Console.ReadKey();
        }

        public static string DefangIpaddr(string address)
        {
            if (String.IsNullOrEmpty(address))
                return string.Empty;

            string defangedIpAddr= Regex.Replace(address, "\\.","[.]");
            return defangedIpAddr;
        }

        //Best in Time
        //public string DefangIPaddr(string address)
        //{
        //    string result = "";
        //    foreach (char c in address)
        //    {
        //        if (c == '.')
        //        {
        //            result = result + ("[.]");
        //        }
        //        else
        //        {
        //            result = result + c;
        //        }
        //    }
        //    return result;
        //}

    }
}
