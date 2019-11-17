using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelsAndStones
{
    class Program
    {
        static void Main(string[] args)
        {
        }
        public static int NumOfJewelsInStones(string j,string s)
        {
            HashSet<char> jewels = new HashSet<char>();
            
            foreach(char c in j.ToCharArray())
            {
                jewels.Add(c);
            }

            int numJewels = 0;
            foreach(char c in s)
            {
                if (jewels.Contains(c))
                    numJewels++;
            }

            return numJewels;
        }
    }
}
