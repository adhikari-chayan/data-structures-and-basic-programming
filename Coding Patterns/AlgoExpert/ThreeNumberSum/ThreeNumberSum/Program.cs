using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreeNumberSum
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = new int[] { 12, 3, 1, 2, -6, 5, -8, 6 };
            var target = 0;
            var result = ThreeNumberSumUsingBruteForce(input, target);
            foreach(var triplet in result)
            {
                Console.WriteLine($"{triplet[0]},{triplet[1]},{triplet[2]}");
            }
            Console.ReadKey();
        }

        /// <summary>
        /// T.C: O(n^2), S.C: O(n)
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public static List<int[]> ThreeNumberSumUsingTwoPointers(int[] arr, int target)
        {
            List<int[]> triplets = new List<int[]>();
            Array.Sort(arr);//O(nlogn)
            for(int i=0;i<arr.Length-2;i++)
            {
                int left = i + 1;
                int right = arr.Length - 1;
                while(left<right)
                {
                    int currentSum = arr[i] + arr[left] + arr[right];
                    if (currentSum == target)
                    {
                        int[] newTriplet = new int[] { arr[i], arr[left], arr[right] };
                        triplets.Add(newTriplet);
                        left++;
                        right--;
                    }
                    else if (currentSum < target)
                        left++;
                    else if (currentSum > target)
                        right--;
                }
            }
            return triplets;
        }
        /// <summary>
        /// T.C: O(n^3)
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public static List<int[]> ThreeNumberSumUsingBruteForce(int[] arr, int target)
        {
            List<int[]> triplets = new List<int[]>();
            Array.Sort(arr);
            for(var i=0;i<arr.Length-2;i++)
            {
                for(var j=i+1;j<arr.Length-1;j++)
                {
                    for(var k=j+1;k<arr.Length;k++)
                    {
                        int sum = arr[i] + arr[j] + arr[k];
                        if(sum==target)
                        {
                            var newTriplet = new int[] { arr[i], arr[j], arr[k] };
                            Array.Sort(newTriplet);
                            triplets.Add(newTriplet);
                        }
                    }
                }
            }

            return triplets;

        }
    }
}
