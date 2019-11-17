using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelsandStones
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        public static int NumJewelsInStones(string J, string S)
        {
            if (S.Length == 0 || J.Length == 0)
                return 0;
            HashSet<char> jewelList = new HashSet<char>();
            foreach (char c in J)
                jewelList.Add(c);

            int jewelCount = 0;
            foreach(char c in S)
            {
                if (jewelList.Contains(c))
                    jewelCount++;
            }

            return jewelCount;

        }

        //Better
        //public int NumJewelsInStones(string J, string S)
        //{
        //    int count = 0;
        //    for (int i = 0; i < J.Length; i++)
        //    {
        //        for (int j = 0; j < S.Length; j++)
        //        {
        //            if (J[i] == S[j])
        //                count++;
        //        }
        //    }
        //    return count;
        //}
    }
}
