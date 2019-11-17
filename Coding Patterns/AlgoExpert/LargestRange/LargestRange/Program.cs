using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LargestRange
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = new int[] { 1, 11, 3, 0, 15, 5, 2, 4, 10, 7, 12, 6 };
            var result = LargestRange(input);

            foreach(var item in result)
            {
                Console.WriteLine(item);
            }

            Console.ReadKey();
        }

        public static int[] LargestRange(int[] arr)
        {
            int[] bestRange = new int[2];
            Dictionary<int, bool> nums = new Dictionary<int, bool>();
            int longestLength = 0;

            foreach(var num in arr)
            {
                nums.Add(num, true);
            }

            foreach(var num in arr)
            {
                if (!nums[num])
                    continue;
                nums[num] = false;
                int currentLength = 1;
                int left = num - 1;
                int right = num + 1;
                while(nums.ContainsKey(left))
                {
                    nums[left] = false;
                    currentLength++;
                    left--;
                }
                while(nums.ContainsKey(right))
                {
                    nums[right] = false;
                    currentLength++;
                    right++;
                }

                if(currentLength>longestLength)
                {
                    longestLength = currentLength;
                    bestRange = new int[] { left + 1, right - 1 };
                }
            }

            return bestRange;
        }
    }
}
