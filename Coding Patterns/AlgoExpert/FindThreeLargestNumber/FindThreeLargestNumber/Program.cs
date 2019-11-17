using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindThreeLargestNumber
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        public static int[] FindThreeLargestNumber(int[] array)
        {
            int[] threeLargest = new int[] { int.MinValue, int.MinValue, int.MinValue };
            foreach(var num in array)
            {
                UpdateLargest(num, threeLargest);
            }
            return threeLargest;
        }

        private static void UpdateLargest(int num, int[] threeLargest)
        {
            if (num > threeLargest[2])
                ShiftAndUpdate(num, threeLargest, 2);
            else if (num > threeLargest[1])
                ShiftAndUpdate(num, threeLargest, 1);
            else if (num > threeLargest[0])
                ShiftAndUpdate(num, threeLargest, 0);
        }

        private static void ShiftAndUpdate(int num, int[] threeLargest, int idx)
        {
            for(int i=0;i<=idx;i++)
            {
                if (i == idx)
                    threeLargest[i] = num;
                else
                    threeLargest[i] = threeLargest[i + 1];
            }
        }
    }
}
