using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinSubArraySort
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = new int[] { 1, 2, 4, 7, 10, 11, 7, 12, 6, 7, 16, 18, 19 };
            var result = SubArraySort(input);
            foreach(var item in result)
                Console.WriteLine(item);

            Console.ReadKey();
        }

        public static int[] SubArraySort(int[] arr)
        {
            int minOutOfOrder = int.MaxValue;
            int maxOutOfOrder = int.MinValue;
            for(int i=0;i<arr.Length;i++)
            {
                int num = arr[i];
                if(IsOutOfOrder(i,num,arr))
                {
                    minOutOfOrder = Math.Min(minOutOfOrder, num);
                    maxOutOfOrder = Math.Max(maxOutOfOrder, num);
                }
            }
            if (minOutOfOrder == int.MaxValue)
                return new int[] { -1, -1 };
            int subArrayLeftIdx = 0;
            while(minOutOfOrder >= arr[subArrayLeftIdx])
            {
                subArrayLeftIdx++;
            }
            int subArrayRightIdx = arr.Length - 1;
            while(maxOutOfOrder <= arr[subArrayRightIdx])
            {
                subArrayRightIdx--;
            }

            return new int[] { subArrayLeftIdx, subArrayRightIdx };
        }

        private static bool IsOutOfOrder(int i, int num, int[] arr)
        {
            if (i == 0)
                return num > arr[i + 1];
            if (i == arr.Length - 1)
                return num < arr[i - 1];
            return num < arr[i - 1] || num > arr[i + 1];
        }
    }
}
