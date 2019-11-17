using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwoIntegersSumToTarget
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = new int[] { 1, 5, 6, 2, 4, 9, 44, 13 };
            var target = 11;
            var result = TwoIntegersSumToTargetAlternate(input, target);
            Console.WriteLine(result);
            Console.ReadKey();
        }

        private static bool TwoIntegersSumToTarget(int[] input, int target)
        {
            Array.Sort(input);
            int leftIdx = 0;
            int rightIdx = input.Length - 1;
            while(leftIdx<rightIdx)
            {
                int sum = input[leftIdx] + input[rightIdx];
                if (target < sum)
                    rightIdx--;
                else if (target > sum)
                    leftIdx++;
                else
                    return true;
            }
            return false;
        }

        private static bool TwoIntegersSumToTargetAlternate(int[] input, int target)
        {
            HashSet<int> set = new HashSet<int>();
            foreach(var number in input)
            {
                int potentialMatch = target - number;
                if (set.Contains(potentialMatch))
                {
                    return true;

                }
                else
                    set.Add(number);
            }

            return false;
        }
    }
}
