using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniqueEmailAddress
{
    class Program
    {
        //https://leetcode.com/problems/unique-email-addresses/
        static void Main(string[] args)
        {
            var input = new string[] {"test.email+alex@leetcode.com", "test.e.mail+bob.cathy@leetcode.com", "testemail+david@lee.tcode.com"};
            var result = NumUniqueEmails(input);
            Console.WriteLine(result);
            Console.ReadKey();
        }

        public static int NumUniqueEmails(string[] emails)
        {
            HashSet<string> set = new HashSet<string>();

            foreach(var email in emails)
            {
                StringBuilder address = new StringBuilder();
                for(int i=0;i<email.Length;i++)
                {
                    char c = email[i];
                    if (c == '.')
                        continue;
                    else if (c == '+')
                    {
                        while (email[i] != '@')
                        {
                            i++;
                        }
                        address.Append(email.Substring(i + 1));
                    }
                    else
                        address.Append(c);
                }
                set.Add(address.ToString());
            }

            return set.Count;
        }
    }
}
