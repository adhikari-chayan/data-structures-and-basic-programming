using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestTimeToBuySellStocks
{
    class Program
    {

        //Design an algorithm to find the maximum profit. You may complete as many transactions as you like (i.e., buy one and sell one share of the stock multiple times).

        //Note: You may not engage in multiple transactions at the same time(i.e., you must sell the stock before you buy again).

        //https://leetcode.com/problems/best-time-to-buy-and-sell-stock-ii/solution/
        static void Main(string[] args)
        {
            var input = new int[] { 7, 1, 5, 3, 6, 4 };
            var result = MaxProfit(input);
            Console.WriteLine(result);
            Console.ReadKey();
        }

        public static int MaxProfit(int[] prices)
        {
            if (prices == null || prices.Length == 0)
                return 0;

            int maxProfit = 0;
            for(var i=0;i<prices.Length-1;i++)
            {
                if(prices[i+1] > prices[i])
                {
                    maxProfit += prices[i + 1] - prices[i];
                }
            }

            return maxProfit;
        }
    }
}
