using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberOfWaysToMakeChange
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = new int[] { 1, 5, 10, 25 };
            var target = 10;
            var result = NumberOfWaysToMakeChange(target,input);
            Console.WriteLine(result);
            Console.ReadKey();
        }

        public static int NumberOfWaysToMakeChange(int n,int[] denoms)
        {
            int[] ways = new int[n + 1];
            ways[0] = 1;
            foreach(var denom in denoms)
            {
                for (int amount = 1; amount < ways.Length; amount++)
                {
                    if (denom <= amount)
                    {
                        ways[amount] += ways[amount - denom];
                    }
                }
            }
            return ways[n];
        }
    }
}
