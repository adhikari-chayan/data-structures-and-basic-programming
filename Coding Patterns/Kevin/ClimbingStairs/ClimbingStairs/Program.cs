using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClimbingStairs
{
    class Program
    {
        //https://leetcode.com/problems/climbing-stairs/description/
        static void Main(string[] args)
        {
            var input = 3;
            var result = ClimbStairs(input);
            Console.WriteLine(result);
            Console.ReadKey();
        }
        public static int ClimbStairs(int n)
        {
            int[] dp = new int[n + 1];
            dp[0] = 1;//The number of ways to climb 0 stairs is only 1, we dont climb
            dp[1] = 1;//The number of ways to climb 1 stair is only 1, we climb one step at a time.
            //iterating from 2 as we have 2 base cases
            for (var i = 2; i <= n; i++)
            {
                dp[i] = dp[i - 1] + dp[i - 2];//We could have only come to ith step from the previous step or two steps before it 
            }

            return dp[n];
         }
    }
}
