using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaxSubsetSumNoAdjacent
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = new int[] { 75, 105, 120, 75, 90, 135 };
            var result = MaxSubsetSumNoAdjacent(input);
            Console.WriteLine(result);
            Console.ReadKey();
        }

        public static int MaxSubsetSumNoAdjacent(int[] array)
        {
            if (array.Length == 0)
                return 0;
            else if (array.Length == 1)
                return array[0];

            int[] maxSums = (int[])array.Clone();
            maxSums[1] = Math.Max(array[0], array[1]);
            for(int i=2;i<array.Length;i++)
            {
                maxSums[i] = Math.Max(maxSums[i - 1], maxSums[i - 2] + array[i]);
            }
            return maxSums[array.Length - 1];
        }
    }
}
