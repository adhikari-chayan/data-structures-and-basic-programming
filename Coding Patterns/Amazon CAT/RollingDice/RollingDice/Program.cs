using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RollingDice
{
    class Program
    {
        static void Main(string[] args)
        {
            var dices = new int[] { 1, 2, 3 };
            var result = MissingNumber(dices);
            Console.WriteLine(result);
            Console.WriteLine("---------------");
            dices = new int[] { 1, 1, 6 };
            result = MissingNumber(dices);
            Console.WriteLine(result);
            Console.WriteLine("---------------");
            dices = new int[] { 1, 6,2, 3 };
            result = MissingNumber(dices);
            Console.WriteLine(result);
            Console.WriteLine("---------------");
            Console.ReadKey();
        }

        public static int MissingNumber(int[] nums)
        {
            // initializations
            int min = int.MaxValue;
            int temp;
            int[] count = new int[7];

            // counting occurrences of each number in the nums array and placing in count[]
            foreach (int num in nums) count[num]++;

            // can flip each dice to any number between 1 and 6, so we find the min of each possible top face.
            for (int i = 1; i < 7; i++)
            {
                /*
                 * count twice if compliment of desired (2*count[7-desired]) +
                 * total number of dice we have (nums.length) -
                 * count of desired occurrences (count[desired] -
                 * count of compliments (count[7-desired]).
                 * simplify to:
                 */

                //For any top pip, its complement of 7 will make 2 moves to reach top pip. Other pips will reach top pip in one move.
                temp = 2 * count[7 - i] + nums.Length - count[i] - count[7 - i];
                // check if what we calculated for moves is less than something we already found.
                min = temp < min ? temp : min;
            }
            return min;
        }
    }
}
