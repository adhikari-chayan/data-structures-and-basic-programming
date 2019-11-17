using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Conditions:

//You will pick exactly 2 numbers.
//You cannot pick the same element twice.
//If you have muliple pairs, select the pair with the largest number.
/// </summary>
namespace TwoSumProblem
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var input = new int[] { 1, 10, 25, 35, 60 };
                var result = UsingDictionary(input, 60);//BruteForce(input, 18);

                Console.WriteLine($"{result[0]}, {result[1]}");

                input = new int[] { 20, 50, 40, 25, 30, 10 };
                result = UsingDictionary(input, 60);//BruteForce(input, 18);

                Console.WriteLine($"{result[0]}, {result[1]}");

                input = new int[] { 5, 55, 40, 20, 30, 30 };
                result = UsingDictionary(input, 60);//BruteForce(input, 18);

                Console.WriteLine($"{result[0]}, {result[1]}");

                Console.ReadKey();
            }
            catch(Exception exp)
            {
                Console.WriteLine(exp.Message);
                Console.ReadKey();
            }
            
        }

        /// <summary>
        /// O(n^2)
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public static int[] BruteForce(int[] arr,int target)
        {
            for(int i=0;i<arr.Length;i++)
            {
                for(int j=i+1;j<arr.Length;j++)
                {
                    if (arr[i] + arr[j] == target)
                        return new int[] { i, j };
                }
            }

            throw new Exception("Pair not found");
        }

        /// <summary>
        /// O(logn) as binary search is O(logn)
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public static int[] UsingArrayAndSort(int[] arr,int target)
        {
            int start = 0;
            int end = arr.Length - 1;
            Array.Sort(arr);

            while(start<end)
            {
                if (arr[start] + arr[end] == target)
                    return new int[] { start, end };
                else if ((arr[start] + arr[end]) < target)
                    start++;
                else
                    end--;
            }
            throw new Exception("Pair not found");
        }

        /// <summary>
        /// O(n)
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public static int[] UsingDictionary(int[] arr,int target)
        {
            Dictionary<int,int> s = new Dictionary<int, int>();
            int[] result = new int[] { -1, -1 };

            int largest = int.MinValue;
            for(var i=0;i<arr.Length;i++)
            {
                var complement = target - arr[i];
                if((arr[i]>largest || complement > largest) && s.ContainsKey(complement))
                {
                    result[0] = s[complement];
                    result[1] = i;
                    largest = Math.Max(arr[i], complement);
                }
                if (s.ContainsKey(arr[i]))
                    s[arr[i]] = i;
                else
                    s.Add(arr[i], i);
                
            }
            return result;
        }

        

        #region Best Solution
        public int[] TwoSum(int[] nums, int target)
        {

            Dictionary<int, int> map = new Dictionary<int, int>();

            for (var i = 0; i < nums.Length; i++)
            {
                var remainingTarget = target - nums[i];
                if (map.ContainsKey(remainingTarget) && map[remainingTarget] != i)
                {
                    return new int[] { map[remainingTarget], i };
                }
                else if (map.ContainsKey(nums[i]))
                {
                    map[nums[i]] = i;
                }
                else
                {
                    map.Add(nums[i], i);
                }

            }

            return new int[] { };
        }
        #endregion


    }
}
