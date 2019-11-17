using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesOnFlight
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = new int[] { 90, 85, 75, 60, 120, 150, 125 };
            var result = TwoSumClosest(input, 220);//BruteForce(input, 18);

            Console.WriteLine($"{result[0]}, {result[1]}");

            input = new int[] { 90,85,75,100,60,115 };
            result = TwoSumClosest(input, 180);//BruteForce(input, 18);

            Console.WriteLine($"{result[0]}, {result[1]}");

            Console.ReadKey();
        }

        public static int[] TwoSumClosest(int[] arr,int target)
        {
            Array.Sort(arr);
            int start = 0;
            int end = arr.Length - 1;
            int max = 0;
            
            int[] result = new int[] { -1, -1 };
            while(start < end)
            {
                int sum = arr[start] + arr[end];
                if (sum > max && sum <= target)
                {
                    max = sum;
                    result[0] = arr[start];
                    result[1] = arr[end];
                   
                    
                }
                if (sum > target)
                    end--;
                else
                    start++;
            }
            return result;
        }
    }
}
