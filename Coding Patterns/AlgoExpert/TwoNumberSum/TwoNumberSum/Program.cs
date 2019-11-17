using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwoNumberSum
{
    class Program
    {
        static void Main(string[] args)
        {

            var input = new int[] { 3, 5, -4, 8, 11, 1, -1, 6 };
            var target = 10;
            var output = TwoNumberSumUsingTwoPointerMethod(input, target);
            foreach(var item in output)
                Console.WriteLine(item);

            Console.ReadKey();


          
        }

        /// <summary>
        /// O(n^2)
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public static int[] TwoNumberSumBruteForce(int[] arr, int target)
        {
            int[] result; 
            
            for(var i=0;i<arr.Length-1;i++)
            {
                for(var j=i+1;j<arr.Length;j++)
                {
                    int sum = arr[i] + arr[j];
                    if(sum==target)
                    {
                        if (arr[i] > arr[j])
                            result = new int[] { arr[j], arr[i] };
                        else
                            result = new int[] {  arr[i], arr[j] };

                        return result;
                    }
                }
            }
            return new int[0];
        }

        /// <summary>
        /// T.C: O(n) , S.C: O(n)
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public static int[] TwoNumberSumUsingHashMap(int[] arr,int target)
        {
            Dictionary<int, bool> nums = new Dictionary<int, bool>();
            for(var i=0;i<arr.Length;i++)
            {
                int potentialMatch = target - arr[i];
                if (nums.ContainsKey(potentialMatch))
                {
                    if (potentialMatch > arr[i])
                        return new int[] {  arr[i],potentialMatch };
                    else
                        return new int[] { potentialMatch,arr[i] };
                }
                else
                    nums.Add(arr[i], true);
            }
            return new int[0];
        }

        /// <summary>
        /// T.C: O(nlogn), S.C: O(1)
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public static int[] TwoNumberSumUsingTwoPointerMethod(int[]arr,int target)
        {
            Array.Sort(arr);
            var start = 0;
            var end = arr.Length-1;

            while(start<end)
            {
                int sum = arr[start] + arr[end];
                if (sum == target)
                {
                    return new int[] { arr[start], arr[end] };
                }
                else if (sum < target)
                    start++;
                else if (sum > target)
                    end--;
            }
            return new int[0];
        }
    }
}
    