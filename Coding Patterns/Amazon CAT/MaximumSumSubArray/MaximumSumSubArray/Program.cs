using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaximumSumSubArray
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = new int[] { 2,1,5,1,3,2};
            var result = SlidingWindow(input, 3);//BruteForce(input, 3);
            Console.WriteLine(result);
            Console.ReadKey();

        }
        /// <summary>
        /// O(n*k)
        /// </summary>
        /// <param name="array"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public static int BruteForce(int[] array,int k)
        {
            int maxSum = 0;
            for(var i=0;i<array.Length-k;i++)
            {
                var sum = 0;
                for(var j=i;j<i+k;j++)
                {
                    sum += array[j];
                }
                maxSum = Math.Max(sum, maxSum);
            }
            return maxSum;
        }
        /// <summary>
        /// O(n)
        /// </summary>
        /// <param name="array"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public static int SlidingWindow(int[] array,int k)
        {
            int start = 0;
            int sum = 0;
            int maxSum = 0;

            for(int end=0;end<array.Length;end++)
            {
                sum += array[end];
                if (end >= k - 1)
                {
                    
                    maxSum = Math.Max(sum, maxSum);
                    sum = sum - array[start];
                    start++;
                }
            }
            return maxSum;
        }
    }
}
