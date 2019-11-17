using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoveNumber
{
    class Program
    {
        //https://leetcode.com/problems/remove-element/description/
        static void Main(string[] args)
        {
            var input = new int[] { 0, 1, 2, 2, 3, 0, 4, 2 };
            var result = RemoveNumber(input, 2);
            Console.WriteLine(result);
            Console.ReadKey();
        }

        public static int RemoveNumber(int[] nums,int value)
        {
            int idx = 0;
            foreach(var num in nums)
            {
                if(num!=value)
                {
                    nums[idx] = num;
                    idx++;
                }
            }
            return idx;
        }
    }
}
