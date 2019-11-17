using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MissingNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = new int[] { 3, 0, 1 };
            var result = MissingNumberAlternate(input);
            Console.WriteLine(result);
            Console.ReadKey();
        }

        public static int MissingNumber(int[] nums)
        {
            int sum = 0;
            foreach(int num in nums)
            {
                sum = sum + num;
            }

            int n = nums.Length + 1;//Adding 1 as 1 number is missing from 0 to n
            int projectedSum = n * (n - 1) / 2;
            return projectedSum - sum;
        }

        public static int MissingNumberAlternate(int[] nums)
        {
            HashSet<int> numSet = new HashSet<int>();
            foreach(var num in nums)
            {
                numSet.Add(num);
            }

            for(var i=0;i<=nums.Length;i++)
            {
                if (!numSet.Contains(i))
                    return i;

            }
            return -1;
        }
    }
}
